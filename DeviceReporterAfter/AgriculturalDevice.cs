namespace SOLID.Assessment.After
{
    public class AgriculturalDevice : Device
    {
        public AgriculturalDevice(int deviceId) : base(deviceId)
        {
        }

        public int SoilQuaility { get; set; }
        public override string GetValue()
        {
            return SoilQuaility.ToString();
        }

        public override string DeviceType => "Agricultural";
    }
}
