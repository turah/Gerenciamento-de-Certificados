using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaredFingers.UnitsConversion;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Program
    {
        public static void Main()
        {
        }

        #region Conversion

        #region LengthUnitTest

        [Test]
        public void TestConvertMeterToKilometer()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 3), 0.001);
        }

        [Test]
        public void TestConvertMeterToCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 3);
            Assert.AreEqual(facade, 100);
        }
        [Test]
        public void TestConvertMeterToMilimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 4);
            Assert.AreEqual(facade, 1000);
        }
        [Test]
        public void TestConvertMeterToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 5);
            Assert.AreEqual(Math.Round(facade, 8), 0.00062137);
        }
        [Test]
        public void TestConvertMeterToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 6);
            Assert.AreEqual(Math.Round(facade, 6), 1.093613);
        }
        [Test]
        public void TestConvertMeterToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 7);
            Assert.AreEqual(Math.Round(facade, 5), 3.28084);
        }
        [Test]
        public void TestConvertMeterToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 1, 8);
            Assert.AreEqual(Math.Round(facade, 2), 39.37);
        }

        [Test]
        public void TestConvertKilometerToCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 3);
            Assert.AreEqual(facade, 100000);
        }
        [Test]
        public void TestConvertKilometerToMilimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 4);
            Assert.AreEqual(facade, 1000000);
        }
        [Test]
        public void TestConvertKilometerToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 5);
            Assert.AreEqual(Math.Round(facade, 5), 0.62137);
        }
        [Test]
        public void TestConvertKilometerToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 6);
            Assert.AreEqual(Math.Round(facade, 3), 1093.613);
        }
        [Test]
        public void TestConvertKilometerToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 7);
            Assert.AreEqual(Math.Round(facade, 2), 3280.84);
        }
        [Test]
        public void TestConvertKilometerToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 8);
            Assert.AreEqual(facade, 39370.0);
        }

        [Test]
        public void TestConvertCentimeterToMilimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 4);
            Assert.AreEqual(facade, 10);
        }
        [Test]
        public void TestConvertCentimeterToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 5);
            Assert.AreEqual(Math.Round(facade, 11), 0.00000621371);
        }
        [Test]
        public void TestConvertCentimeterToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 6);
            Assert.AreEqual(Math.Round(facade, 8), 0.01093613);
        }
        [Test]
        public void TestConvertCentimeterToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 7);
            Assert.AreEqual(Math.Round(facade, 7), 0.0328084);
        }
        [Test]
        public void TestConvertCentimeterToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 8);
            Assert.AreEqual(Math.Round(facade, 5), 0.39370);
        }

        [Test]
        public void TestConvertMilimeterToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 5);
            Assert.AreEqual(Math.Round(facade, 6), Math.Round(6.21371192237e-7, 6));
        }
        [Test]
        public void TestConvertMilimeterToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 6);
            Assert.AreEqual(Math.Round(facade, 9), 0.001093613);
        }
        [Test]
        public void TestConvertMilimeterToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 7);
            Assert.AreEqual(Math.Round(facade, 8), 0.00328084);
        }
        [Test]
        public void TestConvertMilimeterToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 8);
            Assert.AreEqual(Math.Round(facade, 6), 0.039370);
        }

        [Test]
        public void TestConvertMileToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 6);
            Assert.AreEqual(facade, 1760);
        }
        [Test]
        public void TestConvertMileToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 7);
            Assert.AreEqual(facade, 5280);
        }
        [Test]
        public void TestConvertMileToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 8);
            Assert.AreEqual(facade, 63360);
        }

        [Test]
        public void TestConvertYardsToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 7);
            Assert.AreEqual(facade, 3);
        }
        [Test]
        public void TestConvertYardsToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 8);
            Assert.AreEqual(facade, 36);
        }

        [Test]
        public void TestConvertFootToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 8);
            Assert.AreEqual(facade, 12);
        }


        #endregion

        #region TemperatureUnitTest

        [Test]
        public void TestConvertCelsiusToKelvin()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertTemperature(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 3), 274.15);
        }
        [Test]
        public void TestConvertCelsiusToFahrenheit()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertTemperature(1, 1, 3);
            Assert.AreEqual(Math.Round(facade, 1), 33.8);
        }

        [Test]
        public void TestConvertKelvinToFahrenheit()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertTemperature(1, 2, 3);
            Assert.AreEqual(Math.Round(facade, 2), -457.87);
        }

        //[Test]
        //public void TestConvertCelsiusToRankine() {
        //    SDTConverter c = new SDTConverter();
        //    var facade = c.ConvertTemperature(20, 1, 4);
        //    Assert.AreEqual(Math.Round(facade, 3), 527.67);
        //}

        //[Test]
        //public void TestConvertKelvinToRankine()
        //{
        //    SDTConverter c = new SDTConverter();
        //    var facade = c.ConvertTemperature(1, 2, 4);
        //    Assert.AreEqual(Math.Round(facade, 5), 1.8);
        //}

        //[Test]
        //public void TestConvertFahrenheitToRankine()
        //{
        //    SDTConverter c = new SDTConverter();
        //    var facade = c.ConvertTemperature(1, 3, 4);
        //    Assert.AreEqual(Math.Round(facade, 2), 460.67);
        //}

        #endregion

        #region VolumeUnitTest

        [Test]
        public void TestConvertLiterToUSGallon()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolume(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 6), 0.264172);
        }

        #endregion

        #region WeightUnitTest

        [Test]
        public void TestConvertKilogramToGram()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 1, 2);
            Assert.AreEqual(facade, 1000);
        }
        [Test]
        public void TestConvertKilogramToMiligram()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 1, 3);
            Assert.AreEqual(facade, 1000000);
        }
        [Test]
        public void TestConvertKilogramToPound()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 1, 4);
            Assert.AreEqual(Math.Round(facade, 7), 2.204622);
        }
        [Test]
        public void TestConvertKilogramToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 1, 5);
            Assert.AreEqual(Math.Round(facade, 5), 35.27396);
        }

        [Test]
        public void TestConvertGramToMiligram()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 2, 3);
            Assert.AreEqual(facade, 1000);
        }
        [Test]
        public void TestConvertGramToPound()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 2, 4);
            Assert.AreEqual(Math.Round(facade, 10), 0.0022046226);
        }
        [Test]
        public void TestConvertGramToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 2, 5);
            Assert.AreEqual(Math.Round(facade, 8), 0.03527396);
        }

        [Test]
        public void TestConvertMiligramToPound()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 3, 4);
            Assert.AreEqual(Math.Round(facade, 11), 0.00000220462);
        }
        [Test]
        public void TestConvertMiligramToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 3, 5);
            Assert.AreEqual(Math.Round(facade, 10), 0.000035274);
        }

        [Test]
        public void TestConvertPoundToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 4, 5);
            Assert.AreEqual(facade, 16);
        }

        #endregion

        #region MassDensityUnitTest

        [Test]
        public void TestConvertKilogramPerCubicMeterToGramPerCubicCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassDensity(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 3), 0.001);
        }
        [Test]
        public void TestConvertKilogramPerCubicMeterToPoundPerCubicFeet()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassDensity(1, 1, 3);
            Assert.AreEqual(Math.Round(facade, 8), 0.06242796);
        }

        [Test]
        public void TestConvertGramPerCubicCentimeterToPoundPerCubicFeet()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassDensity(1, 2, 3);
            Assert.AreEqual(Math.Round(facade, 5), 62.42796);
        }

        #endregion

        #region MassFlowRateUnitTest

        [Test]
        public void TestConvertKilogramPerSecondToKilogramPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 1, 2);
            Assert.AreEqual(facade, 3600);
        }
        [Test]
        public void TestConvertKilogramPerSecondToPoundPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 1, 3);
            Assert.AreEqual(Math.Round(facade, 5), 2.20462);
        }
        [Test]
        public void TestConvertKilogramPerSecondToPoundPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 1, 4);
            Assert.AreEqual(Math.Round(facade, 2), 7936.64);
        }

        [Test]
        public void TestConvertKilogramPerHourToPoundPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 2, 3);
            Assert.AreEqual(Math.Round(facade, 9), 0.000612395);
        }
        [Test]
        public void TestConvertKilogramPerHourToPoundPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 2, 4);
            Assert.AreEqual(Math.Round(facade, 6), 2.204623);
        }

        [Test]
        public void TestConvertPoundPerSecondToPoundPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 3, 4);
            Assert.AreEqual(facade, 3600);
        }

        #endregion

        #region SurfaceTensionUnitTest

        [Test]
        public void TestConvertNewtonPerMeterToDynePerCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertSurfaceTension(1, 1, 2);
            Assert.AreEqual(facade, 1000);
        }

        #endregion

        #region VelocityUnitTest

        [Test]
        public void TestConvertMeterPerSecondToFeetPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVelocity(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 7), 3.2808399);
        }

        #endregion

        #region VolumeFlowRateUnitTest

        [Test]
        public void TestConvertCubicMeterPerSecondToCubicFeetPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 5), 35.31466);
        }
        [Test]
        public void TestConvertCubicMeterPerSecondToCubicMeterPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 1, 3);
            Assert.AreEqual(facade, 3600);
        }

        [Test]
        public void TestConvertCubicFeetPerSecondToCubicMeterPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 2, 3);
            Assert.AreEqual(Math.Round(facade, 5), 101.94066);
        }

        [Test]
        public void TestConvertCubicMeterPerSecondToGallonPerMinute()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 1, 4);
            Assert.AreEqual(Math.Round(facade, 3), 15850);
        }
        [Test]
        public void TestConvertCubicFeetPerSecondPerSecondToGallonPerMinute()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 2, 4);
            Assert.AreEqual(Math.Round(facade, 2), 448.8);
        }

        [Test]
        public void TestConvertCubicMeterPerHourToGallonPerMinute()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 3, 4);
            Assert.AreEqual(Math.Round(facade, 4), 4.403);
        }


        #endregion

        #region ViscosityUnitTest

        [Test]
        public void TestConvertKilogramPerMeter_SecondToPascal_Second()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 1, 2);
            Assert.AreEqual(facade, 1);
        }
        [Test]
        public void TestConvertKilogramPerMeter_SecondToPoundPerFeet_Second()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 1, 3);
            Assert.AreEqual(Math.Round(facade, 5), 0.67197);
        }
        [Test]
        public void TestConvertKilogramPerMeter_SecondToCentipoise()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 1, 4);
            Assert.AreEqual(facade, 1000);
        }

        [Test]
        public void TestConvertPascal_SecondToPoundPerFeet_Second()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 2, 3);
            Assert.AreEqual(Math.Round(facade, 5), 0.67197);
        }
        [Test]
        public void TestConvertPascal_SecondToCentipoise()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 2, 4);
            Assert.AreEqual(facade, 1000);
        }

        [Test]
        public void TestConvertPoundPerFeet_SecondToCentipoise()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertViscosity(1, 3, 4);
            Assert.AreEqual(Math.Round(facade, 4), 1488.1639);
        }

        #endregion

        #region PressureUnitTest

        [Test]
        public void TestConvertPascalToPoundPerSquareInch()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertPressure(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 6), 0.000145);
        }

        [Test]
        public void TestConvertPascalToBar()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertPressure(1, 1, 3);
            Assert.AreEqual(Math.Round(facade, 5), 0.00001);
        }

        [Test]
        public void TestConvertPoundPerSquareInchToBar()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertPressure(1, 2, 3);
            Assert.AreEqual(Math.Round(facade, 8), 0.06894758);
        }
        #endregion

        #region MolecularWeightUnitTest

        [Test]
        public void TestConvertKilogramPerKilogramMolToGramPerGramMol()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMolecularWeight(1, 1, 2);
            Assert.AreEqual(facade, 1);
        }

        [Test]
        public void TestConvertKilogramPerKilogramMolToPoundPerPoundMol()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMolecularWeight(1, 1, 3);
            Assert.AreEqual(facade, 1);
        }

        [Test]
        public void TestConvertGramPerGramMolToPoundPerPoundMol()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMolecularWeight(1, 2, 3);
            Assert.AreEqual(facade, 1);
        }

        #endregion

        #region MomentumUnitTest

        [Test]
        public void TestKilogramPerMeterSquaredSecondToPoundPerFeetSquaredSecond()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMomentumUnits(1, 1, 2);
            Assert.AreEqual(Math.Round(facade, 6), 0.67205);
        }

        #endregion

        #endregion

        #region ReverseConversion

        #region LengthUnitTest

        [Test]
        public void TestReverseConvertMeterToKilometer()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 2, 1);
            Assert.AreEqual(facade, 1000);
        }
        [Test]
        public void TestReverseConvertMeterToCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 1);
            Assert.AreEqual(Math.Round(facade,3), 0.01);
        }
        [Test]
        public void TestReverseConvertMeterToMilimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 1);
            Assert.AreEqual(Math.Round(facade, 3), 0.001);
        }
        [Test]
        public void TestReverseConvertMeterToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 1);
            Assert.AreEqual(Math.Round(facade, 3), 1609.344);
        }
        [Test]
        public void TestReverseConvertMeterToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 1);
            Assert.AreEqual(Math.Round(facade, 4), 0.9144);
        }
        [Test]
        public void TestReverseConvertMeterToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 1);
            Assert.AreEqual(Math.Round(facade, 5), 0.30480);
        }
        [Test]
        public void TestReverseConvertMeterToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 1);
            Assert.AreEqual(Math.Round(facade, 2), 0.03);
        }

        [Test]
        public void TestReverseConvertKilometerToCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 3, 2);
            Assert.AreEqual(facade, 0,00001);
        }
        [Test]
        public void TestReverseConvertKilometerToMilimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 2);
            Assert.AreEqual(Math.Round(facade, 6), 0.000001);
        }
        [Test]
        public void TestReverseConvertKilometerToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 2);
            Assert.AreEqual(Math.Round(facade, 6), 1.609344);
        }
        [Test]
        public void TestReverseConvertKilometerToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 2);
            Assert.AreEqual(Math.Round(facade, 3), 0.001);
        }
        [Test]
        public void TestReverseConvertKilometerToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 2);
            Assert.AreEqual(Math.Round(facade, 7), 0.0003048);
        }
        [Test]
        public void TestReverseConvertKilometerToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 2);
            Assert.AreEqual(Math.Round(facade, 6), 0.000025);
        }

        [Test]
        public void TestReverseConvertCentimeterToMilimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 4, 3);
            Assert.AreEqual(Math.Round(facade, 1), 0.1);
        }
        [Test]
        public void TestReverseConvertCentimeterToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 3);
            Assert.AreEqual(Math.Round(facade, 1), 160934.5);
        }
        [Test]
        public void TestReverseConvertCentimeterToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 3);
            Assert.AreEqual(Math.Round(facade, 2), 91.44);
        }
        [Test]
        public void TestReverseConvertCentimeterToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 3);
            Assert.AreEqual(Math.Round(facade, 2), 30.48);
        }
        [Test]
        public void TestReverseConvertCentimeterToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 3);
            Assert.AreEqual(Math.Round(facade, 2), 2.54);
        }

        [Test]
        public void TestReverseConvertMilimeterToMile()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 5, 4);
            Assert.AreEqual(Math.Round(facade), 1609344);
        }
        [Test]
        public void TestReverseConvertMilimeterToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 4);
            Assert.AreEqual(Math.Round(facade, 1), 914.4);
        }
        [Test]
        public void TestReverseConvertMilimeterToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 4);
            Assert.AreEqual(Math.Round(facade, 1), 304.8);
        }
        [Test]
        public void TestReverseConvertMilimeterToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 4);
            Assert.AreEqual(Math.Round(facade, 1), 25.4);
        }

        [Test]
        public void TestReverseConvertMileToYards()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 6, 5);
            Assert.AreEqual(Math.Round(facade, 11), 0.0005681818);
        }
        [Test]
        public void TestReverseConvertMileToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 5);
            Assert.AreEqual(Math.Round(facade, 11), 0.00018939393);
        }
        [Test]
        public void TestReverseConvertMileToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 5);
            Assert.AreEqual(Math.Round(facade, 10), 0.0000157828);
        }

        [Test]
        public void TestReverseConvertYardsToFoot()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 7, 6);
            Assert.AreEqual(Math.Round(facade, 7), 0.3333333);
        }
        [Test]
        public void TestReverseConvertYardsToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 6);
            Assert.AreEqual(Math.Round(facade, 2), 0.03);
        }

        [Test]
        public void TestReverseConvertFootToInch()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertLength(1, 8, 7);
            Assert.AreEqual(Math.Round(facade, 7), 0.0833333);
        }


        #endregion

        #region TemperatureUnitTest

        [Test]
        public void TestReverseConvertCelsiusToKelvin()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertTemperature(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 3), -272.15);
        }
        [Test]
        public void TestReverseConvertCelsiusToFahrenheit()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertTemperature(1, 3, 1);
            Assert.AreEqual(Math.Round(facade, 2), -17.22);
        }

        [Test]
        public void TestReverseConvertKelvinToFahrenheit()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertTemperature(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 2), 255.93);
        }

        //[Test]
        //public void TestReverseConvertCelsiusToRankine()
        //{
        //    SDTConverter c = new SDTConverter();
        //    var facade = c.ConvertTemperature(1, 4, 1);
        //    Assert.AreEqual(Math.Round(facade, 3), -272.594);
        //}

        //[Test]
        //public void TestReverseConvertKelvinToRankine()
        //{
        //    SDTConverter c = new SDTConverter();
        //    var facade = c.ConvertTemperature(1, 4, 2);
        //    Assert.AreEqual(Math.Round(facade, 5), 0.55556);
        //}

        //[Test]
        //public void TestReverseConvertFahrenheitToRankine()
        //{
        //    SDTConverter c = new SDTConverter();
        //    var facade = c.ConvertTemperature(1, 4, 3);
        //    Assert.AreEqual(Math.Round(facade, 3), -458.67);
        //}
        #endregion

        #region VolumeUnitTest

        [Test]
        public void TestReverseConvertLiterToUSGallon()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolume(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 3), 3.785);
        }

        #endregion

        #region WeightUnitTest

        [Test]
        public void TestReverseConvertKilogramToGram()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 3), 0.001);
        }
        [Test]
        public void TestReverseConvertKilogramToMiligram()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 3, 1);
            Assert.AreEqual(Math.Round(facade, 6), 0.000001);
        }
        [Test]
        public void TestReverseConvertKilogramToPound()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 4, 1);
            Assert.AreEqual(Math.Round(facade, 5), 0.45359);
        }
        [Test]
        public void TestReverseConvertKilogramToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 5, 1);
            Assert.AreEqual(Math.Round(facade, 9), 0.028349523);
        }

        [Test]
        public void TestReverseConvertGramToMiligram()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 3), 0.001);
        }
        [Test]
        public void TestReverseConvertGramToPound()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 4, 2);
            Assert.AreEqual(Math.Round(facade, 3), 453.592);
        }
        [Test]
        public void TestReverseConvertGramToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 5, 2);
            Assert.AreEqual(Math.Round(facade, 5), 28.34952);
        }

        [Test]
        public void TestReverseConvertMiligramToPound()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 4, 3);
            Assert.AreEqual(Math.Round(facade, 1), 453592.4);
        }
        [Test]
        public void TestReverseConvertMiligramToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 5, 3);
            Assert.AreEqual(Math.Round(facade, 3), 28349.523);
        }

        [Test]
        public void TestReverseConvertPoundToOunce()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertWeight(1, 5, 4);
            Assert.AreEqual(facade, 0.0625);
        }

        #endregion

        #region MassDensityUnitTest

        [Test]
        public void TestReverseConvertKilogramPerCubicMeterToGramPerCubicCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassDensity(1, 2, 1);
            Assert.AreEqual(facade, 1000);
        }
        [Test]
        public void TestReverseConvertKilogramPerCubicMeterToPoundPerCubicFeet()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassDensity(1, 3, 1);
            Assert.AreEqual(Math.Round(facade, 2), 16,02);
        }

        [Test]
        public void TestReverseConvertGramPerCubicCentimeterToPoundPerCubicFeet()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassDensity(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 9), 0,016018463);
        }

        #endregion

        #region MassFlowRateUnitTest

        [Test]
        public void TestReverseConvertKilogramPerSecondToKilogramPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 2, 1);
            Assert.AreEqual(Math.Round(facade,6), 0.000278);
        }
        [Test]
        public void TestReverseConvertKilogramPerSecondToPoundPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 3, 1);
            Assert.AreEqual(Math.Round(facade, 6), 0.453592);
        }
        [Test]
        public void TestReverseConvertKilogramPerSecondToPoundPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 4, 1);
            Assert.AreEqual(Math.Round(facade, 9), 0.000125998);
        }

        [Test]
        public void TestReverseConvertKilogramPerHourToPoundPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 2), 1632.93);
        }
        [Test]
        public void TestReverseConvertKilogramPerHourToPoundPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 4, 2);
            Assert.AreEqual(Math.Round(facade, 6), Math.Round(0.453592,6));
        }

        [Test]
        public void TestReverseConvertPoundPerSecondToPoundPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertMassFlowRate(1, 4, 3);
            Assert.AreEqual(Math.Round(facade,10), Math.Round(0.000277777777778,10));
        }

        #endregion

        #region SurfaceTensionUnitTest

        [Test]
        public void TestReverseConvertNewtonPerMeterToDynePerCentimeter()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertSurfaceTension(1, 2, 1);
            Assert.AreEqual(Math.Round(facade,4), Math.Round(0.001,4));
        }

        #endregion

        #region VelocityUnitTest

        [Test]
        public void TestReverseConvertMeterPerSecondToFeetPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVelocity(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 4), Math.Round(0.3048,4));
        }

        #endregion

        #region VolumeFlowRateUnitTest

        [Test]
        public void TestReverseConvertCubicMeterPerSecondToCubicFeetPerSecond()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 5), Math.Round(0.028316847,5));
        }
        [Test]
        public void TestReverseConvertCubicMeterPerSecondToCubicMeterPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 3, 1);
            Assert.AreEqual(Math.Round(facade,8), Math.Round(0.000277777777778,8));
        }

        [Test]
        public void TestReverseConvertCubicFeetPerSecondToCubicMeterPerHour()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 5), Math.Round(0.009809,5));
        }

        [Test]
        public void TestConverseConvertCubicMeterPerSecondToGallonPerMinute()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 4, 1);
            Assert.AreEqual(Math.Round(facade, 8), 0.00006309);
        }
        [Test]
        public void TestConverseConvertCubicFeetPerSecondToGallonPerMinute()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 4, 2);
            Assert.AreEqual(Math.Round(facade, 6), 0.002228);
        }

        [Test]
        public void TestConverseConvertCubicMeterPerHourToGallonPerMinute()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertVolumeFlowRate(1, 4, 3);
            Assert.AreEqual(Math.Round(facade, 4), 0.2271);
        }

        #endregion

        #region ViscosityUnitTest

        [Test]
        public void TestReverseConvertKilogramPerMeter_SecondToPascal_Second()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 2, 1);
            Assert.AreEqual(facade, 1);
        }
        [Test]
        public void TestReverseConvertKilogramPerMeter_SecondToPoundPerFeet_Second()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 3, 1);
            Assert.AreEqual(Math.Round(facade, 3), 1.488);
        }
        [Test]
        public void TestReverseConvertKilogramPerMeter_SecondToCentipoise()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 4, 1);
            Assert.AreEqual(Math.Round(facade,4), 0.001);
        }

        [Test]
        public void TestReverseConvertPascal_SecondToPoundPerFeet_Second()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 3), 1.488);
        }
        [Test]
        public void TestReverseConvertPascal_SecondToCentipoise()
        {
            SDTConverter c = new SDTConverter();
            var facade = c.ConvertViscosity(1, 4, 2);
            Assert.AreEqual(Math.Round(facade,4), 0.001);
        }

        [Test]
        public void TestReverseConvertPoundPerFeet_SecondToCentipoise()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertViscosity(1, 4, 3);
            Assert.AreEqual(Math.Round(facade, 6), 0.000672);
        }

        #endregion

        #region PressureUnitTest

        [Test]
        public void TestReverseConvertPascalToPoundPerSquareInch()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertPressure(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 4), 6894.7573);
        }

        [Test]
        public void TestReverseConvertPascalToBar()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertPressure(1, 3, 1);
            Assert.AreEqual(facade, 100000);
        }

        [Test]
        public void TestReverseConvertPoundPerSquareInchToBar()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertPressure(1, 3, 2);
            Assert.AreEqual(Math.Round(facade, 6), 14.503774);
        }

        #endregion

        #region MolecularWeightUnitTest

        [Test]
        public void TestReverseConvertKilogramPerKilogramMolToGramPerGramMol()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMolecularWeight(1, 2, 1);
            Assert.AreEqual(facade, 1);
        }

        [Test]
        public void TestReverseConvertKilogramPerKilogramMolToPoundPerPoundMol()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMolecularWeight(1, 3, 1);
            Assert.AreEqual(facade, 1);
        }

        [Test]
        public void TestReverseConvertGramPerGramMolToPoundPerPoundMol()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMolecularWeight(1, 3, 2);
            Assert.AreEqual(facade, 1);
        }

        #endregion

        #region MomentumUnitTest

        [Test]
        public void TestReverseKilogramPerMeterSquaredSecondToPoundPerFeetSquaredSecond()
        {
            SDTConverter c = new SDTConverter();
            double facade = c.ConvertMomentumUnits(1, 2, 1);
            Assert.AreEqual(Math.Round(facade, 3), 1.488);
        }

        #endregion

        #endregion

    }
}
