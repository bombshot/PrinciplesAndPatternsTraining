namespace SOLID.Assessment.After
{
    public class MedicalDevice : Device
    {
        public int HeartRate { get; set; }
        public MedicalDevice(int deviceId) : base(deviceId)
        {
        }

        public override string GetValue()
        {
            return HeartRate.ToString();
        }

        public override string DeviceType => "Medical";
    }
}
