



using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using SmartHome.Devices.Virtual;

namespace SmartHome.Systems
{
    using Utility;

    public class TemperatureSystem : ISystem
    {
        List<TemperatureGauge> thermostats;
        ACSchedule thermostatSchedule;
        TemperatureGauge mainTherm;

        public TemperatureSystem()
        {
            thermostats = GameObject.FindObjectsOfType<TemperatureGauge>().ToList() ;
            thermostatSchedule = new ACSchedule(GetInternalTemperature(), false, new TimeSpan(9, 0, 0), new TimeSpan(16, 0, 0));
        }
        public void IncreaseTemperature()
        {
            mainTherm.SetInternalTemparature(mainTherm.GetInternalTemperature() + 1);
        }
        public float GetInternalTemperature()
        {
            if (thermostats.Count <= 0)
            {
                return 75;
            }
            else
            {
                return thermostats.Average(therm => therm.GetInternalTemperature());
            }
        }
        public void LowerTemperature()
        {
            mainTherm.SetInternalTemparature(mainTherm.GetInternalTemperature() - 1);
        }

        public void SetSchedule(ACSchedule schedule)
        {
            thermostatSchedule = schedule;
        }

        public void UpdateDevices()
        {
            thermostats = GameObject.FindObjectsOfType<TemperatureGauge>().ToList();
        }
    }
}