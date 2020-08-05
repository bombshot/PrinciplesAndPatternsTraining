namespace SOLID.Assessment.After
{
    class RefinaryDevice : Device
    {
        public int Temperature { get; set; }

        public RefinaryDevice(int deviceId) : base(deviceId)
        {
        }

        public override string GetValue()
        {
            return Temperature.ToString();
        }

        public override string DeviceType => "Refinary";
    }
}
