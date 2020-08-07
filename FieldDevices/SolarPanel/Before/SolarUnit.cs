/*using System;
using System.Collections.Generic;

namespace EOOD.SolarPanel.Before
{
    class SolarUnit 
    {
        public Guid DeviceId { get; private set; }
        public string DeviceName { get; set; }
        
        private List<SolarPanel> panels = new List<SolarPanel>();
        private List<SolarUnit> units = new List<SolarUnit>(); 
        
        public SolarUnit(Guid deviceId, string deviceName, 
            List<SolarPanel> panels = null, List<SolarUnit> units = null)
        {
            this.DeviceId = deviceId;
            this.DeviceName = deviceName;
            if (panels != null)
            {
                this.panels = panels;
            }

            if (units != null)
            {
                this.units = units;
            }
        }

        public void AddUnits(SolarUnit unit)
        {
            units.Add(unit);
        }
        
        public void AddPanels(SolarPanel panel)
        {
            panels.Add(panel);
        }
        
        public  float PowerGenerationCapacity()
        {
            float capacity = 0;
            foreach (var panel in panels)
            {
                capacity += panel.GenerationCapacity(); 
            }

            foreach (var unit in units)
            {
                capacity += unit.PowerGenerationCapacity(); 
            }

            return capacity; 
        }
    }

    class SolarPanel
    {
        public Guid DeviceId { get; private set; }
        public string DeviceName { get; set; }
        public float Capacity { get; set; }
        public SolarUnit ParentUnit { get; set; }
        
        public SolarPanel(Guid deviceId, string deviceName, float capacity, SolarUnit parentUnit)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            Capacity = capacity;
            ParentUnit = parentUnit; 
        }

        public float GenerationCapacity()
        {
            return Capacity; 
        }

        public SolarUnit GetParentSolarUnit()
        {
            return ParentUnit; 
        }
    }
    
    class Test
    {
        public static void Main()
        {
            var smallUnit = new SolarUnit(Guid.NewGuid(), "SU001");
            List<SolarPanel> panels = new List<SolarPanel>{
                new SolarPanel(Guid.NewGuid(), "P01", 100, smallUnit),
                new SolarPanel(Guid.NewGuid(), "P02", 93, smallUnit)}; 
            panels.ForEach(panel => smallUnit.AddPanels(panel));
            
            var anotherUnit = new SolarUnit(Guid.NewGuid(), "SU002");
            List<SolarPanel> anotherPanels = new List<SolarPanel>{
                new SolarPanel(Guid.NewGuid(), "P04", 60, anotherUnit),
                new SolarPanel(Guid.NewGuid(), "P05", 67, anotherUnit)}; 
            anotherPanels.ForEach(panel => anotherUnit.AddPanels(panel));
            
            smallUnit.AddUnits(anotherUnit);
            Console.WriteLine(smallUnit.PowerGenerationCapacity());
        }
    }
}*/