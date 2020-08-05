
namespace SOLID.Assessment.After
{
    public abstract class Device
    {
        protected Device(int deviceId)
        {
            DeviceId = deviceId;
        }

        public bool OnOff { get; private set; }

        public int DeviceId { get; }

        public abstract string DeviceType { get; }

        public virtual void ToggleStatus()
        {
            OnOff = !OnOff;
        }

        public abstract string GetValue();
    }
}