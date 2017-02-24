using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHomeSystems;

namespace SmartDevices
{
    class TemperatureGauge : ISmartDevice<TemperatureSystem>
    {
        public enum TempUnits
        {
            Farenheight,
            Celsius
        }
        public float InternalTemperature;
        public float ExternalTemperature;
    }
}
