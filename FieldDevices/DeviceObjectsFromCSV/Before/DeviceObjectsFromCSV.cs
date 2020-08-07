/*using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EOODDay2.DeviceObjectsFromCSV.cs.Before
{
    struct GeoLocation
    {
        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
        }
    }

    /// This constructor initializes too many members that too with optional values
    /// Refactor this by moving to a class that is responsible for creating a SolarDevice object!
    struct SolarDevice
    {
        public SolarDevice(Guid deviceId, string name, double powerGenerationCapacity, double latitude, 
            double longitude, bool status = true, DateTime startDateTime = default(DateTime), double generatedPower = 0.0d)
        {
            DeviceId = deviceId;
            Name = name;
            PowerGenerationCapacity = powerGenerationCapacity;
            Latitude = latitude;
            Longitude = longitude; 
            Status = status;
            StartDateTime = startDateTime;
            GeneratedPower = generatedPower;
        }

        public Guid DeviceId { get; set; }
        public string Name { get; set; }
        public double PowerGenerationCapacity { get; set; }
        public double Latitude { get; }
        public double Longitude { get; }
        public bool Status { get; }
        public DateTime StartDateTime { get; }
        public double GeneratedPower { get; set; }

        public override string ToString()
        {
            return $"{nameof(DeviceId)}: {DeviceId}, {nameof(Name)}: {Name}, " +
                $"{nameof(PowerGenerationCapacity)}: {PowerGenerationCapacity}, {nameof(Latitude)}: {Latitude}, " +
                $"{nameof(Longitude)}: {Longitude}, {nameof(Status)}: {Status}, " +
                $"{nameof(StartDateTime)}: {StartDateTime}, {nameof(GeneratedPower)}: {GeneratedPower}";
        }
    }

    class DeviceObjectsFromCSV
    {
        public static List<SolarDevice> GetSolarDevicesFromCSV(string path)
        {
            Type SolarDeviceType = typeof(SolarDevice);
            ConstructorInfo[] ci = SolarDeviceType.GetConstructors();
            ConstructorInfo SolarDeviceCtor = ci[0]; // the first entry is the constructor we're looking for! 
            // now prepare the parameters
            string line = string.Empty;
            List<SolarDevice> devices = new List<SolarDevice>();
            using (var entries = new StreamReader(path))
            {
                while ((line = entries.ReadLine()) != null)
                {
                    string [] parameters = line.Split(",");
                    object [] ctorParameters = new object[parameters.Length];
                    // public SolarDevice(Guid deviceId, string name, double powerGenerationCapacity,
                    // double latitude, double longitude, bool status, DateTime startDateTime, double generatedPower)
                    ctorParameters[0] = Guid.Parse((string) parameters[0]);
                    ctorParameters[1] = parameters[1];
                    ctorParameters[2] = double.Parse(parameters[2]);
                    ctorParameters[3] = double.Parse(parameters[3]);
                    ctorParameters[4] = double.Parse(parameters[4]);
                    ctorParameters[5] = bool.Parse(parameters[5]);
                    ctorParameters[6] = DateTime.Parse(parameters[6]);
                    ctorParameters[7] = double.Parse(parameters[7]);
                    SolarDevice device = (SolarDevice) SolarDeviceCtor.Invoke(ctorParameters);
                    devices.Add(device);
                }
            }
            return devices; 
        }
    }

    class TestGetDeviceObjectsFromCSV
    {
        static void Main()
        {
            var devices = DeviceObjectsFromCSV.GetSolarDevicesFromCSV("./SolarDevices.csv");
            devices.ForEach(device => Console.WriteLine(device));
        }
    }
}*/