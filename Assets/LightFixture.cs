using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SmartHomeSystems;

namespace SmartDevices
{
    class LightFixture : ISmartDevice<LightSystem>
    {
        public enum LightType
        {
            Incandescent,
            Flourescent,
            LED,
        }

        public enum LightShape
        {
            Normal,
            Flood,
            Tube
        }



        public float intensity;
        public Color color;
        public LightType lightType;
        public LightShape lightShape;

    }

}