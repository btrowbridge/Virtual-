using System.Collections;
using UnityEngine;
using SmartHome.Devices;
using System.Collections.Generic;

namespace SmartHome.Systems
{

    public interface ISystem
    {
        void UpdateDevices();
    }
}