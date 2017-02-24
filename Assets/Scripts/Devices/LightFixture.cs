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

        public bool isOn;
        public bool motionActivated;

        public float intensity;
        public Color color;
        public LightType lightType;
        public LightShape lightShape;

        private Light lightComponent;
        
        void Start()
        {
            lightComponent = GetComponent<Light>();
            lightComponent.color = color;
            lightComponent.intensity = intensity;
        }

        void TurnOn(bool isOn)
        {

        }
    }

}