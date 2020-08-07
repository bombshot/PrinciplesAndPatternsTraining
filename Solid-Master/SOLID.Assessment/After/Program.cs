using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace SOLID.Assessment.After
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
            // Thread.CurrentThread.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

            var devices = new List<Device>
            {
                new AgriculturalDevice(1) { SoilQuaility = 30 },
                new MedicalDevice(2) {HeartRate = 75},
                new RefinaryDevice(3) {Temperature = 100}
            };

            var reportPrinter = new DeviceReportPrinter(new HtmlFormatter(), devices);

            Console.WriteLine(reportPrinter.Generate());

            Console.ReadLine();
        }
    }
}
