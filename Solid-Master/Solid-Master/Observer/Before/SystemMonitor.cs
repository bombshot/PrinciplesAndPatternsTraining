﻿using System;

namespace Solid_Master.Observer.Before
{
    public class CloudVm
    {
        private int _cpuPercentageConsumed;

        public CloudVm(int cpuThreshold)
        {
            CpuThreshold = cpuThreshold;
        }

        public int CpuThreshold { get; }

        public event EventHandler<CloudVmEventArgs> CpuThresholdExceeded;

        public void ConsumeCpu(int cpu)
        {
            if (CpuThresholdExceeded != null && _cpuPercentageConsumed + cpu >= CpuThreshold)
            {
                CpuThresholdExceeded(this, new CloudVmEventArgs(_cpuPercentageConsumed));
            }
            else
            {
                _cpuPercentageConsumed += cpu;
            }
        }
    }

    public class CloudVmEventArgs : EventArgs
    {
        public CloudVmEventArgs(int cpuPercentage)
        {
            CpuPercentage = cpuPercentage;
        }

        public int CpuPercentage { get; }
    }

    class ObserverMain
    {
        public static void Main()
        {
            var threshold = 75;
            var vm = new CloudVm(threshold);
            vm.CpuThresholdExceeded +=
                (s, e) =>
                {
                    Console.WriteLine($"CPU threshold of {threshold} exceeded!");
                };
            for (int i = 0; i < 10; i++)
            {
                vm.ConsumeCpu(10);
            }
            Console.ReadLine();
        }

    }
}