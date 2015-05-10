using SDTBusiness.Unity;
using SDTDomainModel.Entities;
using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaredFingers.UnitsConversion;

namespace SDTBusiness.Registers
{
    public class MeasurementUnitBusinessFacade : BaseUnity
    {

        public static double? ConvertInputWhenUnitIsChanged(double? value, int unitCodeFrom, int unitCodeTo, ConversionUnitType type)
        {
            SDTConverter UnitConverter = new SDTConverter(); 

            if (!value.HasValue || unitCodeFrom == 0 || unitCodeTo == 0)
                return value;

            switch (type)
            {
                case ConversionUnitType.LengthUnit:
                    return UnitConverter.ConvertLength(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.MassDensityUnit:
                    return UnitConverter.ConvertMassDensity(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.MassFlowRateUnit:
                    return UnitConverter.ConvertMassFlowRate(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.MolecularWeightUnit:
                    return UnitConverter.ConvertMolecularWeight(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.PressureUnit:
                    return UnitConverter.ConvertPressure(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.SurfaceTensionUnit:
                    return UnitConverter.ConvertSurfaceTension(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.TemperatureUnit:
                    return UnitConverter.ConvertTemperature(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.VelocityUnit:
                    return UnitConverter.ConvertVelocity(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.ViscosityUnit:
                    return UnitConverter.ConvertViscosity(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.VolumeFlowRateUnit:
                    return UnitConverter.ConvertVolumeFlowRate(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.WeightUnit:
                    return UnitConverter.ConvertWeight(value.Value, unitCodeFrom, unitCodeTo);
                case ConversionUnitType.MomentumUnit:
                    return UnitConverter.ConvertMomentumUnits(value.Value, unitCodeFrom, unitCodeTo);
            }

            return 0;
        }

        public static double ConvertToMeasurementUnit(double? value, int unitCodeFrom, int unitCodeTo, ConversionUnitType type)
        {
            double? result = ConvertInputWhenUnitIsChanged(value, unitCodeFrom, unitCodeTo, type);

            return ((result.HasValue) ? result.Value : 0);
        }

        #region Inputs

        public static void ConvertCaseInputsToDefaultCalculationUnits(SeparatorProcessDesignCase item)
        {
            item.VaporMassDensityInKilogramPerCubicMeter = ConvertToMeasurementUnit(item.VaporMassDensity, (int)item.VaporMassDensityMeasurementUnit, (int)MassDensityUnit.KilogramPerCubicMeter, ConversionUnitType.MassDensityUnit);
            item.HCMassDensityInKilogramPerCubicMeter = ConvertToMeasurementUnit(item.HCMassDensity, (int)item.HCMassDensityMeasurementUnit, (int)MassDensityUnit.KilogramPerCubicMeter, ConversionUnitType.MassDensityUnit);
            item.WaterMassDensityInKilogramPerCubicMeter = ConvertToMeasurementUnit(item.WaterMassDensity, (int)item.WaterMassDensityMeasurementUnit, (int)MassDensityUnit.KilogramPerCubicMeter, ConversionUnitType.MassDensityUnit);

            item.VaporMassFlowRateInKilogramPerSecond = ConvertToMeasurementUnit(item.VaporMassFlowRate, (int)item.VaporMassFlowRateMeasurementUnit, (int)MassFlowRateUnit.KilogramPerSecond, ConversionUnitType.MassFlowRateUnit);
            item.HCMassFlowRateInKilogramPerSecond = ConvertToMeasurementUnit(item.HCMassFlowRate, (int)item.HCMassFlowRateMeasurementUnit, (int)MassFlowRateUnit.KilogramPerSecond, ConversionUnitType.MassFlowRateUnit);
            item.WaterMassFlowRateInKilogramPerSecond = ConvertToMeasurementUnit(item.WaterMassFlowRate, (int)item.WaterMassFlowRateMeasurementUnit, (int)MassFlowRateUnit.KilogramPerSecond, ConversionUnitType.MassFlowRateUnit);

            item.VaporViscosityInKilogramPerMeterSecond = ConvertToMeasurementUnit(item.VaporViscosity, (int)item.VaporViscosityMeasurementUnit, (int)ViscosityUnit.KilogramPerMeterSecond, ConversionUnitType.ViscosityUnit);
            item.HCViscosityInKilogramPerMeterSecond = ConvertToMeasurementUnit(item.HCViscosity, (int)item.HCViscosityMeasurementUnit, (int)ViscosityUnit.KilogramPerMeterSecond, ConversionUnitType.ViscosityUnit);
            item.WaterViscosityInKilogramPerMeterSecond = ConvertToMeasurementUnit(item.WaterViscosity, (int)item.WaterViscosityMeasurementUnit, (int)ViscosityUnit.KilogramPerMeterSecond, ConversionUnitType.ViscosityUnit);

            item.VaporMolecularWeightInKilogramPerKilogramMol = ConvertToMeasurementUnit(item.VaporMolecularWeight, (int)item.VaporMolecularWeightMeasurementUnit, (int)MolecularWeightUnit.KilogramPerKilogramMol, ConversionUnitType.MolecularWeightUnit);
            item.HCSurfaceTensionInNewtonPerMeter = ConvertToMeasurementUnit(item.HCSurfaceTension, (int)item.HCSurfaceTensionMeasurementUnit, (int)SurfaceTensionUnit.NewtonPerMeter, ConversionUnitType.SurfaceTensionUnit);
            item.WaterSurfaceTensionInNewtonPerMeter = ConvertToMeasurementUnit(item.WaterSurfaceTension, (int)item.WaterSurfaceTensionMeasurementUnit, (int)SurfaceTensionUnit.NewtonPerMeter, ConversionUnitType.SurfaceTensionUnit);
        }
       
        #endregion


        #region Outputs

        internal static void ConvertVaporOutletMomentumVariablesToOutputUnits(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                c.VaporOutletNozzleCalculatedMomentumMeasurementUnit = MomentumUnit.PoundPerFeetSquaredSecond;
                c.VaporOutletNozzleCalculatedMomentum = ConvertToMeasurementUnit(c.MoutInKilogramPerMeterSquareSecond, (int)MomentumUnit.KilogramPerMeterSquaredSecond, (int)MomentumUnit.PoundPerFeetSquaredSecond, ConversionUnitType.MomentumUnit);

                c.VoutMeasurementUnit = VelocityUnit.FeetPerSecond;
                c.Vout = ConvertToMeasurementUnit(c.VoutInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                c.VaporOutletNozzleCalculatedMomentumMeasurementUnit = MomentumUnit.KilogramPerMeterSquaredSecond;
                c.VaporOutletNozzleCalculatedMomentum = c.MoutInKilogramPerMeterSquareSecond;

                c.VoutMeasurementUnit = VelocityUnit.MeterPerSecond;
                c.Vout = c.VoutInMeterPerSecond;
            }

            c.VaporOutletNozzleCalculatedMomentum = Math.Round(c.VaporOutletNozzleCalculatedMomentum.Value, 3);
            c.Vout = Math.Round(c.Vout.Value, 3);
        }

        internal static void ConvertInletMomentumVariablesToOutputUnits(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                c.InletNozzleCalculatedMomentumMeasurementUnit = MomentumUnit.PoundPerFeetSquaredSecond;
                c.InletNozzleCalculatedMomentum = ConvertToMeasurementUnit(c.MiInKilogramPerMeterSquareSecond, (int)MomentumUnit.KilogramPerMeterSquaredSecond, (int)MomentumUnit.PoundPerFeetSquaredSecond, ConversionUnitType.MomentumUnit);

                c.PmMeasurementUnit = MassDensityUnit.PoundPerCubicFeet;
                c.Pm = ConvertToMeasurementUnit(c.PmInKilogramPerCubicMeter, (int)MassDensityUnit.KilogramPerCubicMeter, (int)MassDensityUnit.PoundPerCubicFeet, ConversionUnitType.MassDensityUnit);
                
                c.ViMeasurementUnit = VelocityUnit.FeetPerSecond;
                c.Vi = ConvertToMeasurementUnit(c.ViInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                c.InletNozzleCalculatedMomentumMeasurementUnit = MomentumUnit.KilogramPerMeterSquaredSecond;
                c.InletNozzleCalculatedMomentum = c.MiInKilogramPerMeterSquareSecond;

                c.PmMeasurementUnit = MassDensityUnit.KilogramPerCubicMeter;
                c.Pm = c.PmInKilogramPerCubicMeter;

                c.ViMeasurementUnit = VelocityUnit.MeterPerSecond;
                c.Vi = c.ViInMeterPerSecond;
            }

            c.InletNozzleCalculatedMomentum = Math.Round(c.InletNozzleCalculatedMomentum.Value, 3);
            c.Pm = Math.Round(c.Pm.Value, 3);
            c.Vi = Math.Round(c.Vi.Value, 3);
        }

        internal static void ConvertLiquidOutletOutputsToOutputUnits(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                c.LiquidOutletNozzleVelocityDRFMeasuremetUnit = VelocityUnit.FeetPerSecond;
                c.LiquidOutletNozzleVelocityDRF = ConvertToMeasurementUnit(c.LiquidOutletNozzleVelocityDRFInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);

                c.LiquidOutletNozzleCalculatedDRFMeasurementUnit = LengthUnit.Inches;
                c.LiquidOutletNozzleCalculatedDRF = ConvertToMeasurementUnit(c.LiquidOutletNozzleCalculatedDRFInMilimeter, (int)LengthUnit.Milimeter, (int)LengthUnit.Inches, ConversionUnitType.LengthUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                c.LiquidOutletNozzleVelocityDRFMeasuremetUnit = VelocityUnit.MeterPerSecond;
                c.LiquidOutletNozzleVelocityDRF = c.LiquidOutletNozzleVelocityDRFInMeterPerSecond;

                c.LiquidOutletNozzleCalculatedDRFMeasurementUnit = LengthUnit.Milimeter;
                c.LiquidOutletNozzleCalculatedDRF = c.LiquidOutletNozzleCalculatedDRFInMilimeter;
            }

            c.LiquidOutletNozzleVelocityDRF = Math.Round(c.LiquidOutletNozzleVelocityDRF.Value, 3);
            c.LiquidOutletNozzleCalculatedDRF = Math.Round(c.LiquidOutletNozzleCalculatedDRF.Value, 3);
        }

        internal static void ConvertKWatervesselsToOutputUnits(SeparatorProcessDesignCase item, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                item.KWaterVesselMeasurementUnit = VelocityUnit.FeetPerSecond;
                item.KWaterVessel = ConvertToMeasurementUnit(item.KWaterVesselInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                item.KWaterVesselMeasurementUnit = VelocityUnit.MeterPerSecond;
                item.KWaterVessel = item.KWaterVesselInMeterPerSecond;
            }

            item.KWaterVessel = Math.Round(item.KWaterVessel.Value, 3);
        }

        internal static void ConvertKHCvesselsToOutputUnits(SeparatorProcessDesignCase item, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                item.KHCVesselMeasurementUnit = VelocityUnit.FeetPerSecond;
                item.KHCVessel = ConvertToMeasurementUnit(item.KHCVesselInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                item.KHCVesselMeasurementUnit = VelocityUnit.MeterPerSecond;
                item.KHCVessel = item.KHCVesselInMeterPerSecond;
            }

            item.KHCVessel = Math.Round(item.KHCVessel.Value, 3);
        }

        internal static void ConvertHCSmallestDropletDiameterToOutputUnits(SeparatorProcessDesignCase item)
        {
            item.HCDropletCutDiameterMeasurementUnit = LengthUnit.Micrometer;
            item.HCDropletCutDiameter = ConvertToMeasurementUnit(item.HCDropletCutDiameterInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            item.HCDropletCutDiameter = Math.Round(item.HCDropletCutDiameter.Value, 3);
        }

        internal static void ConvertWaterSmallestDropletDiameterToOutputUnits(SeparatorProcessDesignCase item)
        {
            item.WaterDropletCutDiameterMeasurementUnit = LengthUnit.Micrometer;
            item.WaterDropletCutDiameter = ConvertToMeasurementUnit(item.WaterDropletCutDiameterInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            item.WaterDropletCutDiameter = Math.Round(item.WaterDropletCutDiameter.Value, 3);
        }

        internal static void ConvertVolumetricFlowRatesToOutputUnits(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                c.QvMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                c.Qv = ConvertToMeasurementUnit(c.QvInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);

                c.QhcMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                c.Qhc = ConvertToMeasurementUnit(c.QhcInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);
                
                c.QwMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                c.Qw = ConvertToMeasurementUnit(c.QwInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);

                c.QltMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                c.Qlt = ConvertToMeasurementUnit(c.QltInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);

                c.QtMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                c.Qt = ConvertToMeasurementUnit(c.QtInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                c.QvMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                c.Qv = c.QvInCubicMeterPerSecond;

                c.QhcMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                c.Qhc = c.QhcInCubicMeterPerSecond;

                c.QwMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                c.Qw = c.QwInCubicMeterPerSecond;

                c.QltMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                c.Qlt = c.QltInCubicMeterPerSecond;

                c.QtMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                c.Qt = c.QtInCubicMeterPerSecond;
            }

            c.Qv = Math.Round(c.Qv.Value, 3);
            c.Qhc = Math.Round(c.Qhc.Value, 3);
            c.Qw = Math.Round(c.Qw.Value, 3);
            c.Qlt = Math.Round(c.Qlt.Value, 3);
            c.Qt = Math.Round(c.Qt.Value, 3);

        }
     
        internal static void ConvertStdVToOutputUnit(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                c.StdVMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                c.StdV = ConvertToMeasurementUnit(c.StdVInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);
             }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                c.StdVMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                c.StdV = c.StdVInCubicMeterPerSecond;
     
            }

            c.StdV = Math.Round(c.StdV.Value, 3);
        }

        internal static void ConvertHUactToOutputUnits(SeparatorProcessDesignCase c, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                c.UactMeasurementUnit = VelocityUnit.FeetPerSecond;
                c.Uact = ConvertToMeasurementUnit(c.UactInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond, ConversionUnitType.VelocityUnit);
             }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                c.UactMeasurementUnit = VelocityUnit.MeterPerSecond;
                c.Uact = c.UactInMeterPerSecond;
     
            }

            c.Uact = Math.Round(c.Uact.Value, 3);
        }

        //public static void ConvertSeparationEfficiencyToOutputUnits(SeparatorEfficiencyCase separatorEfficiencyCase, MeasurementUnitSystem measurementUnitSystem)
        //{
        //    ConvertTotalLiquidEntrainedToOutputUnit(separatorEfficiencyCase, measurementUnitSystem);
        //    ConvertDropletSizeToOutputUnit(separatorEfficiencyCase);
        //    ConvertAssumedLiquidEntrainedToOutputUnit(separatorEfficiencyCase, measurementUnitSystem);
        //    ConvertIshiiKataokaCorrelationToOutputUnit(separatorEfficiencyCase);
        //    ConvertMedToOutputUnit(separatorEfficiencyCase);
        //    ConvertMaxToOutputUnit(separatorEfficiencyCase);
        //    ConvertSauterToOutputUnit(separatorEfficiencyCase);
        //}

        internal static void ConvertTotalLiquidEntrainedToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                separatorEfficiencyCase.HCTotalLiquidEntrainedMeasurementUnit = MassFlowRateUnit.PoundPerHour;
                separatorEfficiencyCase.HCTotalLiquidEntrained = ConvertToMeasurementUnit(separatorEfficiencyCase.HCTotalLiquidEntrainedInKilogramPerSecond, (int)MassFlowRateUnit.KilogramPerSecond, (int)MassFlowRateUnit.PoundPerHour, ConversionUnitType.MassFlowRateUnit);

                separatorEfficiencyCase.WaterTotalLiquidEntrainedMeasurementUnit = MassFlowRateUnit.PoundPerHour;
                separatorEfficiencyCase.WaterTotalLiquidEntrained = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterTotalLiquidEntrainedInKilogramPerSecond, (int)MassFlowRateUnit.KilogramPerSecond, (int)MassFlowRateUnit.PoundPerHour, ConversionUnitType.MassFlowRateUnit);

            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                separatorEfficiencyCase.HCTotalLiquidEntrainedMeasurementUnit = MassFlowRateUnit.KilogramPerHour;
                separatorEfficiencyCase.HCTotalLiquidEntrained = ConvertToMeasurementUnit(separatorEfficiencyCase.HCTotalLiquidEntrainedInKilogramPerSecond, (int)MassFlowRateUnit.KilogramPerSecond, (int)MassFlowRateUnit.KilogramPerHour, ConversionUnitType.MassFlowRateUnit);

                separatorEfficiencyCase.WaterTotalLiquidEntrainedMeasurementUnit = MassFlowRateUnit.KilogramPerHour;
                separatorEfficiencyCase.WaterTotalLiquidEntrained = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterTotalLiquidEntrainedInKilogramPerSecond, (int)MassFlowRateUnit.KilogramPerSecond, (int)MassFlowRateUnit.KilogramPerHour, ConversionUnitType.MassFlowRateUnit);

            }

            separatorEfficiencyCase.HCTotalLiquidEntrained = Math.Round(separatorEfficiencyCase.HCTotalLiquidEntrained.Value, 3);
            separatorEfficiencyCase.WaterTotalLiquidEntrained = Math.Round(separatorEfficiencyCase.WaterTotalLiquidEntrained.Value, 3);
        }

        internal static void ConvertHCDropletSizeToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase)
        {
            separatorEfficiencyCase.HCDropletSizeMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.HCDropletSize = ConvertToMeasurementUnit(separatorEfficiencyCase.HCDropletSizeInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.HCDropletSize = Math.Round(separatorEfficiencyCase.HCDropletSize.Value, 3);
        }
        
        internal static void ConvertWaterDropletSizeToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase)
        {
            separatorEfficiencyCase.WaterDropletSizeMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.WaterDropletSize = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterDropletSizeInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);
            
            separatorEfficiencyCase.WaterDropletSize = Math.Round(separatorEfficiencyCase.WaterDropletSize.Value, 3);
        }

       
        internal static void ConvertAssumedHCEntrainedToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                separatorEfficiencyCase.HCAssumedLiquidEntrainedMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                separatorEfficiencyCase.HCAssumedLiquidEntrained = ConvertToMeasurementUnit(separatorEfficiencyCase.HCAssumedLiquidEntrainedInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                separatorEfficiencyCase.HCAssumedLiquidEntrainedMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                separatorEfficiencyCase.HCAssumedLiquidEntrained = separatorEfficiencyCase.HCAssumedLiquidEntrainedInCubicMeterPerSecond;
            }
            separatorEfficiencyCase.HCAssumedLiquidEntrained = Math.Round(separatorEfficiencyCase.HCAssumedLiquidEntrained.Value, 3);
         }
        internal static void ConvertAssumedWaterEntrainedToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase, MeasurementUnitSystem measurementUnitSystem)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                separatorEfficiencyCase.WaterAssumedLiquidEntrainedMeasurementUnit = VolumeFlowRateUnit.CubicFeetPerSecond;
                separatorEfficiencyCase.WaterAssumedLiquidEntrained = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterAssumedLiquidEntrainedInCubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.CubicFeetPerSecond, ConversionUnitType.VolumeFlowRateUnit);
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                separatorEfficiencyCase.WaterAssumedLiquidEntrainedMeasurementUnit = VolumeFlowRateUnit.CubicMeterPerSecond;
                separatorEfficiencyCase.WaterAssumedLiquidEntrained = separatorEfficiencyCase.WaterAssumedLiquidEntrainedInCubicMeterPerSecond;
            }
            separatorEfficiencyCase.WaterAssumedLiquidEntrained = Math.Round(separatorEfficiencyCase.WaterAssumedLiquidEntrained.Value, 3);
        }

        internal static void ConvertIshiiKataokaCorrelationToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase)
        {

            separatorEfficiencyCase.HCMeanMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.HCMean = ConvertToMeasurementUnit(separatorEfficiencyCase.HCMeanInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.WaterMeanMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.WaterMean = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterMeanInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.HCMean = Math.Round(separatorEfficiencyCase.HCMean.Value, 3);
            separatorEfficiencyCase.WaterMean = Math.Round(separatorEfficiencyCase.WaterMean.Value, 3);

            ConvertSauterToOutputUnit(separatorEfficiencyCase);

            ConvertMedToOutputUnit(separatorEfficiencyCase);
        }

        internal static void ConvertMedToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase)
        {
            separatorEfficiencyCase.WaterMedMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.WaterMed = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterMedInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.HCMedMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.HCMed = ConvertToMeasurementUnit(separatorEfficiencyCase.HCMedInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.HCMed = Math.Round(separatorEfficiencyCase.HCMed.Value, 3);
            separatorEfficiencyCase.WaterMed = Math.Round(separatorEfficiencyCase.WaterMed.Value, 3);
        }

        internal static void ConvertMaxToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase)
        {
            separatorEfficiencyCase.HCMaxMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.HCMax = ConvertToMeasurementUnit(separatorEfficiencyCase.HCMaxInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.WaterMaxMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.WaterMax = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterMaxInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.HCMax = Math.Round(separatorEfficiencyCase.HCMax.Value, 3);
            separatorEfficiencyCase.WaterMax = Math.Round(separatorEfficiencyCase.WaterMax.Value, 3);
        }

        internal static void ConvertSauterToOutputUnit(SeparatorEfficiencyCase separatorEfficiencyCase)
        {
            separatorEfficiencyCase.HCSauterMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.HCSauter = ConvertToMeasurementUnit(separatorEfficiencyCase.HCSauterInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.WaterSauterMeasurementUnit = LengthUnit.Micrometer;
            separatorEfficiencyCase.WaterSauter = ConvertToMeasurementUnit(separatorEfficiencyCase.WaterSauterInMeter, (int)LengthUnit.Meter, (int)LengthUnit.Micrometer, ConversionUnitType.LengthUnit);

            separatorEfficiencyCase.HCSauter = Math.Round(separatorEfficiencyCase.HCSauter.Value, 3);
            separatorEfficiencyCase.WaterSauter = Math.Round(separatorEfficiencyCase.WaterSauter.Value, 3);
        }

        #endregion



        
    }
}
