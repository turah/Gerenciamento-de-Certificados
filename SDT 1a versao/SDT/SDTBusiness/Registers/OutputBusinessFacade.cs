using SDTBusiness.Unity;
using SDTDomainModel.Entities;
using SDTDomainModel.Enums;
using SDTFramework.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTBusiness.Registers
{
    public class OutputBusinessFacade : BaseUnity
    {
        #region Geometry Screen

        public static void GenerateKVesselOutputs(SeparatorGeometry g, List<SeparatorProcessDesignCase> cases, MeasurementUnitSystem measurementUnitSystem)
        {
            g.DrumInsideDiameterInMeters = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.DrumInsideDiameter, (int)g.DrumInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

            foreach (var item in cases)
            {
                MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                CalculationModuleBusinessFacade.CalculateKVessels(g.DrumInsideDiameterInMeters, item, measurementUnitSystem);
            }
        }

        public static void GenerateInletNozzleOutputs(SeparatorGeometry g, List<SeparatorProcessDesignCase> cases, MeasurementUnitSystem measurementUnitSystem)
        {
            g.InletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.InletNozzleInsideDiameter, (int)g.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

            foreach (var item in cases)
            {
                MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                CalculationModuleBusinessFacade.CalculateInletNozzleOutputs(g.InletNozzleInsideDiameterInMeter, item, measurementUnitSystem);
            }

            SetInletMaximumMomentum(measurementUnitSystem, g);
        }

        public static void GenerateVaporOutletOutputs(SeparatorGeometry g, List<SeparatorProcessDesignCase> cases, MeasurementUnitSystem measurementUnitSystem)
        {
             g.VaporOutletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.VaporOutletNozzleInsideDiameter, (int)g.VaporOutletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

            foreach (var item in cases)
            {
                MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                CalculationModuleBusinessFacade.CalculateOutletMomentum(g.VaporOutletNozzleInsideDiameterInMeter, item, measurementUnitSystem);
            }

            SetVaporOutletMaximumMomentum(measurementUnitSystem, g);
        }

        public static void GenerateLiquidOutletOutputs(SeparatorGeometry g, List<SeparatorProcessDesignCase> cases, MeasurementUnitSystem measurementUnitSystem)
        {
             g.LiquidOutletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.LiquidOutletNozzleInsideDiameter, (int)g.LiquidOutletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

            foreach (var item in cases)
            {
                MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                CalculationModuleBusinessFacade.CalculateLiquidOutletOutputs(g.LiquidOutletNozzleInsideDiameterInMeter, item, measurementUnitSystem);
            }
        }

        public static void GenerateHCSmallestDropletDiameter(SeparatorGeometry g, List<SeparatorProcessDesignCase> cases, MeasurementUnitSystem measurementUnitSystem)
        {
            try {
                g.DrumInsideDiameterInMeters = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.DrumInsideDiameter, (int)g.DrumInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
                g.HCInitialGuessForDropletSizeInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.HCInitialGuessForDropletSize, (int)g.HCInitialGuessForDropletSizeMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

                foreach (var item in cases)
                {
                    MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                    CalculationModuleBusinessFacade.CalculateHCDropletCutDiameter(g.HCInitialGuessForDropletSizeInMeter, g.DrumInsideDiameterInMeters, item, measurementUnitSystem);
                }
            }
            catch (Exception e){
                throw e;
            }
        }

        public static void GenerateWaterSmallestDropletDiameter(SeparatorGeometry g, List<SeparatorProcessDesignCase> cases, MeasurementUnitSystem measurementUnitSystem)
        {
            try
            {
                g.DrumInsideDiameterInMeters = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.DrumInsideDiameter, (int)g.DrumInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

                g.DrumInsideDiameterInMeters = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.DrumInsideDiameter, (int)g.DrumInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
                g.WaterInitialGuessForDropletSizeInMeter =
                    MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(g.WaterInitialGuessForDropletSize,
                        (int) LengthUnit.Micrometer, (int) LengthUnit.Meter, ConversionUnitType.LengthUnit);

                foreach (var item in cases)
                {
                    MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                    CalculationModuleBusinessFacade.CalculateWaterDropletCutDiameter(g.WaterInitialGuessForDropletSizeInMeter, g.DrumInsideDiameterInMeters, item, measurementUnitSystem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion
        
        #region Output Screen

        public static SeparatorDesign GenerateAllOutputs(SeparatorDesign s, int caseIndex)
        {
            try
            {
                 s.Geometry.InletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.InletNozzleInsideDiameter, (int)s.Geometry.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
                 s.Geometry.DrumInsideDiameterInMeters = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.DrumInsideDiameter, (int)s.Geometry.DrumInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
                 s.Geometry.VaporOutletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.VaporOutletNozzleInsideDiameter, (int)s.Geometry.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
                 s.Geometry.LiquidOutletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.LiquidOutletNozzleInsideDiameter, (int)s.Geometry.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);

                 s.ProcessInfo.PressureInPascal = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.ProcessInfo.Pressure, (int)s.ProcessInfo.PressureUnit, (int)PressureUnit.Pascal, ConversionUnitType.PressureUnit);
                 s.ProcessInfo.TemperatureInFahrenheit = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.ProcessInfo.Temperature, (int)s.ProcessInfo.TemperatureUnit, (int)TemperatureUnit.Fahrenheit, ConversionUnitType.TemperatureUnit);

                 s.Geometry.HCInitialGuessForDropletSizeInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.HCInitialGuessForDropletSize, (int)s.Geometry.HCInitialGuessForDropletSizeMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
                 s.Geometry.WaterInitialGuessForDropletSizeInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.WaterInitialGuessForDropletSize, (int)s.Geometry.WaterInitialGuessForDropletSizeMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);


                 SeparatorProcessDesignCase item = s.ProcessInfo.Cases[caseIndex];
                 if (item != null) { 
                    
                    MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);
                    CheckAndCalculateGeometryOutputs(s, item);
                    CheckAndCalculateProcessParametersOutputs(s, item);
                    //CalculationModuleBusinessFacade.CalculateSeparationEfficiency(item, (int)s.Geometry.NumberOfInletNozzles, s.CorrelationType, s.GeneralInfo.OutputUnitSet, s.Geometry.InletNozzleInsideDiameterInMeter);

                 }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private static void CheckAndCalculateProcessParametersOutputs(SeparatorDesign s, SeparatorProcessDesignCase item)
        {
            if (s.ProcessInfo.Pressure != null && s.ProcessInfo.Temperature != null && item.VaporMolecularWeight != null && item.VaporMassDensity != null)
            {
                item.CompressibilityFactor = CalculationModuleBusinessFacade.CalculateCompressibilityFactor(s.ProcessInfo.PressureInPascal, s.ProcessInfo.TemperatureInFahrenheit, item.VaporMolecularWeightInKilogramPerKilogramMol, item.VaporMassDensityInKilogramPerCubicMeter);
                //CalculationModuleBusinessFacade.CalculateStandardVolumetricFlowRateInCubicMeterPerSecond(s.ProcessInfo.PressureInPascal, s.ProcessInfo.TemperatureInFahrenheit, item, s.GeneralInfo.OutputUnitSet);
            }
            if (item.VaporMolecularWeight != null)
            {
                item.Sg = CalculationModuleBusinessFacade.CalculateVaporSpecificGravity(item.VaporMolecularWeightInKilogramPerKilogramMol);
            }
            if (item.Qt != null)
            {
                CalculationModuleBusinessFacade.CalculatePercentageOfVaporByVolume(item);
            }
            if (s.Geometry.LiquidOutletNozzleInsideDiameter > 0)
            {
                item.FroudeNumber = CalculationModuleBusinessFacade.CalculateFroudeNumber(item, s.Geometry.LiquidOutletNozzleInsideDiameterInMeter);
            }
        }

        private static void CheckAndCalculateDropletsCutDiameter(SeparatorDesign s, SeparatorProcessDesignCase item)
        {
            if (s.Geometry.HCInitialGuessForDropletSize != null && s.Geometry.DrumInsideDiameter != null && CalculationModuleBusinessFacade.IsValidNumber(item.HCMassDensity))
            {
                //CalculationModuleBusinessFacade.CalculateHCDropletCutDiameter(s.Geometry.HCInitialGuessForDropletSizeInMeter, s.Geometry.DrumInsideDiameterInMeters, item, s.GeneralInfo.OutputUnitSet);
            }
            if (s.Geometry.WaterInitialGuessForDropletSize != null && s.Geometry.DrumInsideDiameter != null && CalculationModuleBusinessFacade.IsValidNumber(item.WaterMassDensity))
            {
                //CalculationModuleBusinessFacade.CalculateWaterDropletCutDiameter(s.Geometry.WaterInitialGuessForDropletSizeInMeter, s.Geometry.DrumInsideDiameterInMeters, item, s.GeneralInfo.OutputUnitSet);
            }
        }

        private static void CheckAndCalculateLiquidOutletOutputs(SeparatorDesign s, SeparatorProcessDesignCase item)
        {
            if (s.Geometry.LiquidOutletNozzleInsideDiameter != null)
            {
               // CalculationModuleBusinessFacade.CalculateLiquidOutletOutputs(s.Geometry.LiquidOutletNozzleInsideDiameterInMeter, item, s.GeneralInfo.OutputUnitSet);
            }
        }

        private static void CheckAndCalculateOutletMomentum(SeparatorDesign s, SeparatorProcessDesignCase item)
        {
            if (s.Geometry.VaporOutletNozzleInsideDiameter != null)
            {
                //CalculationModuleBusinessFacade.CalculateOutletMomentum(s.Geometry.VaporOutletNozzleInsideDiameterInMeter, item, s.GeneralInfo.OutputUnitSet);
            }
        }

        private static void CheckAndCalculateInletNozzleOutputs(SeparatorDesign s, SeparatorProcessDesignCase item)
        {
            if (s.Geometry.InletNozzleInsideDiameter != null)
            {
                //CalculationModuleBusinessFacade.CalculateInletNozzleOutputs(s.Geometry.InletNozzleInsideDiameterInMeter, item, s.GeneralInfo.OutputUnitSet);
            }
        }

        private static void CheckAndCalculateKVessels(SeparatorDesign s, SeparatorProcessDesignCase item)
        {
            if (s.Geometry.DrumInsideDiameter != null)
            {
                //CalculationModuleBusinessFacade.CalculateKVessels(s.Geometry.DrumInsideDiameterInMeters, item, s.GeneralInfo.OutputUnitSet);
            }
        }

        #endregion

        public static void SetInletMaximumMomentum(MeasurementUnitSystem measurementUnitSystem, SeparatorGeometry sg)
        {
            if (sg.InletDevice.Equals(InletDevices.HalfPipe) || sg.InletDevice.Equals(InletDevices.SplashPlate) || sg.InletDevice.Equals(InletDevices.Elbow) || sg.InletDevice.Equals(InletDevices.FlushNozzle) || sg.InletDevice.Equals(InletDevices.VBaffle))
            {
                sg.InletNozzleMaxMomentum = measurementUnitSystem.Equals(MeasurementUnitSystem.US) ? 2015.0 : 3000.0;
            }
            else if (sg.InletDevice.Equals(InletDevices.SlottedPipe))
            {
                sg.InletNozzleMaxMomentum = measurementUnitSystem.Equals(MeasurementUnitSystem.US) ? 3700.0 : 5500.0;
            }
            else if (sg.InletDevice.Equals(InletDevices.InletVaneDiffuser))
            {
                sg.InletNozzleMaxMomentum = measurementUnitSystem.Equals(MeasurementUnitSystem.US) ? 5375.0 : 8000.0;
            }
            if (sg.InletDevice.Equals(InletDevices.InletCyclones))
            {
                sg.InletNozzleMaxMomentum = measurementUnitSystem.Equals(MeasurementUnitSystem.US) ? 10080.0 : 15000.0;
            }
            sg.InletNozzleMaxMomentumMeasurementUnit = sg.InletNozzleMaxMomentumMeasurementUnit.Equals(MeasurementUnitSystem.US) ? MomentumUnit.PoundPerFeetSquaredSecond : MomentumUnit.KilogramPerMeterSquaredSecond;
        }
        
        private static void SetVaporOutletMaximumMomentum(MeasurementUnitSystem measurementUnitSystem, SeparatorGeometry g)
        {
            if (measurementUnitSystem == MeasurementUnitSystem.SI)
            {
                g.VaporOutletNozzleMaxMomentum = 5400;
                g.VaporOutletNozzleMaxMomentumMeasurementUnit = MomentumUnit.PoundPerFeetSquaredSecond;
            }
            else if (measurementUnitSystem == MeasurementUnitSystem.US)
            {
                g.VaporOutletNozzleMaxMomentum = 3600;
                g.VaporOutletNozzleMaxMomentumMeasurementUnit = MomentumUnit.KilogramPerMeterSquaredSecond;
            }
        }
       
       public static void GenerateAllGeometryOutputs(SeparatorDesign s)
       {
           try
           {

               s.Geometry.InletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.InletNozzleInsideDiameter, (int)s.Geometry.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
               s.Geometry.DrumInsideDiameterInMeters = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.DrumInsideDiameter, (int)s.Geometry.DrumInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
               s.Geometry.VaporOutletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.VaporOutletNozzleInsideDiameter, (int)s.Geometry.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
               s.Geometry.LiquidOutletNozzleInsideDiameterInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.LiquidOutletNozzleInsideDiameter, (int)s.Geometry.InletNozzleInsideDiameterMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);


               s.Geometry.HCInitialGuessForDropletSizeInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.HCInitialGuessForDropletSize, (int)s.Geometry.HCInitialGuessForDropletSizeMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);
               s.Geometry.WaterInitialGuessForDropletSizeInMeter = MeasurementUnitBusinessFacade.ConvertToMeasurementUnit(s.Geometry.WaterInitialGuessForDropletSize, (int)s.Geometry.WaterInitialGuessForDropletSizeMeasurementUnit, (int)LengthUnit.Meter, ConversionUnitType.LengthUnit);


               foreach (var item in s.ProcessInfo.Cases)
               {
                   MeasurementUnitBusinessFacade.ConvertCaseInputsToDefaultCalculationUnits(item);

                   CheckAndCalculateGeometryOutputs(s, item);
               }

               if (s.Geometry.InletNozzleInsideDiameter != null)
               {
                   //SetInletMaximumMomentum(s.GeneralInfo.OutputUnitSet, s.Geometry);
               }
               if (s.Geometry.VaporOutletNozzleInsideDiameter != null)
               {
                   //SetVaporOutletMaximumMomentum(s.GeneralInfo.OutputUnitSet, s.Geometry);
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }
        }

       private static void CheckAndCalculateGeometryOutputs(SeparatorDesign s, SeparatorProcessDesignCase item)
       {
           CheckAndCalculateKVessels(s, item);
           CheckAndCalculateInletNozzleOutputs(s, item);
           CheckAndCalculateOutletMomentum(s, item);
           CheckAndCalculateLiquidOutletOutputs(s, item);
           CheckAndCalculateDropletsCutDiameter(s, item);
       }
    }
}
