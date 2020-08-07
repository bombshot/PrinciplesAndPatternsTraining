using System;

namespace EOODDay2.DeviceCreation.Before
{
    struct GeoLocation
    {
        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        public override string ToString()
        {
            return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
        }
    }

    /// This constructor initializes too many members that too with optional values
    /// Refactor this by moving to a class that is responsible for creating a SolarDevice object!
    struct SolarDevice
    {
        public SolarDevice(Guid deviceId, string name, double powerGenerationCapacity, GeoLocation location, bool status = true, DateTime startDateTime = default(DateTime), double generatedPower = 0.0d)
        {
            DeviceId = deviceId;
            Name = name;
            PowerGenerationCapacity = powerGenerationCapacity;
            Location = location;
            Status = status;
            StartDateTime = startDateTime;
            GeneratedPower = generatedPower;
        }

        public Guid DeviceId { get; set; }
        public string Name { get; set; }
        public double PowerGenerationCapacity { get; set; }
        public GeoLocation Location { get; }
        public bool Status { get; }
        public DateTime StartDateTime { get; }
        public double GeneratedPower { get; set; }

        public override string ToString()
        {
            return $"{nameof(DeviceId)}: {DeviceId}, {nameof(Name)}: {Name}, " +
                   $"{nameof(PowerGenerationCapacity)}: {PowerGenerationCapacity}, " +
                   $"{nameof(Location)}: {Location}, {nameof(Status)}: {Status}, {nameof(StartDateTime)}: {StartDateTime}," +
                   $" {nameof(GeneratedPower)}: {GeneratedPower}";
        }
    }
}