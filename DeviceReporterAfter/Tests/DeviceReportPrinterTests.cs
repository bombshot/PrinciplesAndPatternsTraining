using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace SOLID.Assessment.After.Tests
{
    [TestFixture]
    public class DeviceReportPrinterTests
    {
        private static string Print(List<Device> devices)
        {
            var formatter = new DeviceReportPrinter(new HtmlFormatter(), devices);
            return formatter.Generate();
        }

        private static List<Device> GetDevices()
        {
            return new List<Device>
            {
                GetTestAgriculturalDevice(),
                GetTestMedicalDevice(),
                GetTestRefinaryDevice()
            };
        }

        private static RefinaryDevice GetTestRefinaryDevice()
        {
            return new RefinaryDevice(3) { Temperature = 100 };
        }

        private static AgriculturalDevice GetTestAgriculturalDevice()
        {
            return new AgriculturalDevice(1) { SoilQuaility = 30 };
        }

        private static MedicalDevice GetTestMedicalDevice()
        {
            return new MedicalDevice(2) { HeartRate = 75 };
        }

        [Test]
        public void EmptyList_Should_PrintEmptyHeader()
        {
            var mockFormatter = new Mock<IFormatter>();
            Print(new List<Device>());
            mockFormatter.Verify(f => f.AppendHeader(DeviceResources.EmptyList), Times.AtMostOnce);
        }

        [Test]
        public void SingleElementList_Should_PrintNonEmptyHeader()
        {
            var device = GetTestMedicalDevice();
            var mockFormatter = new Mock<IFormatter>();
            Print(new List<Device> { device });
            mockFormatter.Verify(f => f.AppendHeader(DeviceResources.DeviceReport), Times.AtMostOnce);
        }

        [Test]
        public void NonEmptyList_Should_PrintBody()
        {
            var device = GetTestMedicalDevice();
            var mockFormatter = new Mock<IFormatter>();
            Print(new List<Device> { device });
            mockFormatter.Verify(f => f.AppendBodyElement(device.DeviceType, "1"), Times.AtMostOnce);
            mockFormatter.Verify(
                f => f.AppendBodyElement(DeviceResources.DeviceID, device.DeviceId.ToString(), device.GetValue()), Times.AtMostOnce);
            mockFormatter.Verify(
                f => f.AppendBodyElement(DeviceResources.DeviceID, device.DeviceId.ToString(), device.GetValue()), Times.AtMostOnce);
            mockFormatter.Verify(f => f.AppendBodyElement(DeviceResources.Total, "1"), Times.AtMostOnce);
        }

        [Test]
        public void MultipleElementList_Should_PrintBody()
        {
            var devices = GetDevices();
            var refineryDevice = (RefinaryDevice)devices[2];
            var medicalDevice = (MedicalDevice)devices[1];
            var agriDevice = (AgriculturalDevice)devices[0];
            var mockFormatter = new Mock<IFormatter>();
            Print(devices);
            mockFormatter.Verify(f => f.AppendBodyElement(refineryDevice.DeviceType, "1"), Times.AtMostOnce);
            mockFormatter.Verify(f => f.AppendBodyElement(agriDevice.DeviceType, "1"), Times.AtMostOnce);
            mockFormatter.Verify(f => f.AppendBodyElement(medicalDevice.DeviceType, "1"), Times.AtMostOnce);

            mockFormatter.Verify(
                f => f.AppendBodyElement(DeviceResources.DeviceID, refineryDevice.DeviceId.ToString(), refineryDevice.GetValue()), Times.AtMostOnce);
            mockFormatter.Verify(
                f => f.AppendBodyElement(DeviceResources.DeviceID, medicalDevice.DeviceId.ToString(), medicalDevice.GetValue()), Times.AtMostOnce);
            mockFormatter.Verify(
                f => f.AppendBodyElement(DeviceResources.DeviceID, agriDevice.DeviceId.ToString(), agriDevice.GetValue()), Times.AtMostOnce);

            mockFormatter.Verify(f => f.AppendBodyElement(DeviceResources.Total, "3"), Times.AtMostOnce);
        }

        [Test]
        public void EmptyList_Should_NotPrintBody()
        {
            var mockFormatter = new Mock<IFormatter>();
            Print(new List<Device>());
            mockFormatter.Verify(f => f.AppendBodyElement("", ""), Times.Never());
        }
    }
}
