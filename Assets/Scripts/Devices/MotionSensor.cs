using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHomeSystems;

namespace SmartDevices {
    class MotionSensor : ISmartDevice<SecuritySystem>
    {
        public enum DetectionShape
        {
            Line,
            Cone,
            Sphere
        }

        public float range;
    }

}