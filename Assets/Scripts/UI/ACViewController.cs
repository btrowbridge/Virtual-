using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SmartHome.Systems.Utility;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using SmartHome.Systems;

namespace SmartHome.UI.Views
{
    public class ACViewController : MonoBehaviour
    {
        TemperatureSystem system;

        // Use this for initialization
        void Start()
        {
            system = SmartHomeController.GetSystem<TemperatureSystem>();
        }

        // Update is called once per frame
        void OnGUI()
        {


        }

        public void OnSwitchSchedule()
        {
            var gameSwitch = GameObject.Find("SwitchEnableSchedule");
            var switchState = gameSwitch.GetComponentInChildren<Switch>().isOn;

            // needs a toggle for the gameSwitch
            if (switchState == true)
            {
                // Need to call OnButtonSetSchedule Again

            }

        }

        public void OnButtonRaiseTemperature()
        {
            system.IncreaseTemperature();
        }

        public void OnButtonLowerTemperature()
        {
            system.LowerTemperature();
        }

        public void OnButtonSetSchedule()
        {
            // Toggles for the Schedule
            var checkboxBeginAM = GameObject.Find("CheckboxBeginAM");
            var beginAMstatus = checkboxBeginAM.GetComponentInChildren<Toggle>().isOn;

            var checkboxBeginPM = GameObject.Find("CheckboxBeginPM");
            var beginPMstatus = checkboxBeginPM.GetComponentInChildren<Toggle>().isOn;

            var checkboxEndAM = GameObject.Find("CheckboxEndAM");
            var endAMstatus = checkboxEndAM.GetComponentInChildren<Toggle>().isOn;

            var checkboxEndPM = GameObject.Find("CheckboxEndPM");
            var endPMstatus = checkboxEndPM.GetComponentInChildren<Toggle>().isOn;

            var textboxTemp = GameObject.Find("TextboxTemp");
            var textboxTempText = textboxTemp.GetComponentInChildren<Text>();
            var scheduleTemp = textboxTempText.text;

            // Access to Cool Toggle
            var coolToggle = GameObject.Find("CoolBtn");
            var coolToggleStatus = coolToggle.GetComponentInChildren<Toggle>().isOn;
            // Access to Heat Toggle
            var heatToggle = GameObject.Find("HeatBtn");
            var heatToggleStatus = heatToggle.GetComponentInChildren<Toggle>().isOn;

            var textboxBeginInput = GameObject.Find("TextboxBeginInput");
            var textboxBeginText = textboxBeginInput.GetComponentInChildren<Text>();
            var beginScheduleText = textboxBeginText.text;

            var textboxEndInput = GameObject.Find("TextboxEndInput");
            var textboxEndText = textboxEndInput.GetComponentInChildren<Text>();
            var endScheduleText = textboxEndText.text;

            TimeSpan eTime;
            TimeSpan bTime;
            if (TimeSpan.TryParse(beginScheduleText, out bTime) && TimeSpan.TryParse(endScheduleText, out eTime))
            {
                
                if (beginPMstatus == true)
                {
                    bTime = bTime.Add(new TimeSpan(12, 0, 0));
                }
                if (endPMstatus == true)
                {
                    eTime = eTime.Add(new TimeSpan(12, 0, 0));
                }
                ACSchedule schedule = new ACSchedule(int.Parse(scheduleTemp), true, bTime, eTime);
                system.SetSchedule(schedule);
            }
        }

        public void OnButtonAC()
        {
            //Toggle System On and Off Needs implementation
            //Schedule won't work and AC will be off but still display current temp

            var button = GameObject.Find("ButtonAC");
            var buttonText = button.GetComponentInChildren<Text>();

            if (buttonText.text == "AC ON")
            {
                // change the system state to off
                buttonText.text = "AC OFF";
            }
            else
            {
                // change the system state to on
                buttonText.text = "AC ON";
            }
        }
    }
}