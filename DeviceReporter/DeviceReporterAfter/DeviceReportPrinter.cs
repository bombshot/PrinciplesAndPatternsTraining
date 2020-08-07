using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;

namespace SOLID.Assessment.After
{
    public class DeviceReportPrinter
    {
        private readonly IFormatter _formatter;
        private readonly IList<Device> _devices;

        public DeviceReportPrinter(IFormatter formatter, IList<Device> devices)
        {
            _formatter = formatter;
            _devices = devices;
        }

        public string Generate()
        {
            //Header
            _formatter.AppendHeader(_devices.Count == 0 ? DeviceResources.EmptyList : DeviceResources.DeviceReport);

            //Device Status
            _devices.ForEach(device =>
                _formatter.AppendBodyElement(DeviceResources.DeviceID, device.DeviceId.ToString(), device.GetValue()));

            //Device Counts grouped by type
            _devices.GroupBy(device => device.DeviceType)
                .ForEach(item => _formatter.AppendBodyElement(item.Key, item.Count().ToString()));

            //_devices.ForEachDeviceType(tuple => _formatter.AppendBodyElement(DeviceResources.Device, tuple.Item1, tuple.Item2.ToString()));
            
            // Total (Footer)
            _formatter.AppendBodyElement(DeviceResources.Total, _devices.Count.ToString());

            return _formatter.ToReportString();
        }
    }
}