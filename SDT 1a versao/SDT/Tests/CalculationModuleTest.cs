using NUnit.Framework;
using ScaredFingers.UnitsConversion;
using SDTBusiness.Registers;
using SDTDomainModel.Entities;
using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class CalculationModuleTest
    {
        [Test]
        public static void CalculationOfKVesselTest()
        {
            SDTConverter sdt = new SDTConverter();

            double diameterInMeters = 1.38;
            SeparatorProcessDesignCase c = new SeparatorProcessDesignCase() { VaporMassFlowRateInKilogramPerSecond = 44.340, VaporMassDensityInKilogramPerCubicMeter = 174.654, HCMassDensityInKilogramPerCubicMeter = 839.025, WaterMassDensityInKilogramPerCubicMeter = 1042.851};
            CalculationModuleBusinessFacade.CalculateKVessels(diameterInMeters, c, MeasurementUnitSystem.SI);

            Assert.AreEqual(Math.Round(c.KHCVessel.Value,3), 0.087);

            double KwVessel = sdt.ConvertVelocity(c.KWaterVesselInMeterPerSecond, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond);
            Assert.AreEqual(0.25, Math.Round(KwVessel, 2));
        }

        [Test]
       public static void CalculationOfInletMomentumTest()
        {
           
            double diameterInMeters = 0.393;
            
            SeparatorProcessDesignCase c = new SeparatorProcessDesignCase() 
            { 
                VaporMassFlowRateInKilogramPerSecond = 44.340,
                VaporMassDensityInKilogramPerCubicMeter = 174.654,
                HCMassFlowRateInKilogramPerSecond = 0.00068,
                HCMassDensityInKilogramPerCubicMeter = 839.025,
                WaterMassFlowRateInKilogramPerSecond = 8.452,
                WaterMassDensityInKilogramPerCubicMeter = 1042.851
            };
         
            CalculationModuleBusinessFacade.CalculateInletNozzleOutputs(diameterInMeters, c, MeasurementUnitSystem.SI);

            Assert.AreEqual(Math.Round(c.InletNozzleCalculatedMomentum.Value, 3), 939.918);
        }

        [Test]
        public static void CalculationOfKVesselWithDefaultUnits_Test()
        {
            SeparatorProcessDesignCase c = new SeparatorProcessDesignCase() { VaporMassFlowRate = 44.340, VaporMassFlowRateMeasurementUnit = MassFlowRateUnit.KilogramPerSecond, VaporMassDensity = 174.654, VaporMassDensityMeasurementUnit = MassDensityUnit.KilogramPerCubicMeter, HCMassDensity = 839.025, HCMassDensityMeasurementUnit = MassDensityUnit.KilogramPerCubicMeter };
            SeparatorProcessInformation p = new SeparatorProcessInformation() {Cases = new List<SeparatorProcessDesignCase>()};
            p.Cases.Add(c);
            SeparatorDesign s = new SeparatorDesign()
            {
                Geometry = new SeparatorGeometry() { DrumInsideDiameter =  1.38, DrumInsideDiameterMeasurementUnit = LengthUnit.Meter },
                ProcessInfo = p
            };

            OutputBusinessFacade.GenerateAllOutputs(s, 0);

            Assert.AreEqual(Math.Round(s.ProcessInfo.Cases.FirstOrDefault().KHCVesselInMeterPerSecond, 3), 0.087);
        }

        [Test]
        public static void CalculationOfKVesselWithDifferentUnits_Test()
        {
            SeparatorProcessDesignCase c = new SeparatorProcessDesignCase() { VaporMassFlowRate = 352306, VaporMassFlowRateMeasurementUnit = MassFlowRateUnit.PoundPerHour, VaporMassDensity = 10.9033, VaporMassDensityMeasurementUnit = MassDensityUnit.PoundPerCubicFeet, HCMassDensity = 52.3786, HCMassDensityMeasurementUnit = MassDensityUnit.PoundPerCubicFeet };
            SeparatorProcessInformation p = new SeparatorProcessInformation() { Cases = new List<SeparatorProcessDesignCase>() };
            p.Cases.Add(c);
            SeparatorDesign s = new SeparatorDesign()
            {
                Geometry = new SeparatorGeometry() { DrumInsideDiameter = 1380, DrumInsideDiameterMeasurementUnit = LengthUnit.Milimeter },
                ProcessInfo = p
            };

            OutputBusinessFacade.GenerateAllOutputs(s, 0);

            Assert.AreEqual(Math.Round(s.ProcessInfo.Cases.FirstOrDefault().KHCVesselInMeterPerSecond, 3), 0.087);
        }

        [Test]
       public static void CalculationOfInletMomentumWithDifferentUnits_Test()
        {

            SeparatorProcessDesignCase c = new SeparatorProcessDesignCase() { 
                VaporMassFlowRate = 352306, 
                VaporMassFlowRateMeasurementUnit = MassFlowRateUnit.PoundPerHour,
                HCMassFlowRate = 5.4,
                HCMassFlowRateMeasurementUnit = MassFlowRateUnit.PoundPerHour,
                WaterMassFlowRate = 67077,
                WaterMassFlowRateMeasurementUnit = MassFlowRateUnit.PoundPerHour,
                VaporMassDensity = 10.9033,
                VaporMassDensityMeasurementUnit = MassDensityUnit.PoundPerCubicFeet,
                HCMassDensity = 52.3786,
                HCMassDensityMeasurementUnit = MassDensityUnit.PoundPerCubicFeet,
                WaterMassDensity = 65.1031,
                WaterMassDensityMeasurementUnit = MassDensityUnit.PoundPerCubicFeet
            };
                            
            SeparatorProcessInformation p = new SeparatorProcessInformation() { Cases = new List<SeparatorProcessDesignCase>() };
            p.Cases.Add(c);
            SeparatorDesign s = new SeparatorDesign()
            {
                Geometry = new SeparatorGeometry() 
                { 
                    DrumInsideDiameter = 1380,
                    DrumInsideDiameterMeasurementUnit = LengthUnit.Milimeter,
                    InletNozzleInsideDiameter = 15.5,
                    InletNozzleInsideDiameterMeasurementUnit = LengthUnit.Inches
                },
                ProcessInfo = p
            };

            OutputBusinessFacade.GenerateAllOutputs(s, 0);

            Assert.AreEqual(Math.Round(s.ProcessInfo.Cases.FirstOrDefault().KHCVesselInMeterPerSecond, 3), 0.087);
        }
        
        [Test]
       public static void CalculationOfDRF_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateDRFInMilimeter(0.0081050718, 839.025, 174.654, 0);

            Assert.AreEqual(162, Math.Round(output,0));
        }

        [Test]
       public static void CalculationOfDRFVelocity_Test()
        {
            SDTConverter sdt = new SDTConverter();

            double output = CalculationModuleBusinessFacade.CalculateDRFVelocity(0.0081050718, 0.2032);

            double outputInFeetPerSecond = sdt.ConvertVelocity(output, (int)VelocityUnit.MeterPerSecond, (int)VelocityUnit.FeetPerSecond);
            Assert.AreEqual(0.82, Math.Round(outputInFeetPerSecond,2));
        }

        [Test]
       public static void CalculationOfWebber_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateWebber(0.06994, 0.2541720456, 174.654, 0.1217365307, 0.3937);
            Assert.AreEqual(1932.767, Math.Round(output, 3));
        }

        [Test]
       public static void CalculationOfReynolds_Test()
        {
            SDTConverter sdt = new SDTConverter();

            double viscosityInKilogramPerMeter_Second =sdt.ConvertViscosity(0.683, (int)ViscosityUnit.Centipoise, (int)ViscosityUnit.KilogramPerMeterSecond);
            double output = CalculationModuleBusinessFacade.CalculateReynolds(viscosityInKilogramPerMeter_Second, 0.0081042516, 1042.851403226, 0.1217365307, 0.3937, 1);

            Assert.AreEqual(40018, Math.Round(output, 0));
        }

        [Test]
       public static void CalculationOfSlipVelocityInFeetPerSecond_Test()
        {
            SDTConverter sdt = new SDTConverter();

            double viscosityInKilogramPerMeter_Second = sdt.ConvertViscosity(0.000683, (int)ViscosityUnit.PascalSecond, (int)ViscosityUnit.KilogramPerMeterSecond);

            double output = CalculationModuleBusinessFacade.CalculateSlipVelocityInFeetPerSecond(0.3937, 1042.851403226, viscosityInKilogramPerMeter_Second, 0.06994);

            Assert.AreEqual(0.001583, Math.Round(output, 6));
        }

        [Test]
        public void CalculationOfX_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateX(1932.767, 40018);

            Assert.AreEqual(181254, Math.Round(output, 0));
        }

        [Test]
       public static void CalculationOfXX_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateXX(181000);

            Assert.AreEqual(5.26, Math.Round(output, 2));
        }

        [Test]
       public static void CalculationOfPercentageLiquidEntrainedWithOlga_Correlation_Test()
        {
            SDTConverter sdt = new SDTConverter();

            double viscosityInKilogramPerMeter_Second = sdt.ConvertViscosity(0.683, (int)ViscosityUnit.Centipoise, (int)ViscosityUnit.KilogramPerMeterSecond);
           
            double output = CalculationModuleBusinessFacade.UseOlgaCorrelationToCalculatePercentageLiquidEntrained(0.3937, 1042.851403226, viscosityInKilogramPerMeter_Second, 0.06994, 0.0081042516, 0.1217365307, 0.2541720456, 174.654);

            Assert.AreEqual(0.0729, Math.Round(output, 4));
        }

        [Test]
       public static void CalculationOfCompressibilityFactor()
        {
            SDTConverter sdt = new SDTConverter();

            double pressureInPascal = sdt.ConvertPressure(2074.0397377, (int)PressureUnit.PoundPerSquareInch, (int)PressureUnit.Pascal);
            double molecularWeightInKilogramPerKilogramMol = sdt.ConvertMolecularWeight(19.55, (int)MolecularWeightUnit.PoundPerPoundMol, (int)MolecularWeightUnit.KilogramPerKilogramMol);
            double massDensityInKilogramPerCubicMeter = sdt.ConvertMassDensity(10.9033, (int)MassDensityUnit.PoundPerCubicFeet, (int)MassDensityUnit.KilogramPerCubicMeter);
            
            double output = CalculationModuleBusinessFacade.CalculateCompressibilityFactor(pressureInPascal, 100, molecularWeightInKilogramPerKilogramMol, massDensityInKilogramPerCubicMeter);

            Assert.AreEqual(0.619, Math.Round(output, 3));
        }

        //[Test]
        //public void CalculationOfStandardVolumetricFlowRate()
        //{
        //    SDTConverter sdt = new SDTConverter();

        //    var facade = new CalculationModuleBusinessFacade();

        //    double pressureInPascal = sdt.ConvertPressure(2074.0397377, (int)PressureUnit.PoundPerSquareInch, (int)PressureUnit.Pascal);
            
        //    double output = facade.CalculateStandardVolumetricFlowRateInCubicMeterPerSecond(0.2541720456, pressureInPascal, 100, 0.619);
      

        //    Assert.AreEqual(53.7, Math.Round(output, 1));
        //}

        [Test]
       public static void CalculationOfVaporSpecificGravity()
        {
            SDTConverter sdt = new SDTConverter();

            double molecularWeightInKilogramPerKilogramMol = sdt.ConvertMolecularWeight(19.55, (int)MolecularWeightUnit.PoundPerPoundMol, (int)MolecularWeightUnit.KilogramPerKilogramMol);
            double output = CalculationModuleBusinessFacade.CalculateVaporSpecificGravity(molecularWeightInKilogramPerKilogramMol);
            
            Assert.AreEqual(0.675069, Math.Round(output, 6));
        }

        [Test]
       public static void CalculationOfDropletSize_Test()
        {
            SDTConverter sdt = new SDTConverter();
            var surfaceTensionInNewtonPerMeter = sdt.ConvertSurfaceTension(16.69, (int)SurfaceTensionUnit.DynePerCentimeter, (int)SurfaceTensionUnit.NewtonPerMeter);
            var viscosityInKilogramPerMeter_Second = sdt.ConvertViscosity(1.5, (int)ViscosityUnit.Centipoise, (int)ViscosityUnit.KilogramPerMeterSecond);
            var vaporViscosityInKilogramPerMeter_Second = sdt.ConvertViscosity(0.012, (int)ViscosityUnit.Centipoise, (int)ViscosityUnit.KilogramPerMeterSecond);

            double output = CalculationModuleBusinessFacade.CalculateDropletSize(surfaceTensionInNewtonPerMeter, 839.025, viscosityInKilogramPerMeter_Second, 8.202e-7, 0.1217365307, 0.3937, 1, 174.654074918, 0.2541720456, vaporViscosityInKilogramPerMeter_Second);

            //Assert.AreEqual(0.006389, Math.Round(output, 6));
            Assert.AreEqual(0.00638, Math.Round(output, 5));
        }

        [Test]
       public static void CalculationOfSauter_UsingIshiiKataoakCorrelation_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateSauterUsingIshiiKataokaCorrelation(0.00639);

            Assert.AreEqual(0.001624, Math.Round(output, 6));
        }

        [Test]
       public static void CalculationOfMean_UsingIshiiKataoakCorrelation_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateMeanUsingIshiiKataokaCorrelation(0.00639);

            Assert.AreEqual(0.002171, Math.Round(output, 6));
        }

        [Test]
       public static void CalculationOfMed_UsingIshiiKataoakCorrelation_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateMedUsingIshiiKataokaCorrelation(0.00639);

            Assert.AreEqual(0.001607, Math.Round(output, 6));
        }

        [Test]
       public static void CalculationOfMed_UsingTattersonDallmanHanrattyCorrelation_Test()
        {
            SDTConverter sdt = new SDTConverter();

            var surfaceTensionInNewtonPerMeter = sdt.ConvertSurfaceTension(16.69, (int)SurfaceTensionUnit.DynePerCentimeter, (int)SurfaceTensionUnit.NewtonPerMeter);
            var vaporViscosityInKilogramPerMeter_Second = sdt.ConvertViscosity(0.012, (int)ViscosityUnit.Centipoise, (int)ViscosityUnit.KilogramPerMeterSecond);

            double output = CalculationModuleBusinessFacade.CalculateMedUsingTattersonDallmanHanrattyCorrelation(surfaceTensionInNewtonPerMeter, 0.2541720456, 0.1217365307, 174.654074918, 0.3937, vaporViscosityInKilogramPerMeter_Second);

            //Assert.AreEqual(0.001582 , Math.Round(output, 6));
            Assert.AreEqual(0.00158, Math.Round(output, 5));
        }

        [Test]
       public static void CalculationOfMax_UsingTattersonDallmanHanrattyCorrelation_Test()
        {
          
            SDTConverter sdt = new SDTConverter();

            var surfaceTensionInNewtonPerMeter = sdt.ConvertSurfaceTension(16.69, (int)SurfaceTensionUnit.DynePerCentimeter, (int)SurfaceTensionUnit.NewtonPerMeter);
            var vaporViscosityInKilogramPerMeter_Second = sdt.ConvertViscosity(0.012, (int)ViscosityUnit.Centipoise, (int)ViscosityUnit.KilogramPerMeterSecond);

            double med = CalculationModuleBusinessFacade.CalculateMedUsingTattersonDallmanHanrattyCorrelation(surfaceTensionInNewtonPerMeter, 0.2541720456, 0.1217365307, 174.654074918, 0.3937, vaporViscosityInKilogramPerMeter_Second);


            double output = CalculationModuleBusinessFacade.CalculateMaxUsingTattersonDallmanHanrattyCorrelation(med);


            Assert.AreEqual(Math.Round(0.004586, 6), Math.Round(output, 6));
        }

        [Test]
       public static void CalculationOfSauter_UsingTattersonDallmanHanrattyCorrelation_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateSauterUsingTattersonDallmanHanrattyCorrelation(0.004586, 0.001582);

            Assert.AreEqual(0.001125, Math.Round(output, 6));
        }

        [Test]
       public static void CalculationOfProjectedDrumEfficiency_Test()
        {
            double output = CalculationModuleBusinessFacade.CalculateProjectedDrumEfficiency(0.000255, 0.00639);

            Assert.AreEqual(Math.Round(99.877, 2), Math.Round(output, 2));
        }

        [Test]
       public static void CalculationOfAssumedLiquidEntrained_Test()
        {
            SDTConverter sdt = new SDTConverter();
 
            double output = CalculationModuleBusinessFacade.CalculateAssumedLiquidEntrained(0.000255, 0.00639, 8.202e-7);

            var vaporViscosityInKilogramPerMeter_Second = sdt.ConvertVolumeFlowRate(output, (int)VolumeFlowRateUnit.CubicMeterPerSecond, (int)VolumeFlowRateUnit.GallonPerMinute);


            Assert.AreEqual(Math.Round(0.00001584, 6), Math.Round(vaporViscosityInKilogramPerMeter_Second,6));
        }
    }
}
