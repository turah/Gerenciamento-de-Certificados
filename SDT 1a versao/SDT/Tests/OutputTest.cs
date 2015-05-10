using NUnit.Framework;
using ScaredFingers.UnitsConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDTDomainModel.Enums;
using SDTBusiness.Registers;
using SDTDomainModel.Entities;

namespace Tests
{
    [TestFixture]
    class OutputTest
    {
        [Test]
        public static void SetInletDeviceMaximumMomentum_Test()
        {
            SeparatorGeometry sg = new SeparatorGeometry() { InletNozzleMaxMomentum = 0, InletDevice = InletDevices.HalfPipe };
            OutputBusinessFacade.SetInletMaximumMomentum(MeasurementUnitSystem.SI, sg);
            Assert.AreEqual(sg.InletNozzleMaxMomentum, 3000.0);

            OutputBusinessFacade.SetInletMaximumMomentum(MeasurementUnitSystem.US, sg);
            Assert.AreEqual(sg.InletNozzleMaxMomentum, 2015.0);

            //facade.SetInletMaximumMomentum(InletDevices.InletCyclones, MeasurementUnitSystem.US, sg);
            //Assert.AreEqual(sg.InletNozzleMaxMomentum, 10080.0);
        }
    }
}
