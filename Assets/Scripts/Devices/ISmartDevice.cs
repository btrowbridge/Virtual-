using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SmartHomeSystems;

namespace SmartDevices
{
    public abstract class ISmartDevice<TSystem> : MonoBehaviour where TSystem : ISystem
    {

        public bool isEnabled;

        Guid deviceID;
        public Guid DeviceGUID { get { return deviceID; } }


        void Start()
        {
            if (deviceID == Guid.Empty)
            {
                deviceID = new Guid();
            }
        }

    }
}