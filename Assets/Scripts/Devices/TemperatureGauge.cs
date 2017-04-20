using System;
using System.Collections.Generic;

using UnityEngine;
using System.Linq;
using System.Text;

namespace SmartHome.Devices.Virtual
{
    public class TemperatureGauge : SmartDevice
    {
        private enum TempUnits
        {
            Farenheight,
            Celsius
        }

        private TempUnits tempUnits;
        private float InternalTemperature;
        private float ExternalTemperature;

        void Start()
        {
            tempUnits = TempUnits.Farenheight;
            InternalTemperature = 75;
            ExternalTemperature = 82;
        }

        public float tempConversion(float temp, bool FToC)
        {
            if (FToC) // Farenheight to Celsius
                return (temp - 32) / (float)1.8;
            else // Celsius to Farenheight
                return temp * (float)1.8 + 32;
        }

        public void SetInternalTemparature(float temp)
        {
            if (tempUnits == TempUnits.Farenheight)
                InternalTemperature = temp;
            else
                InternalTemperature = tempConversion(temp, false);
        }

        public void SetExternalTemparature(float temp)
        {
            if (tempUnits == TempUnits.Farenheight)
                ExternalTemperature = temp;
            else
                ExternalTemperature = tempConversion(temp, false);
        }

        public void SetTempUnit(char t)
        {
            if (t == 'f' || t == 'F')
                tempUnits = TempUnits.Farenheight;
            else if (t == 'c' || t == 'C')
                tempUnits = TempUnits.Celsius;
            else
                Console.WriteLine("Enter either F or C for the temperature unit");
        }

        public float GetInternalTemperature()
        {
            if (tempUnits == TempUnits.Farenheight)
                return InternalTemperature;
            else
                return tempConversion(InternalTemperature,true);
        }

        public float GetExternalTemperature()
        {
            if (tempUnits == TempUnits.Farenheight)
                return ExternalTemperature;
            else
                return tempConversion(ExternalTemperature,true);
        }

        public string GetTempUnit()
        {
            if (tempUnits == TempUnits.Farenheight)
                return "F°";
            else
                return "C°";

        }

    }
	
}
