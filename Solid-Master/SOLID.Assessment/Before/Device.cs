/**
* Refactor the Device class to respect SOLID principles and patterns. 
* What happens if a new device type needs to be supported such as Automotive, or if we need to support more languages?
*
* You can make any change you see fit, in code or tests.
*/


using System.Collections.Generic;

namespace SOLID.Assessment.Before
{
    public class Device
    {
        public const int MEDICAL = 0;
        public const int AGRICULTURAL = 1;
        public const int REFINARY = 2;

        public int Type;
        public bool Status = true;
        public int DeviceId;

        public int SoilQuality;
        public int HeartRate;
        public int Temperature;

        public const int EN = 1;
        public const int DU = 2;

        public Device(int type, int deviceId)
        {
            this.Type = type;
            this.DeviceId = deviceId;
        }

        public void ToggleStatus()
        {
            Status = !Status;
        }

        public static string GetStatus(Device device, int language)
        {
            string onOrOff;
            string statusMessage;
            //If not english, then dutch
            if (language == EN)
            {
                statusMessage = "OnOff";
                onOrOff = device.Status ? "ON" : "OFF";
            }
            else
            {
                statusMessage = "Toestand";
                onOrOff = device.Status ? "OP" : "UIT";
            }

            switch (device.Type)
            {
                case MEDICAL:
                    return $"{statusMessage}: {onOrOff},  {device.HeartRate}";
                case AGRICULTURAL:
                    return $"{statusMessage}: {onOrOff},  {device.SoilQuality}";
                case REFINARY:
                    return $"{statusMessage}: {onOrOff},  {device.Temperature}";
            }
            return string.Empty;
        }

        public static string PrintStatus(List<Device> devices, int userLanguage)
        {
            var returnString = string.Empty;

            // test list is empty
            if (devices.Count == 0)
            {
                returnString = userLanguage == EN ? "<h1>Empty list of devices!</h1>" : "<h1>Lege lijst met apparaten!</h1>";
            }
            else
            {
                //we have devices
                //header
                if (userLanguage == EN)
                {
                    returnString += "<h1>Devices report</h1><br/>";
                }
                else 
                {
                    // default is dutch
                    returnString += "<h1>Apparaten Report</ h1><br/>";
                }

                var numberMedical = 0;
                var numberAgricultural = 0;
                var numberRefinaries = 0;

                //Get all statuses
                foreach (Device device in devices)
                {
                    if (device.Type == MEDICAL)
                    {
                        numberMedical++;
                        returnString += $"<BR/> Device ID: {device.DeviceId};{GetStatus(device, userLanguage)}<BR/>";
                    }
                    if (device.Type == AGRICULTURAL)
                    {
                        numberAgricultural++;
                        returnString += $"<BR/> Device ID: {device.DeviceId};{GetStatus(device, userLanguage)}<BR/>"; ;
                    }
                    if (device.Type == REFINARY)
                    {
                        numberRefinaries++;
                        returnString += $"<BR/> Device ID: {device.DeviceId};{GetStatus(device, userLanguage)}<BR/>"; ;
                    }
                }

                //let`s print this
                returnString += GetLine(Device.MEDICAL, userLanguage, numberMedical);
                returnString += GetLine(Device.AGRICULTURAL, userLanguage, numberAgricultural);
                returnString += GetLine(Device.REFINARY, userLanguage, numberRefinaries);

                //footer
                returnString += "TOTAL: ";
                returnString += (numberAgricultural + numberMedical + numberRefinaries) + " " +
                                (userLanguage == EN ? "devices" : "apparaten");

            }
            return returnString;
        }

        public static string GetLine(int deviceType, int userLanguage, int numberOfDevices)
        {
            if (numberOfDevices > 0)
            {
                if (userLanguage == EN)
                {
                    return $"{numberOfDevices} {TranslateDevice(deviceType, userLanguage)} devices<br/>";
                }
                return $"{numberOfDevices} {TranslateDevice(deviceType, userLanguage)} apparaten<br/>";
            }
            return string.Empty;
        }

        private static string TranslateDevice(int type, int userLanguage)
        {
            switch (type)
            {
                case MEDICAL:
                    return userLanguage == EN ? "Medical" : "Medisch";
                case AGRICULTURAL:
                    return userLanguage == EN ? "Agricultural" : "Agrarisch";
                case REFINARY:
                    return userLanguage == EN ? "Refinary" : "Raffinaderij";
            }
            return string.Empty;
        }
    }
}
