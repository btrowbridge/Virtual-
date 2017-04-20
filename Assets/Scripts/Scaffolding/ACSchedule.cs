using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SmartHome.Systems.Utility
{
    public class ACSchedule
    {

        private float scheduleTemperature;
        private bool scheduleOn = false;
        private TimeSpan startTime;
        private TimeSpan endTime;

        public ACSchedule(float temp, bool status, TimeSpan start, TimeSpan end)
        {
            scheduleTemperature = temp;
            scheduleOn = status;
            startTime = start;
            endTime = end;
        }

        public TimeSpan EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }

        public TimeSpan StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public bool ScheduleOn
        {
            get
            {
                return scheduleOn;
            }

            set
            {
                scheduleOn = value;
            }
        }

        public float ScheduleTemperature
        {
            get
            {
                return scheduleTemperature;
            }

            set
            {
                scheduleTemperature = value;
            }
        }
    }
}