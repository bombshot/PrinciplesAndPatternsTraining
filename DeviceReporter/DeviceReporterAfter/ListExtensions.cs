using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;


namespace SOLID.Assessment.After
{
    public static class ListExtensions
    {
        public static void ForEachDeviceType<T>(this IList<T> sequence, Action<Tuple<string, int>> task)
            where T : Device
        {
            sequence.GroupBy(
                item => item.DeviceType,
                (type, count) => Tuple.Create(type, type.Count()))
            .ForEach(task);
        }
    }
}
