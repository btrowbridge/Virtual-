

using System;
using SmartHome.Devices;
using SmartHome.Devices.Virtual;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace SmartHome.Systems
{
    public class ApplianceSystem : ISystem
    {
        private List<SmartTV> TVs = new List<SmartTV>();
        private List<RadioBehavior> radios = new List<RadioBehavior>();

        public void UpdateDevices()
        {
            TVs = GameObject.FindObjectsOfType<SmartTV>().ToList();
            radios = GameObject.FindObjectsOfType<RadioBehavior>().ToList();
        }

        public SmartTV GetTV(string name)
        {
            return TVs.Where(tv => tv.DevInfo.Name == name).First() ;
        }

        public RadioBehavior GetRadio(string name)
        {
            return radios.Where(radio => radio.DevInfo.Name == name).First();
        }

        public List<SmartDevice> GetGroup(string groupName) //Radios and tvs of same group
        {
            return DeviceHelper.GetGroupFromDeviceLists(groupName, TVs.Cast<SmartDevice>().ToList(), radios.Cast<SmartDevice>().ToList());
        }

        public void AddDevicesToGroup(List<string> deviceNames, string groupName)
        {

            DeviceHelper.AddDevicesFromListsToGroup(deviceNames, groupName, TVs.Cast<SmartDevice>().ToList(), radios.Cast<SmartDevice>().ToList());

        }
    }
}