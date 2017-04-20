



using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SmartHome.Devices.Virtual;
using SmartHome.Devices;
using System;

namespace SmartHome.Systems
{
    public class SecuritySystem : ISystem
    {
        private List<SecurityCamera> cameras;
        private List<MotionSensor> motionSensors;

        public List<SecurityCamera> Cameras
        {
            get
            {
                return cameras;
            }
        }

        public List<MotionSensor> MotionSensors
        {
            get
            {
                return motionSensors;
            }
        }

        public SecuritySystem()
        {
            cameras = GameObject.FindObjectsOfType<SecurityCamera>().ToList();
            motionSensors = GameObject.FindObjectsOfType<MotionSensor>().ToList();
        }

        public void UpdateDevices()
        {
            cameras = GameObject.FindObjectsOfType<SecurityCamera>().ToList();
            motionSensors = GameObject.FindObjectsOfType<MotionSensor>().ToList();
        }

        public MotionSensor GetMotionSensor(string name)
        {
            return motionSensors.Where(ms => ms.DevInfo.Name == name).First();
        }

        public SecurityCamera GetCamera(string name)
        {
            return cameras.Where(cameras => cameras.DevInfo.Name == name).First();
        }

        public List<SmartDevice> GetGroup(string groupName) //Radios and tvs of same group
        {
            return DeviceHelper.GetGroupFromDeviceLists(groupName, cameras.Cast<SmartDevice>().ToList(), motionSensors.Cast<SmartDevice>().ToList());
        }

        public void AddDevicesToGroup(List<string> deviceNames, string groupName)
        {
            DeviceHelper.AddDevicesFromListsToGroup(deviceNames, groupName, cameras.Cast<SmartDevice>().ToList(), motionSensors.Cast<SmartDevice>().ToList());
        }
    }
}
