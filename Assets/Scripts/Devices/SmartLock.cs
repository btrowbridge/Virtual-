using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartHome.Systems;

namespace SmartHome.Devices.Virtual
{
    public class SmartLock : SmartDevice
    {
        public enum LockType
        {
            Door,
            Window
        }

        public void Start()
        {
            this.DevInfo = new DeviceInfo(this.GetType(), DevInfo.Name, DevInfo.GroupName, SH_SystemType.Security);

        }
        public LockType lockType;

        private bool IsLocked;

        public void SetLock(bool isLocked)
        {
            IsLocked = isLocked;
            //lockDoors
        }
    }
}