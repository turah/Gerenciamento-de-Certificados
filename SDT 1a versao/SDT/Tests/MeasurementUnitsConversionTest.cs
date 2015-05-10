using NUnit.Framework;
using ScaredFingers.UnitsConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDTDomainModel.Enums;

namespace Tests
{
    [TestFixture]
    class MeasurementUnitsConversionTest
    {
        [Test]
        public static void LenghtConverterCalculationOfKVesselTest()
        {
            SDTConverter converter = new SDTConverter();
            double output = converter.ConvertLength(1.25, (int)LengthUnit.Meter, (int)LengthUnit.Centimeter);
            Assert.AreEqual(output, 125);
        }
    }
}
