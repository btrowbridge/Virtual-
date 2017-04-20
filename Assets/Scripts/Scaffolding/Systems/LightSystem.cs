using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SmartHome.Devices.Virtual;
using SmartHome.Devices;
using System.Linq;
using System;

namespace SmartHome.Systems
{
    public class LightSystem : ISystem
    {
        private List<LightFixture> lights;

        public List<LightFixture> Lights
        {
            get
            {
                return lights;
            }
        }

        public LightSystem()
        {
            UpdateDevices();
        }

        public LightFixture GetLight(string name)
        {
            return lights.Where(cameras => cameras.DevInfo.Name == name).First();
        }

        public List<SmartDevice> GetGroup(string groupName) //Radios and tvs of same group
        {
            return DeviceHelper.GetGroupFromDeviceLists(groupName, lights.Cast<SmartDevice>().ToList());
        }

        public void AddDevicesToGroup(List<string> deviceNames, string groupName)
        {
            DeviceHelper.AddDevicesFromListsToGroup(deviceNames, groupName, lights.Cast<SmartDevice>().ToList());
        }
        public List<string> GetDeviceNames()
        {
            return DeviceHelper.GetDeviceNames(lights.Cast<SmartDevice>().ToList());
        }
        public List<string> GetGroupNames()
        {
            return DeviceHelper.GetGroupNames(lights.Cast<SmartDevice>().ToList());
        }


        public List<string> GetNamesFromGroup(string groupName)
        {
            return DeviceHelper.GetDeviceNamesFromGroup(groupName, lights.Cast<SmartDevice>().ToList());
        }
        public List<string> GetNamesFromGroups(List<string> groupNames)
        {
            return DeviceHelper.GetDeviceNamesFromGroups(groupNames, lights.Cast<SmartDevice>().ToList());
        }
        public void UpdateDevices()
        {
            lights = GameObject.FindObjectsOfType<LightFixture>().ToList();
        }
        
    }
}
