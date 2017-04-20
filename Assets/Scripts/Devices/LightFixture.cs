using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SmartHome.Systems;


namespace SmartHome.Devices.Virtual
{

    [RequireComponent(typeof(Light))]
    public class LightFixture : SmartDevice
    {

        private bool isOn;

        private float intensity;
        private float range;
        private UnityEngine.Color color;


        private Light lightComponent;
        
        void Start()
        {
            this.DevInfo = new DeviceInfo(this.GetType(), SH_SystemType.Lighting);

            lightComponent = this.gameObject.GetComponentInChildren<Light>();
        }

        //SETTERS

        public void SetEnable(bool on)
        {
            isOn = on;
            lightComponent.enabled = isOn;
        }


        public void SetIntensity(float intensity)
        {
            lightComponent.intensity = intensity/20;
        }

        public void SetColor(Color col)
        {
            color = col;
            lightComponent.color = color;
        }

        public Color GetColor()
        {
            return color;
        }

        public bool GetEnable()
        {
            return isOn;
        }

        public float GetIntensity()
        {
            return intensity;
        }
        

    }

}