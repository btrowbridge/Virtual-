using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHome.Systems;

namespace SmartHome.Devices
{
    public class DeviceInfo
    {
        

        private string name;
        private string groupName;
        private SH_SystemType system;
        private Type deviceType;

        internal DeviceInfo(Type aType, string aName, string aGroupName = "Default", SH_SystemType aSystem = SH_SystemType.Default)
        {
            deviceType = aType;
            name = aName;
            groupName = aGroupName;
            system = aSystem;
        }
        internal DeviceInfo(Type aType, SH_SystemType aSystem = SH_SystemType.Default)
        {
            deviceType = aType;
            name = aType.Name + "_" + Guid.NewGuid();
            groupName = "Default Group";
            system = aSystem;
        }
        internal DeviceInfo(Type aType)
        {
            deviceType = aType;
            name = aType.ToString() + "_" + Guid.NewGuid();
            groupName = "Default Group";
            system = SH_SystemType.Default;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }

        public SH_SystemType System
        {
            get
            {
                return system;
            }
        }

        public Type DeviceType
        {
            get
            {
                return deviceType;
            }
        }
    }
}

