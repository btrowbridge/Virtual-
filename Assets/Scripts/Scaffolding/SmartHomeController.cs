using System.Collections.Generic;
using Utility;
using SmartHome.Systems;
using System;
using System.Linq;
namespace SmartHome
{

    //Namespace Declaration

    //namespace Core
    //{
    //    using{Devices,Systems}
    //}
    namespace Devices
    {
        namespace Virtual { }
        namespace Physical { }
    }
    namespace UI
    {
        namespace Views { }
        namespace Utility { }
    }
    namespace Systems
    {
        public enum SH_SystemType
        {
            Default,
            Security,
            Appliance,
            Power,
            Temperature,
            Lighting
        }
        namespace Utility { }
    }
    namespace Simulator { }

    
    public class SmartHomeController : Singleton<SmartHomeController>
    {


        private static Dictionary<SH_SystemType, ISystem> SystemContainer = new Dictionary<SH_SystemType, ISystem>()
            {
                { SH_SystemType.Security, new SecuritySystem() },
                { SH_SystemType.Lighting,new LightSystem() },
                { SH_SystemType.Temperature,new TemperatureSystem() },
                { SH_SystemType.Appliance, new ApplianceSystem()}

            };


        private void Start()
        {
            UpdateAllDevices();
        }

        //?
        private void UpdateAllDevices()
        {
            foreach(var system in SystemContainer)
            {
                system.Value.UpdateDevices();
            }
        }

        //faster
        public static ISystem GetSystem(SH_SystemType systemType)
        {
            return SystemContainer[systemType];
        }


        public static T GetSystem<T>() where T : ISystem
        {
            return SystemContainer.Select(system => system.Value).OfType<T>().FirstOrDefault();
        }
    }
}