using System;

namespace EOOD.DeviceCommands.Before
{
    class RemoteControlledVolumeDevice
    {
        private int _volume;
        private const int MaxVolume = 10; 
        
        public RemoteControlledVolumeDevice(int volume = 0)
        {
            if (volume > MaxVolume)
            {
                _volume = MaxVolume;
            }
            else
            {
                _volume = volume; 
            }
        }

        public int Volume
        {
            get => _volume;
            set => _volume = value; 
        }

        public void ResetVolume()
        {
            Volume = 0; 
        }

        public void SetToMaxVolume()
        {
            Volume = MaxVolume; 
        }

        public void IncreaseVolume()
        {
            if (Volume < MaxVolume)
            {
                Volume++;
            }
        }

        public void DecreaseVolume()
        {
            Volume--; 
        }
    }

    class TestDeviceCommands
    {
        static void Main()
        {
            string []commands = {"SetToMax", "Decrease"};
            RemoteControlledVolumeDevice volumeDevice = new RemoteControlledVolumeDevice(); 

            foreach (var command in commands)
            {
                DeviceCommands.ExecuteCommand(volumeDevice, command);
                Console.WriteLine($"After {command} command, volume is: {volumeDevice.Volume}");
            }
        }
    }
}