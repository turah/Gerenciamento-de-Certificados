using MathNet.Numerics.RootFinding;
using SDTBusiness.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using SDTDomainModel.Entities;
using ScaredFingers.UnitsConversion;
using SDTDomainModel.Enums;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using SDTFramework.Utils.Exceptions;
using SDTBusiness.Utils;

namespace SDTBusiness.Registers
{
    public class CalculationModuleBusinessFacade : BaseUnity
    {
        
        public static void CalculateKVessels(double drumInsideDiameterInMeter, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem) 
        {
            c.AtInSquareMeter = CalculateArea(drumInsideDiameterInMeter);

            if (IsValidNumber(c.VaporMassFlowRate) && IsValidNumber(c.VaporMassDensity) && c.VaporMassDensityInKilogramPerCubicMeter != 0.0)
            {
                c.QvInCubicMeterPerSecond = c.VaporMassFlowRateInKilogramPerSecond / c.VaporMassDensityInKilogramPerCubicMeter;

                if (IsValidNumber(c.HCMassDensity))
                {
                    c.KHCVesselInMeterPerSecond = CalculateKVessel(c.QvInCubicMeterPerSecond, c.AtInSquareMeter, c.VaporMassDensityInKilogramPerCubicMeter, c.HCMassDensityInKilogramPerCubicMeter);
                    MeasurementUnitBusinessFacade.ConvertKHCvesselsToOutputUnits(c, measurementUnitSystem);
                }

                if (IsValidNumber(c.WaterMassDensity))
                {
                    c.KWaterVesselInMeterPerSecond = CalculateKVessel(c.QvInCubicMeterPerSecond, c.AtInSquareMeter, c.VaporMassDensityInKilogramPerCubicMeter, c.WaterMassDensityInKilogramPerCubicMeter);
                    MeasurementUnitBusinessFacade.ConvertKWatervesselsToOutputUnits(c, measurementUnitSystem);
                }
            }
        }
                
        private static double CalculateKVessel(double QvInCubicMeterPerSecond, double AtInSquareMeter, double vaporMassDensityInKilogramPerCubicMeter, double massDensityInKilogramPerCubicMeter) 
        {
            return QvInCubicMeterPerSecond / AtInSquareMeter * Math.Sqrt(vaporMassDensityInKilogramPerCubicMeter / (massDensityInKilogramPerCubicMeter - vaporMassDensityInKilogramPerCubicMeter));
        }

        public static void CalculateInletNozzleOutputs(double inletNozzleInsideDiameterInMeter, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            CalculateInletMomentum(inletNozzleInsideDiameterInMeter, c, measurementUnitSystem);
            CalculatePercentageEntrainedHCAndWater(inletNozzleInsideDiameterInMeter, c);
        }

        public static void CalculateLiquidOutletOutputs(double liquidOutletNozzleInsideDiameterInMeter, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (IsValidNumber(c.Qlt) && IsValidNumber(c.HCMassDensity) && IsValidNumber(c.VaporMassDensity))
            {
                c.LiquidOutletNozzleCalculatedDRFInMilimeter = CalculateDRFInMilimeter(c.QltInCubicMeterPerSecond, c.HCMassDensityInKilogramPerCubicMeter, c.VaporMassDensityInKilogramPerCubicMeter, c.WaterMassDensityInKilogramPerCubicMeter);
                c.LiquidOutletNozzleVelocityDRFInMeterPerSecond = CalculateDRFVelocity(c.QltInCubicMeterPerSecond, liquidOutletNozzleInsideDiameterInMeter);
                c.LiquidOutletNozzleInsideDiameterNOTAcceptable = (c.LiquidOutletNozzleVelocityDRFInMeterPerSecond > 0.9144 ? true : false);

                MeasurementUnitBusinessFacade.ConvertLiquidOutletOutputsToOutputUnits(c, measurementUnitSystem);
            }
        }

        public static double CalculateDRFInMilimeter(double QltInCubicMeterPerSecond, double HCMassDensityInKilogramPerCubicMeter, double VaporMassDensityInKilogramPerCubicMeter, double WaterMassDensityInKilogramPerCubicMeter)
        {
            double massDensity = (HCMassDensityInKilogramPerCubicMeter == 0 ? WaterMassDensityInKilogramPerCubicMeter : HCMassDensityInKilogramPerCubicMeter);
            double sub = massDensity / (massDensity - VaporMassDensityInKilogramPerCubicMeter);
            double QltInCubicMeterPerHour = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(QltInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerHour, ConversionUnitType.VolumeFlowRateUnit);
            double DRF = 41.566 * (Math.Pow(QltInCubicMeterPerHour, 0.39)) * (Math.Pow(sub,0.2));
            return DRF;
        }

        public static double CalculateDRFVelocity(double QltInCubicMeterPerSecond, double liquidOutletNozzleInsideDiameterInMeter)
        {
            double A = CalculateArea(liquidOutletNozzleInsideDiameterInMeter);
            return CalculateVelocity(QltInCubicMeterPerSecond, A);
        }

        #region Momemtum

        public static void CalculateInletMomentum(double inletNozzleInsideDiameterInMeter, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            CalculateVolumetricFlowRates(c, measurementUnitSystem);
            
            c.AiInSquareMeter = CalculateArea(inletNozzleInsideDiameterInMeter);

            if (c.QtInCubicMeterPerSecond != 0.0)
            {
                double waterRate = 0.0, hcRate = 0.0, vaporRate = 0.0;

                if (IsValidNumber(c.HCMassDensity)){
                    hcRate = (c.HCMassDensityInKilogramPerCubicMeter * (c.QhcInCubicMeterPerSecond / c.QtInCubicMeterPerSecond));
                }
                if (IsValidNumber(c.WaterMassDensity))
                {
                    waterRate = (c.WaterMassDensityInKilogramPerCubicMeter * (c.QwInCubicMeterPerSecond / c.QtInCubicMeterPerSecond));
                }
                if (IsValidNumber(c.VaporMassDensity))
                {
                    vaporRate = (c.VaporMassDensityInKilogramPerCubicMeter * (c.QvInCubicMeterPerSecond / c.QtInCubicMeterPerSecond));
                }

                c.PmInKilogramPerCubicMeter = hcRate + waterRate + vaporRate;
            
                c.ViInMeterPerSecond = CalculateVelocity(c.QtInCubicMeterPerSecond, c.AiInSquareMeter);
                c.MiInKilogramPerMeterSquareSecond = CalculateMomentum(c.PmInKilogramPerCubicMeter, c.ViInMeterPerSecond);

                MeasurementUnitBusinessFacade.ConvertInletMomentumVariablesToOutputUnits(c, measurementUnitSystem);
            }
            
        }

        public static void CalculateOutletMomentum(double outletNozzleInsideDiameterInMeter, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem) 
        {
            c.AoutInSquareMeter = CalculateArea(outletNozzleInsideDiameterInMeter);

            if (IsValidNumber(c.VaporMassDensity))
            {
                c.VoutInMeterPerSecond = CalculateVelocity(c.QvInCubicMeterPerSecond, c.AoutInSquareMeter);
                c.MoutInKilogramPerMeterSquareSecond = CalculateMomentum(c.VaporMassDensityInKilogramPerCubicMeter, c.VoutInMeterPerSecond);

                MeasurementUnitBusinessFacade.ConvertVaporOutletMomentumVariablesToOutputUnits(c, measurementUnitSystem);
            }
            
        }

        private static double CalculateMomentum(double P, double V)
        {
            return P * (Math.Pow(V, 2));
        }

        private static void CalculateVolumetricFlowRates(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (c.VaporMassDensityInKilogramPerCubicMeter != 0 && IsValidNumber(c.VaporMassFlowRate))
            {
                c.QvInCubicMeterPerSecond = c.VaporMassFlowRateInKilogramPerSecond / c.VaporMassDensityInKilogramPerCubicMeter;
            }

            if (c.HCMassDensityInKilogramPerCubicMeter != 0 && IsValidNumber(c.HCMassFlowRate))
            { 
                c.QhcInCubicMeterPerSecond = c.HCMassFlowRateInKilogramPerSecond / c.HCMassDensityInKilogramPerCubicMeter;
            }

            if (c.WaterMassDensityInKilogramPerCubicMeter != 0 && IsValidNumber(c.WaterMassFlowRate))
            {
                c.QwInCubicMeterPerSecond = c.WaterMassFlowRateInKilogramPerSecond / c.WaterMassDensityInKilogramPerCubicMeter;
            }
            

            c.QltInCubicMeterPerSecond = c.QhcInCubicMeterPerSecond + c.QwInCubicMeterPerSecond;

            c.QtInCubicMeterPerSecond = c.QhcInCubicMeterPerSecond + c.QwInCubicMeterPerSecond + c.QvInCubicMeterPerSecond;

            MeasurementUnitBusinessFacade.ConvertVolumetricFlowRatesToOutputUnits(c, measurementUnitSystem);
        }

        #endregion

        #region Inlet Liquid EntrainedCalculatePercentageEntrainedHCAndWater

        private static void CalculatePercentageEntrainedHCAndWater(double inletNozzleInsideDiameterInMeter, SeparatorProcessDesignCase c)
        {
            if (IsValidNumber(c.AiInSquareMeter) && IsValidNumber(c.Qv) && IsValidNumber(c.VaporMassDensity))
            {
                if (IsValidNumber(c.HCMassDensity) && IsValidNumber(c.HCViscosity) && IsValidNumber(c.HCSurfaceTension) && IsValidNumber(c.Qhc))
                {
                    c.InletNozzleEntrainedHC = UseOlgaCorrelationToCalculatePercentageLiquidEntrained(inletNozzleInsideDiameterInMeter, c.HCMassDensityInKilogramPerCubicMeter, c.HCViscosityInKilogramPerMeterSecond, c.HCSurfaceTensionInNewtonPerMeter, c.QhcInCubicMeterPerSecond, c.AiInSquareMeter, c.QvInCubicMeterPerSecond, c.VaporMassDensityInKilogramPerCubicMeter);
                    c.InletNozzleEntrainedHCFormated = Math.Round(c.InletNozzleEntrainedHC.Value * 100, 3);
                }

                if (IsValidNumber(c.WaterMassDensity) && IsValidNumber(c.WaterViscosity) && IsValidNumber(c.WaterSurfaceTension) && IsValidNumber(c.Qw))
                {
                    c.InletNozzleEntrainedWater = UseOlgaCorrelationToCalculatePercentageLiquidEntrained(inletNozzleInsideDiameterInMeter, c.WaterMassDensityInKilogramPerCubicMeter, c.WaterViscosityInKilogramPerMeterSecond, c.WaterSurfaceTensionInNewtonPerMeter, c.QwInCubicMeterPerSecond, c.AiInSquareMeter, c.QvInCubicMeterPerSecond, c.VaporMassDensityInKilogramPerCubicMeter);
                    c.InletNozzleEntrainedWaterFormated = Math.Round(c.InletNozzleEntrainedWater.Value * 100, 3);
                }
            }
        }

        public static double UseOlgaCorrelationToCalculatePercentageLiquidEntrained(double inletNozzleInsideDiameterInMeter, double massDensityInKilogramPerCubicMeter, double viscosityInKilogramPerMeterSecond, double surfaceTensionInNewtonPerMeter, double QInCubicMeterPerSecond, double AiInSquareMeter, double QvInCubicMeterPerSecond, double PvInKilogramPerCubicMeter)
        {
            double VslfcInFeetPerSecond = CalculateSlipVelocityInFeetPerSecond(inletNozzleInsideDiameterInMeter, massDensityInKilogramPerCubicMeter, viscosityInKilogramPerMeterSecond, surfaceTensionInNewtonPerMeter);
            double vInMeterPerSecond = CalculateVelocity(QInCubicMeterPerSecond, AiInSquareMeter);
            double vInFeetPerSecond = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(vInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);
            if (vInFeetPerSecond <= VslfcInFeetPerSecond)
            {
                return 0;
            }

            double webber = CalculateWebber(surfaceTensionInNewtonPerMeter, QvInCubicMeterPerSecond, PvInKilogramPerCubicMeter, AiInSquareMeter, inletNozzleInsideDiameterInMeter);
            double reynolds = CalculateReynolds(viscosityInKilogramPerMeterSecond, QInCubicMeterPerSecond, massDensityInKilogramPerCubicMeter, AiInSquareMeter, inletNozzleInsideDiameterInMeter, (int)NumberOfInletNozzles.One);

            double X = CalculateX(webber, reynolds);
            double XX = CalculateXX(X);
            double EE = GetEE(XX);

            return EE * (1 - (VslfcInFeetPerSecond * (1 / vInFeetPerSecond)));
        }

        public static double CalculateXX(double X)
        {
            return Math.Log10(X);
        }

        public static double CalculateX(double webber, double reynolds)
        {
            return Math.Pow(webber, 1.25) * Math.Pow(reynolds, 0.25);
        }

        private static double GetEE(double XX)
        {
            if (XX > 6.95) return 1;
            if (XX > 6.7 && XX <= 6.95) return 0.95 + (0.05 * GetEESubFunction(XX, 6.7, 6.95));
            if (XX > 6.54 && XX <= 6.7) return 0.9 + (0.05 * GetEESubFunction(XX, 6.54, 6.7));
            if (XX > 6.32  && XX <= 6.54) return 0.8 + (0.1 * GetEESubFunction(XX, 6.32, 6.54));
            if (XX > 6.16 && XX <= 6.32) return 0.7 + (0.1 * GetEESubFunction(XX, 6.16, 6.32));
            if (XX > 6.03 && XX <= 6.16) return 0.6 + (0.1 * GetEESubFunction(XX, 6.03, 6.16));
            if (XX > 5.89 && XX <= 6.03) return 0.5 + (0.1 * GetEESubFunction(XX, 5.89, 6.03));
            if (XX > 5.79 && XX <= 5.89) return 0.4 + (0.1 * GetEESubFunction(XX, 5.79, 5.89));
            if (XX > 5.67 && XX <= 5.79) return 0.3 + (0.1 * GetEESubFunction(XX, 5.67, 5.79));
            if (XX > 5.51 && XX <= 5.67) return 0.2 + (0.1 * GetEESubFunction(XX, 5.51, 5.67));
            if (XX > 5.33 && XX <= 5.51) return 0.1 + (0.1 * GetEESubFunction(XX, 5.33, 5.51));
            if (XX > 5.06 && XX <= 5.33) return (0.1 * GetEESubFunction(XX, 5.06, 5.33));
            return 0;
        }

        private static double GetEESubFunction(double XX, double lowerEnd, double HigherEnd) 
        { 
            return (XX - lowerEnd)/(HigherEnd - lowerEnd);
        }
        
        public static double CalculateWebber(double surfaceTensionInNewtonPerMeter, double QvInCubicMeterPerSecond, double PvInKilogramPerCubicMeter, double AiInSquareMeter, double diameterInMeter)
        {
            double VgInMeterPerSecond = CalculateVelocity(QvInCubicMeterPerSecond, AiInSquareMeter);
            double PvInPoundPerCubicFeet = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(PvInKilogramPerCubicMeter, (int)MassDensityUnit.KilogramPerCubicMeter, (int)MassDensityUnit.PoundPerCubicFeet, ConversionUnitType.MassDensityUnit);
            return ((Math.Pow(VgInMeterPerSecond, 2) * diameterInMeter * PvInKilogramPerCubicMeter) / (surfaceTensionInNewtonPerMeter)) * (Math.Pow((1 / PvInPoundPerCubicFeet), (1.0 / 3)));
        }

        public static double CalculateSlipVelocityInFeetPerSecond(double inletNozzleInsideDiameterInMeters, double massDensityInKilogramPerCubicMeter, double viscosityInKilogramPerMeterSecond, double surfaceTensionInNewtonPerMeter)
        {
            double diameterInInches = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(inletNozzleInsideDiameterInMeters, (int)LengthUnit.Meter, (int)LengthUnit.Inches, ConversionUnitType.LengthUnit);
            double massDensityInPoundPerCubicFeet = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(massDensityInKilogramPerCubicMeter, (int)MassDensityUnit.KilogramPerCubicMeter, (int)MassDensityUnit.PoundPerCubicFeet, ConversionUnitType.MassDensityUnit);
            double viscosityInCp = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(viscosityInKilogramPerMeterSecond, (int)ViscosityUnit.KilogramPerMeterSecond, (int)ViscosityUnit.Centipoise, ConversionUnitType.ViscosityUnit);
            double surfaceTensionInDynePerCentimeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(surfaceTensionInNewtonPerMeter, (int)SurfaceTensionUnit.NewtonPerMeter, (int)SurfaceTensionUnit.DynePerCentimeter, ConversionUnitType.SurfaceTensionUnit);

            return (1.137 * Math.Pow(10, 7)) / (Math.Pow(diameterInInches, 1.375) * Math.Pow(massDensityInPoundPerCubicFeet, 4.495) * Math.Pow(viscosityInCp, 0.44) * Math.Pow(surfaceTensionInDynePerCentimeter, 0.076));
        }

        #endregion

        #region Process Outputs

        public static double CalculateCompressibilityFactor(double pressureInPascal, double temperatureInFahrenheit, double vaporMolecularWeightInKilogramPerKilogramMol, double vaporMassDensityInKilogramPerCubicMeter) 
        {
            double pressureInPSI = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(pressureInPascal, (int)PressureUnit.Pascal, (int)PressureUnit.PoundPerSquareInch, ConversionUnitType.PressureUnit);
            double molecularWeightInPoundPerPoundMol = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(vaporMolecularWeightInKilogramPerKilogramMol, (int)MolecularWeightUnit.KilogramPerKilogramMol, (int)MolecularWeightUnit.PoundPerPoundMol, ConversionUnitType.MolecularWeightUnit);
            double massDensityInPoundPerCubicFeet = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(vaporMassDensityInKilogramPerCubicMeter, (int)MassDensityUnit.KilogramPerCubicMeter, (int)MassDensityUnit.PoundPerCubicFeet, ConversionUnitType.MassDensityUnit);
            double T1r = temperatureInFahrenheit + 460;
            double R = 10.7316;
            return Math.Round((pressureInPSI * molecularWeightInPoundPerPoundMol) / (R * T1r * massDensityInPoundPerCubicFeet), 3);
        }

        public static void CalculateStandardVolumetricFlowRateInCubicMeterPerSecond(double pressureInPascal, double temperatureInFahrenheit, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem) 
        {
            double pressureInPSI = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(pressureInPascal, (int)PressureUnit.Pascal, (int)PressureUnit.PoundPerSquareInch, ConversionUnitType.PressureUnit);
            double P2InPSI = 14.73;
            double T2InFahrenheit = 60;
            double T1r = temperatureInFahrenheit + 460;
            double T2r = T2InFahrenheit + 460;

            c.StdVInCubicMeterPerSecond = (c.QvInCubicMeterPerSecond * pressureInPSI * T2r) / (c.CompressibilityFactor.Value * P2InPSI * T1r);

            MeasurementUnitBusinessFacade.ConvertStdVToOutputUnit(c, measurementUnitSystem);
        }

        public static double CalculateVaporSpecificGravity(double vaporMolecularWeightInKilogramPerKilogramMol) 
        {
            return Math.Round(vaporMolecularWeightInKilogramPerKilogramMol / 28.96, 3);
        }

        public static void CalculatePercentageOfVaporByVolume(SeparatorProcessDesignCase c) 
        {
            c.PercentageOfVaporByVolume = Math.Round((c.QvInCubicMeterPerSecond / c.QtInCubicMeterPerSecond) * 100 , 3);
        }

        public static double CalculateFroudeNumber(SeparatorProcessDesignCase c, double liquidOutletNozzleInsideDiameterInMeter) 
        {
            double DRFInMeter = liquidOutletNozzleInsideDiameterInMeter; 
            double gInSquareMeterPerSecond = 9.8;

            double massDensity = (c.HCMassDensityInKilogramPerCubicMeter == 0 ? c.WaterMassDensityInKilogramPerCubicMeter : c.HCMassDensityInKilogramPerCubicMeter);

            double froudeNumber = (c.LiquidOutletNozzleVelocityDRFInMeterPerSecond / (Math.Sqrt(DRFInMeter * gInSquareMeterPerSecond))) * (Math.Sqrt(massDensity / (massDensity - c.VaporMassDensityInKilogramPerCubicMeter)));
            return Math.Round(froudeNumber, 3);
        }

        #endregion

        #region General

        private static double CalculateArea(double insideDiameter)
        {
            return (Math.PI / 4) * (Math.Pow(insideDiameter, 2));
        }

        private static double CalculateVelocity(double Q, double A)
        {
            return Q / A;
        }

        public static double CalculateReynolds(double viscosityInKilogramPerMeterSecond, double QInCubicMeterPerSecond, double PInKilogramPerCubicMeter, double AiInSquareMeter, double inletNozzleInsideDiameterInMeter, double numberOfInletNozzle)
        {
            return (PInKilogramPerCubicMeter * (QInCubicMeterPerSecond / (AiInSquareMeter * numberOfInletNozzle)) * inletNozzleInsideDiameterInMeter) / viscosityInKilogramPerMeterSecond;
        }

        #endregion

        #region Separation Efficiency

        public static bool IsValidNumber(double? value)
        {
            if (!value.HasValue)
                return false;
            if (double.IsNaN(value.Value))
                return false;

            return true;
        }

        public static void CalculateSeparationEfficiency(SeparatorProcessDesignCase c, int numberOfInletNozzles, CorrelationType correlation, MeasurementUnitSystem measurementUnitSystem, double inletNozzleInsideDiameterInMeter) 
        {
            double HCInletNozzleEntrained = c.InletNozzleEntrainedHC.HasValue ? c.InletNozzleEntrainedHC.Value : 0;
            double WaterInletNozzleEntrained = c.InletNozzleEntrainedWater.HasValue ? c.InletNozzleEntrainedWater.Value : 0;

            CheckAndCalculateTotalLiquidEntrained(c, measurementUnitSystem, HCInletNozzleEntrained, WaterInletNozzleEntrained);

            CheckAndCalculateDropletSize(c, numberOfInletNozzles, inletNozzleInsideDiameterInMeter);

            CalculateSeparationEfficiencyByCorrelationType(c, correlation, inletNozzleInsideDiameterInMeter);

            CheckAndCalculateProjectedDrumEfficiency(c);

            CheckAndCalculateAssumedLiquidEntrained(c, measurementUnitSystem);
            
            GenerateCharts(c, correlation);
        }

        private static void CheckAndCalculateAssumedLiquidEntrained(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (IsValidNumber(c.HCDropletCutDiameter) && IsValidNumber(c.EfficiencyCase.HCDropletSize) && IsValidNumber(c.Qhc))
            {
                c.EfficiencyCase.HCAssumedLiquidEntrainedInCubicMeterPerSecond = CalculateAssumedLiquidEntrained(c.HCDropletCutDiameterInMeter, c.EfficiencyCase.HCDropletSizeInMeter, c.QhcInCubicMeterPerSecond);
                MeasurementUnitBusinessFacade.ConvertAssumedHCEntrainedToOutputUnit(c.EfficiencyCase, measurementUnitSystem);
            }
            if (IsValidNumber(c.WaterDropletCutDiameter) && IsValidNumber(c.EfficiencyCase.WaterDropletSize) && IsValidNumber(c.Qw))
            {
                c.EfficiencyCase.WaterAssumedLiquidEntrainedInCubicMeterPerSecond = CalculateAssumedLiquidEntrained(c.WaterDropletCutDiameterInMeter, c.EfficiencyCase.WaterDropletSizeInMeter, c.QwInCubicMeterPerSecond);
                MeasurementUnitBusinessFacade.ConvertAssumedWaterEntrainedToOutputUnit(c.EfficiencyCase, measurementUnitSystem);
            }
        }

        private static void CheckAndCalculateProjectedDrumEfficiency(SeparatorProcessDesignCase c)
        {
            if (IsValidNumber(c.HCDropletCutDiameter) && IsValidNumber(c.EfficiencyCase.HCDropletSize))
            {
                c.EfficiencyCase.HCProjectedDrumEfficiency = CalculateProjectedDrumEfficiency(c.HCDropletCutDiameterInMeter, c.EfficiencyCase.HCDropletSizeInMeter);
                c.EfficiencyCase.HCProjectedDrumEfficiency = Math.Round(c.EfficiencyCase.HCProjectedDrumEfficiency.Value, 3);
            }

            if (IsValidNumber(c.WaterDropletCutDiameter) && IsValidNumber(c.EfficiencyCase.WaterDropletSize))
            {
                c.EfficiencyCase.WaterProjectedDrumEfficiency = CalculateProjectedDrumEfficiency(c.WaterDropletCutDiameterInMeter, c.EfficiencyCase.WaterDropletSizeInMeter);
                c.EfficiencyCase.WaterProjectedDrumEfficiency = Math.Round(c.EfficiencyCase.WaterProjectedDrumEfficiency.Value, 3);
            }
        }

        private static void CalculateSeparationEfficiencyByCorrelationType(SeparatorProcessDesignCase c, CorrelationType correlation, double inletNozzleInsideDiameterInMeter)
        {
            if (correlation == CorrelationType.IshiiKataoka)
            {
                CalculateSeparationEfficiencyUsingIshiiKataokaCorrelation(c.EfficiencyCase);
            }
            else if (correlation == CorrelationType.TattersonDallmanHanratty)
            {
                CalculateSeparationEfficiencyUsingTattersonDallmanHarranttyCorrelation(c, inletNozzleInsideDiameterInMeter);
            }
        }

        private static void CheckAndCalculateDropletSize(SeparatorProcessDesignCase c, int numberOfInletNozzles, double inletNozzleInsideDiameterInMeter)
        {
            if (IsValidNumber(c.HCSurfaceTension) && IsValidNumber(c.HCMassDensity) && IsValidNumber(c.HCViscosity) && IsValidNumber(c.Qhc) && IsValidNumber(c.AiInSquareMeter) && IsValidNumber(inletNozzleInsideDiameterInMeter) && IsValidNumber(numberOfInletNozzles) && IsValidNumber(c.VaporMassDensity) && IsValidNumber(c.Qv) && IsValidNumber(c.VaporViscosity))
            {
                c.EfficiencyCase.HCDropletSizeInMeter = CalculateDropletSize(c.HCSurfaceTensionInNewtonPerMeter, c.HCMassDensityInKilogramPerCubicMeter, c.HCViscosityInKilogramPerMeterSecond, c.QhcInCubicMeterPerSecond, c.AiInSquareMeter, inletNozzleInsideDiameterInMeter, numberOfInletNozzles, c.VaporMassDensityInKilogramPerCubicMeter, c.QvInCubicMeterPerSecond, c.VaporViscosityInKilogramPerMeterSecond);
                MeasurementUnitBusinessFacade.ConvertHCDropletSizeToOutputUnit(c.EfficiencyCase);
            }
            if (IsValidNumber(c.WaterSurfaceTension) && IsValidNumber(c.WaterMassDensity) && IsValidNumber(c.WaterViscosity) && IsValidNumber(c.Qw) && IsValidNumber(c.AiInSquareMeter) && IsValidNumber(inletNozzleInsideDiameterInMeter) && IsValidNumber(numberOfInletNozzles) && IsValidNumber(c.VaporMassDensity) && IsValidNumber(c.Qv) && IsValidNumber(c.VaporViscosity))
            {
                c.EfficiencyCase.WaterDropletSizeInMeter = CalculateDropletSize(c.WaterSurfaceTensionInNewtonPerMeter, c.WaterMassDensityInKilogramPerCubicMeter, c.WaterViscosityInKilogramPerMeterSecond, c.QwInCubicMeterPerSecond, c.AiInSquareMeter, inletNozzleInsideDiameterInMeter, numberOfInletNozzles, c.VaporMassDensityInKilogramPerCubicMeter, c.QvInCubicMeterPerSecond, c.VaporViscosityInKilogramPerMeterSecond);
                MeasurementUnitBusinessFacade.ConvertWaterDropletSizeToOutputUnit(c.EfficiencyCase);
            }
        }

        private static void CheckAndCalculateTotalLiquidEntrained(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem, double HCInletNozzleEntrained, double WaterInletNozzleEntrained)
        {
            if (IsValidNumber(HCInletNozzleEntrained) && IsValidNumber(c.HCMassFlowRate))
            {
                c.EfficiencyCase.HCTotalLiquidEntrainedInKilogramPerSecond = CalculateTotalLiquidEntrained(HCInletNozzleEntrained, c.HCMassFlowRateInKilogramPerSecond);
                MeasurementUnitBusinessFacade.ConvertTotalLiquidEntrainedToOutputUnit(c.EfficiencyCase, measurementUnitSystem);
            }

            if (IsValidNumber(WaterInletNozzleEntrained) && IsValidNumber(c.WaterMassFlowRate))
            {
                c.EfficiencyCase.WaterTotalLiquidEntrainedInKilogramPerSecond = CalculateTotalLiquidEntrained(WaterInletNozzleEntrained, c.WaterMassFlowRateInKilogramPerSecond);
                MeasurementUnitBusinessFacade.ConvertTotalLiquidEntrainedToOutputUnit(c.EfficiencyCase, measurementUnitSystem);
            }
        }

        private static void GenerateCharts(SeparatorProcessDesignCase c, CorrelationType correlation)
        {
            //c.EfficiencyCase.HCDropCumulativeDristributionChart = chartModuleBF.DropCumulativeDistributionChart(0.00639, CorrelationType.IshiiKataoka);
            //c.EfficiencyCase.HCDropletDensityDistributionChart = chartModuleBF.DropletDensityDistributionChart(0.00639, CorrelationType.IshiiKataoka);
            //c.EfficiencyCase.WaterDropCumulativeDristributionChart = chartModuleBF.DropCumulativeDistributionChart(0.00886, CorrelationType.IshiiKataoka);
            //c.EfficiencyCase.WaterDropletDensityDistributionChart = chartModuleBF.DropletDensityDistributionChart(0.00886, CorrelationType.IshiiKataoka);


            if (correlation == CorrelationType.IshiiKataoka)
            {
                if (IsValidNumber(c.EfficiencyCase.HCDropletSize) && c.EfficiencyCase.HCDropletSize != 0)
                {
                    c.EfficiencyCase.HCDropCumulativeDistributionChart = ChartModuleBusinessFacade.DropCumulativeDistributionChartIshiiKataoka(c.EfficiencyCase.HCDropletSize);
                    c.EfficiencyCase.HCDropletDensityDistributionChart = ChartModuleBusinessFacade.DropletDensityDistributionChartIshiiKataoka(c.EfficiencyCase.HCDropletSize);
                }
                if (IsValidNumber(c.EfficiencyCase.WaterDropletSize) && c.EfficiencyCase.WaterDropletSize != 0)
                {
                    c.EfficiencyCase.WaterDropCumulativeDistributionChart = ChartModuleBusinessFacade.DropCumulativeDistributionChartIshiiKataoka(c.EfficiencyCase.WaterDropletSize);
                    c.EfficiencyCase.WaterDropletDensityDistributionChart = ChartModuleBusinessFacade.DropletDensityDistributionChartIshiiKataoka(c.EfficiencyCase.WaterDropletSize);
                }
            }
            else
            {
                if (IsValidNumber(c.EfficiencyCase.WaterDropletSize) && IsValidNumber(c.EfficiencyCase.HCDropletSize) && c.EfficiencyCase.WaterDropletSize != 0 && IsValidNumber(c.EfficiencyCase.HCMedInMeter) && IsValidNumber(c.EfficiencyCase.WaterMedInMeter))
                {
                    c.EfficiencyCase.HCDropCumulativeDistributionChart = ChartModuleBusinessFacade.DropCumulativeDistributionChartTattersonDallmanHanratty(c.EfficiencyCase.HCMax, c.EfficiencyCase.HCMed);
                    c.EfficiencyCase.WaterDropCumulativeDistributionChart = ChartModuleBusinessFacade.DropCumulativeDistributionChartTattersonDallmanHanratty(c.EfficiencyCase.WaterMax, c.EfficiencyCase.WaterMed);

                    c.EfficiencyCase.HCDropletDensityDistributionChart = null;
                    c.EfficiencyCase.WaterDropletDensityDistributionChart = null;
                }
            }

            
        }

       private static void CalculateSeparationEfficiencyUsingTattersonDallmanHarranttyCorrelation(SeparatorProcessDesignCase c, double inletNozzleInsideDiameterInMeter)
        {
            c.EfficiencyCase.HCMean = null;
            c.EfficiencyCase.WaterMean = null;

            if (IsValidNumber(c.HCSurfaceTension) && IsValidNumber(c.Qv) && IsValidNumber(c.AiInSquareMeter) && IsValidNumber(c.VaporMassDensity) && IsValidNumber(inletNozzleInsideDiameterInMeter) && IsValidNumber(c.VaporViscosity))
            {
                c.EfficiencyCase.HCMedInMeter = CalculateMedUsingTattersonDallmanHanrattyCorrelation(c.HCSurfaceTensionInNewtonPerMeter, c.QvInCubicMeterPerSecond, c.AiInSquareMeter, c.VaporMassDensityInKilogramPerCubicMeter, inletNozzleInsideDiameterInMeter, c.VaporViscosityInKilogramPerMeterSecond);
                MeasurementUnitBusinessFacade.ConvertMedToOutputUnit(c.EfficiencyCase);
            }
            if (IsValidNumber(c.WaterSurfaceTension) && IsValidNumber(c.Qv) && IsValidNumber(c.AiInSquareMeter) && IsValidNumber(c.VaporMassDensity) && IsValidNumber(inletNozzleInsideDiameterInMeter) && IsValidNumber(c.VaporViscosity))
            {
                c.EfficiencyCase.WaterMedInMeter = CalculateMedUsingTattersonDallmanHanrattyCorrelation(c.WaterSurfaceTensionInNewtonPerMeter, c.QvInCubicMeterPerSecond, c.AiInSquareMeter, c.VaporMassDensityInKilogramPerCubicMeter, inletNozzleInsideDiameterInMeter, c.VaporViscosityInKilogramPerMeterSecond);
                MeasurementUnitBusinessFacade.ConvertMedToOutputUnit(c.EfficiencyCase);
            }

            if (IsValidNumber(c.EfficiencyCase.HCMed))
            {
                c.EfficiencyCase.HCMaxInMeter = CalculateMaxUsingTattersonDallmanHanrattyCorrelation(c.EfficiencyCase.HCMedInMeter);
                MeasurementUnitBusinessFacade.ConvertMaxToOutputUnit(c.EfficiencyCase);
            }
            if (IsValidNumber(c.EfficiencyCase.WaterMed))
            {
                c.EfficiencyCase.WaterMaxInMeter = CalculateMaxUsingTattersonDallmanHanrattyCorrelation(c.EfficiencyCase.WaterMedInMeter);
                MeasurementUnitBusinessFacade.ConvertMaxToOutputUnit(c.EfficiencyCase);
            }
            if (IsValidNumber(c.EfficiencyCase.HCMed) && IsValidNumber(c.EfficiencyCase.HCMax))
            {
                c.EfficiencyCase.HCSauterInMeter = CalculateSauterUsingTattersonDallmanHanrattyCorrelation(c.EfficiencyCase.HCMaxInMeter, c.EfficiencyCase.HCMedInMeter);
                MeasurementUnitBusinessFacade.ConvertSauterToOutputUnit(c.EfficiencyCase);
            }
            if (IsValidNumber(c.EfficiencyCase.WaterMed) && IsValidNumber(c.EfficiencyCase.WaterMax))
            {
                c.EfficiencyCase.WaterSauterInMeter = CalculateSauterUsingTattersonDallmanHanrattyCorrelation(c.EfficiencyCase.WaterMaxInMeter, c.EfficiencyCase.WaterMedInMeter);
                MeasurementUnitBusinessFacade.ConvertSauterToOutputUnit(c.EfficiencyCase);
            }
        }

        private static void CalculateSeparationEfficiencyUsingIshiiKataokaCorrelation(SeparatorEfficiencyCase g)
        {
            if (IsValidNumber(g.HCDropletSize))
            {
                g.HCSauterInMeter = CalculateSauterUsingIshiiKataokaCorrelation(g.HCDropletSizeInMeter);
                g.HCMeanInMeter = CalculateMeanUsingIshiiKataokaCorrelation(g.HCDropletSizeInMeter);
                g.HCMedInMeter = CalculateMedUsingIshiiKataokaCorrelation(g.HCDropletSizeInMeter);
                MeasurementUnitBusinessFacade.ConvertIshiiKataokaCorrelationToOutputUnit(g);
            }
            if (IsValidNumber(g.WaterDropletSize))
            {
                g.WaterSauterInMeter = CalculateSauterUsingIshiiKataokaCorrelation(g.WaterDropletSizeInMeter);
                g.WaterMedInMeter = CalculateMedUsingIshiiKataokaCorrelation(g.WaterDropletSizeInMeter);
                g.WaterMeanInMeter = CalculateMeanUsingIshiiKataokaCorrelation(g.WaterDropletSizeInMeter);
                MeasurementUnitBusinessFacade.ConvertIshiiKataokaCorrelationToOutputUnit(g);
            }

            g.HCMax = null;
            g.WaterMax = null;
        }

        public static double CalculateTotalLiquidEntrained(double inletNozzleLiquidEntrained, double massFlowRateInKilogramPerSecond)
        {
            return inletNozzleLiquidEntrained * massFlowRateInKilogramPerSecond;
        }

        public static double CalculateDropletSize(double surfaceTensionInNewtonPerMeter, double densityInKilogramPerCubicMeter, double viscosityInKilogramPerMeterSecond, double QInCubicMeterPerSecond, double AiInSquareMeter, double inletNozzleInsideDiameterInMeter, double numberOfInletNozzle, double vaporMassDensityInKilogramPerCubicMeter, double vaporQInCubicMeterPerSecond, double vaporViscosityInKilogramPerMeterSecond)
        {
            double reynolds = CalculateReynolds(viscosityInKilogramPerMeterSecond, QInCubicMeterPerSecond, densityInKilogramPerCubicMeter, AiInSquareMeter, inletNozzleInsideDiameterInMeter, numberOfInletNozzle);
            
            double reynoldsPow = (reynolds != 0) ? Math.Pow(reynolds, -1.0 / 6) : 0;


            return 0.088 *
                (surfaceTensionInNewtonPerMeter / (vaporMassDensityInKilogramPerCubicMeter * Math.Pow(vaporQInCubicMeterPerSecond / (AiInSquareMeter * numberOfInletNozzle), 2))) *
                 reynoldsPow *
                Math.Pow(vaporMassDensityInKilogramPerCubicMeter * (vaporQInCubicMeterPerSecond / (AiInSquareMeter * numberOfInletNozzle)) * (inletNozzleInsideDiameterInMeter / vaporViscosityInKilogramPerMeterSecond), 2.0 / 3) *
                Math.Pow(vaporMassDensityInKilogramPerCubicMeter / densityInKilogramPerCubicMeter, -1.0 / 3) *
                Math.Pow(vaporViscosityInKilogramPerMeterSecond / viscosityInKilogramPerMeterSecond, 2.0 / 3);

        }

        public static double GetDensityfnIshiiKataoka(double x, double maxDropletSize)
        {
           return (0.884 / Math.Sqrt(Math.PI)) * 
               Math.Pow(Math.E, -0.781 * Math.Pow(Math.Log(2.13 * (x/(maxDropletSize - x))),2)) * 
               ((-1.0 * maxDropletSize)/((x - maxDropletSize) * x));
        }

        public static double CalculateSauterUsingIshiiKataokaCorrelation(double maxDropletSize)
        {

            double result = Integrate.OnClosedInterval(x => GetDensityfnIshiiKataoka(x, maxDropletSize), 0, maxDropletSize) /
                Integrate.OnClosedInterval(x => GetDensityfnIshiiKataoka(x, maxDropletSize) / x, 0, maxDropletSize);

            return result;

        }

        public static double CalculateMeanUsingIshiiKataokaCorrelation(double maxDropletSize)
        {

            double result = Integrate.OnClosedInterval(x => x * GetDensityfnIshiiKataoka(x, maxDropletSize), 0, maxDropletSize);

            return result;
        }

        public static double GetDropIshiiKataoka(double x, double maxDropletSize)
        {
            return Math.Pow(10, -1.0 * 0.05 * x) * maxDropletSize * 1.001;
        }

        public static double GetDropTattersonDallmanHanratty(double x, double maxDropletSize)
        {
            return Math.Pow(10, -1.0 * 0.05 * x) * maxDropletSize * 1.001;
        }

        private static double GetUpperLimitDistribution(double x, double maxDropletSize)
        {
            return Math.Log(2.13 * (x / (maxDropletSize - x)));
        }

        public static double CalculateMedUsingIshiiKataokaCorrelation(double maxDropletSize)
        {
            Dictionary<int, double> densityFnArray = new Dictionary<int,double>();

            for (int i = 0; i <= 50; i++)
            {
                densityFnArray.Add(i, GetDensityfnIshiiKataoka(GetDropIshiiKataoka(i, maxDropletSize),maxDropletSize));
            }

            double maxDensityValue = densityFnArray.Values.Max();
            int maxDensityIndex = 0;
            foreach (var item in densityFnArray)
            {
                if (item.Value == maxDensityValue)
                    maxDensityIndex = item.Key;
            }

            double maxDrop = GetDropIshiiKataoka(maxDensityIndex, maxDropletSize);

            double ymean = GetUpperLimitDistribution(maxDrop, maxDropletSize);

            double result = (Math.Pow(Math.E, ymean) * maxDropletSize) / (2.13 + Math.Pow(Math.E, ymean));

            return result;
            
        }

        private static double GetReg(double velocity, double vaporDensityInKilogramPerCubicMeter, double inletNozzleInsideDiameterInMeter, double vaporViscosityInKilogramPerMeterSecond)
        {
            return (velocity * vaporDensityInKilogramPerCubicMeter * inletNozzleInsideDiameterInMeter) / vaporViscosityInKilogramPerMeterSecond;
        }

        private static double GetFs(double reg)
        {
            return 0.046 / Math.Pow(reg, 0.2);
        }

        public static double CalculateMedUsingTattersonDallmanHanrattyCorrelation(double surfaceTensionInNewtonPerMeter, double vaporQInCubicMeterPerSecond, double AiInSquareMeter, double vaporDensityInKilogramPerCubicMeter, double inletNozzleInsideDiameterInMeter, double vaporViscosityInKilogramPerMeterSecond)
        {

            double velocity = CalculateVelocity(vaporQInCubicMeterPerSecond, AiInSquareMeter);

            double reg = GetReg(velocity, vaporDensityInKilogramPerCubicMeter, inletNozzleInsideDiameterInMeter, vaporViscosityInKilogramPerMeterSecond);

            double fs = GetFs(reg);

            double result = (0.016 * inletNozzleInsideDiameterInMeter) *
                Math.Sqrt((2.0 * surfaceTensionInNewtonPerMeter) / (vaporDensityInKilogramPerCubicMeter * Math.Pow(velocity, 2) * fs * inletNozzleInsideDiameterInMeter));

            return result;

        }

        public static double CalculateMaxUsingTattersonDallmanHanrattyCorrelation(double medInMeter)
        {
            return 2.9 * medInMeter;
        }

        public static double GetDensityfnTattersonDallmanHanratty(double x, double maxtdh, double medtdh)
        {
            return ((0.72 * maxtdh) / (Math.Sqrt(Math.PI) * x * (maxtdh - x))) *
                Math.Exp((-1.0 * Math.Pow(0.72, 2)) * Math.Pow(Math.Log(x/(maxtdh - x)) - Math.Log(medtdh/(maxtdh - medtdh)), 2));
        }

        public static double CalculateSauterUsingTattersonDallmanHanrattyCorrelation(double maxtdh, double medtdh)
        {
            double result = Integrate.OnClosedInterval(x => GetDensityfnTattersonDallmanHanratty(x, maxtdh, medtdh), 0, maxtdh) /
                Integrate.OnClosedInterval(x => GetDensityfnTattersonDallmanHanratty(x, maxtdh, medtdh) / x, 0, maxtdh);

            return result;
        }

        public static double CalculateProjectedDrumEfficiency(double smallestDropletDiamenterInMeter, double maxDropletSize)
        {
            double cwik = Integrate.OnClosedInterval(x => GetDensityfnIshiiKataoka(x, maxDropletSize), 0, smallestDropletDiamenterInMeter);

            double result = 1 - cwik;

            return result * 100;
        }

        public static double CalculateAssumedLiquidEntrained(double smallestDropletDiamenterInMeter, double maxDropletSize, double QinCubicMeterPerSecond)
        {
            double cw = 0.0;

            if (smallestDropletDiamenterInMeter >= maxDropletSize)
                cw = 1.0;
            else
            {
                cw = Integrate.OnClosedInterval(x => GetDensityfnIshiiKataoka(x, maxDropletSize), 0, smallestDropletDiamenterInMeter);
            }

            return cw * QinCubicMeterPerSecond;
        }

        #region Smallest Droplet Diameter (uses Newton-Raphson method)

        private static double MaterialMassDensityInKilogramPerCubicMeter { get; set; } //HC or Water
        private static double VaporMassDensityInKilogramPerCubicMeter { get; set; }
        private static double VaporViscosityInKilogramPerMeterSecond { get; set; }

        public static void CalculateHCDropletCutDiameter(double HCInitialGuessForDropletSizeInMeter, double drumInsideDiameterInMeters, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            try {
                if (IsValidNumber(c.HCMassDensity))
                {
                    c.HCDropletCutDiameterBadEstimateValue = false;
                    c.HCDropletCutDiameterInMeter = CalculateSmallestDropletDiameter(HCInitialGuessForDropletSizeInMeter, drumInsideDiameterInMeters, c.HCMassDensityInKilogramPerCubicMeter, c, measurementUnitSystem);
                    MeasurementUnitBusinessFacade.ConvertHCSmallestDropletDiameterToOutputUnits(c);
                }
            }
            catch (Exception)
            {
                c.HCDropletCutDiameterBadEstimateValue = true; ;
            }
        }

        public static void CalculateWaterDropletCutDiameter(double WaterInitialGuessForDropletSizeInMeter, double drumInsideDiameterInMeters, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            try {
                if (IsValidNumber(c.WaterMassDensity))
                {
                    c.WaterDropletCutDiameterBadEstimateValue = false;
                    c.WaterDropletCutDiameterInMeter = CalculateSmallestDropletDiameter(WaterInitialGuessForDropletSizeInMeter, drumInsideDiameterInMeters, c.WaterMassDensityInKilogramPerCubicMeter, c, measurementUnitSystem);
                    MeasurementUnitBusinessFacade.ConvertWaterSmallestDropletDiameterToOutputUnits(c);
                }
            }
            catch (Exception)
            {
                c.WaterDropletCutDiameterBadEstimateValue = true;
            }
        }

        public static double CalculateSmallestDropletDiameter(double initialGuessForDropletSize, double drumInsideDiameterInMeters, double materialMassDensityInKilogramPerCubicMeter, SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if(c.QvInCubicMeterPerSecond == 0)
                c.QvInCubicMeterPerSecond = c.VaporMassFlowRateInKilogramPerSecond/c.VaporMassDensityInKilogramPerCubicMeter;

            if (c.AtInSquareMeter == 0)
                c.AtInSquareMeter = CalculateArea(drumInsideDiameterInMeters);

            c.UactInMeterPerSecond = c.QvInCubicMeterPerSecond / c.AtInSquareMeter;
            MeasurementUnitBusinessFacade.ConvertHUactToOutputUnits(c, measurementUnitSystem);

            double dp = initialGuessForDropletSize;

            MaterialMassDensityInKilogramPerCubicMeter = materialMassDensityInKilogramPerCubicMeter;
            VaporMassDensityInKilogramPerCubicMeter = c.VaporMassDensityInKilogramPerCubicMeter;
            VaporViscosityInKilogramPerMeterSecond = c.VaporViscosityInKilogramPerMeterSecond;

            double root = NewtonRapExternal(dp, c.UactInMeterPerSecond);
            
            if (root < 0 || double.IsNaN(root) || double.IsInfinity(root))
            {
                throw new Exception(ConstantsFile.BADESTIMATEFORDROPLETSIZE);
            }
            return root;
        }

        #region External Loop

        private static double NewtonRapExternal(double dp, double Uact)
        {
            const double TOLERANCE = 1e-5;
            double B = 1;
            double error = 5;
            double x0 = dp;
            double u = Uact;
            int numberOfIterations = 0;

            double x1 = .0, dx;
            while (error > TOLERANCE)
            {
                numberOfIterations++;
                x1 = x0 - Fextern(x0, u) / DFextern(x0, u);
                error = Math.Abs(x1 - x0);

                dx = x1 - x0;
                x1 = x0 + B * dx;
                x0 = x1;

                if (numberOfIterations == 1000)
                {
                    B = .5;
                    x0 = dp;
                }
                else if (numberOfIterations == 2500)
                {
                    B = .3;
                    x0 = dp;
                }
                else if (numberOfIterations > 5000)
                {
                    throw new BusinessException(ConstantsFile.BADESTIMATEFORDROPLETSIZE);
                }
            }
            return x1;
        }

        public static double Fextern(double x, double y)
        {
            double dp = x;
            double u = y;

            return NewtonRapInternal(dp, u) - u;
        }

        private static double DFextern(double x, double d)
        {
            const double delta = 1e-8;
            double za = (Fextern(x + delta, d) - Fextern(x - delta, d)) / (2 * delta);

            double z = za == 0 ? 1e-8 : za;
            return z;
        }

        #endregion

        #region Internal Loop

        private static double NewtonRapInternal(double dp, double u)
        {
            const double TOLERANCE = 1e-6;
            double B = 1;
            double error = 5;
            double x0 = u;
            double d = dp;
            int numberOfIterations = 0;

            double x1 = .0, dx;
            while (error > TOLERANCE)
            {
                numberOfIterations++;
                x1 = x0 - Fintern(x0, d) / DFintern(x0, d);
                error = Math.Abs(x1 - x0);

                dx = x1 - x0;
                x1 = x0 + B * dx;
                x0 = x1;

                if (numberOfIterations == 250 || (x0 > 1e90 && numberOfIterations < 250))
                {
                    B = .5;
                    x0 = dp;
                }
                else if (numberOfIterations == 500 || (x0 > 1e90 && numberOfIterations > 500 && numberOfIterations < 1000))
                {
                    B = .3;
                    x0 = dp;
                }
                else if (numberOfIterations == 1000)
                {
                    throw new BusinessException(ConstantsFile.BADESTIMATEFORDROPLETSIZE);
                }
            }
            return x1;
        }

        public static double Fintern(double x, double y)
        {
            double dp = y;
            double V = Math.PI * ((Math.Pow(dp, 3.0)) / 6);
            double A = Math.PI * ((Math.Pow(dp, 2.0)) / 4);

            double rhohc = MaterialMassDensityInKilogramPerCubicMeter;
            double rhov = VaporMassDensityInKilogramPerCubicMeter;
            double miv = VaporViscosityInKilogramPerMeterSecond;

            double Re = dp * x * (rhov / miv);

            if (Re == 0)
            {
                Re = 1e-15;
            }
            if (V == 0)
            {
                V = 1e-20;
            }
            if (A == 0)
            {
                A = 1e-20;
            }

            double Cd;
            if (Re < 2)
            {
                Cd = 24 / Re;
            }
            else if (Re > 2 && Re < 500)
            {
                Cd = 18.5 / Math.Pow(Re, 0.6);
            }
            else
            {
                Cd = 0.44;
            }

            double Fd = Cd * (Math.Pow(x, 2.0)) * rhov * (A / (2 * V * rhohc));
            double Fb = 9.82 * (rhohc - rhov) / rhohc;

            return Fb - Fd;
        }

        private static double DFintern(double x, double d)
        {
            const double delta = 1e-8;
            double za = (Fintern(x + delta, d) - Fintern(x - delta, d)) / (2 * delta);

            double z = za == 0 ? 1e-8 : za;
            return z;
        }

        #endregion

        #endregion

        #endregion


    }
}
