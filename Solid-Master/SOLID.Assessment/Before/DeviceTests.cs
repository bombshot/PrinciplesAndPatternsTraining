using NUnit.Framework;
using System.Collections.Generic;

namespace SOLID.Assessment.Before
{
    [TestFixture]
    public class DeviceTests
    {
        [Test]
        public void PrintDeviceStatusInEnglish()

        {
            List<Device> devices = new List<Device>
            {
                new Device(Device.MEDICAL, 1) {Status = false, HeartRate = 75},
                new Device(Device.AGRICULTURAL, 2) {Status = true, SoilQuality = 32},
                new Device(Device.REFINARY, 3) {Status = false, Temperature = 60}
            };

            var printStatus = Device.PrintStatus(devices, Device.EN);

            var expectedString =
                "<h1>Devices report</h1><br/><BR/> Device ID: 1;OnOff: OFF,  75<BR/><BR/> Device ID: 2;OnOff: ON,  32<BR/><BR/> Device ID: 3;OnOff: OFF,  60<BR/>1 Medical devices<br/>1 Agricultural devices<br/>1 Refinary devices<br/>TOTAL: 3 devices";

            Assert.AreEqual(expectedString, printStatus);
        }

        [Test]
        public void PrintDeviceStatusInDutch()

        {
            List<Device> devices = new List<Device>
            {
                new Device(Device.MEDICAL, 1) {Status = false, HeartRate = 75},
                new Device(Device.AGRICULTURAL, 2) {Status = true, SoilQuality = 32},
                new Device(Device.REFINARY, 3) {Status = false, Temperature = 60}
            };

            var printStatus = Device.PrintStatus(devices, Device.DU);

            var expectedString =
                "<h1>apparaten Report</ h1><br/><BR/> Device ID: 1;Toestand: UIT,  75<BR/><BR/> Device ID: 2;Toestand: OP,  32<BR/><BR/> Device ID: 3;Toestand: UIT,  60<BR/>1 Medisch apparaten<br/>1 Agrarisch apparaten<br/>1 Raffinaderij apparaten<br/>TOTAL: 3 apparaten";

            Assert.AreEqual(expectedString, printStatus);
        }

        [Test]
        public void ToggleStatus()
        {
            var device = new Device(Device.MEDICAL, 1) { Status = false, HeartRate = 75 };
            device.ToggleStatus();

            Assert.AreEqual(device.Status, true);
            device.ToggleStatus();

            Assert.AreEqual(device.Status, false);

        }

        [Test]
        public void PrintEmptyDeviceStatusInEnglish()

        {
            List<Device> devices = new List<Device>();

            var printStatus = Device.PrintStatus(devices, Device.EN);

            var expectedString = "<h1>Empty list of devices!</h1>";

            Assert.AreEqual(expectedString, printStatus);
        }


        [Test]
        public void PrintEmptyDeviceStatusInDutch()
        {
            List<Device> devices = new List<Device>();

            var printStatus = Device.PrintStatus(devices, Device.DU);

            var expectedString = "<h1>Lege lijst met apparaten!</h1>";

            Assert.AreEqual(expectedString, printStatus);
        }
    }
}
