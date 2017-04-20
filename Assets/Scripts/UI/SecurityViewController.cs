using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartHome.Systems;
using SmartHome.Devices.Virtual;
using UnityEngine.UI;
using System.Linq;

namespace SmartHome.UI.Views
{
    public class SecurityViewController : MonoBehaviour
    {
        public GameObject cameraList;
        public GameObject sensorList;

        List<string> cameraNames;
        List<string> sensorNames;


        List<RawImage> screens;

        SecuritySystem system;
        // Use this for initialization
        void Start()
        {
            system = SmartHomeController.GetSystem<SecuritySystem>();

            cameraNames = system.Cameras.Select(cam => cam.DevInfo.Name).ToList();
            sensorNames = system.MotionSensors.Select(sensor => sensor.DevInfo.Name).ToList();

            screens = new List<RawImage>(4);
            for(int iscreen = 0; iscreen < screens.Capacity; iscreen++)
            {
                screens[iscreen] = GameObject.Find("Sec_Screen_" + iscreen).GetComponent<RawImage>();
                system.Cameras[iscreen].BindTargetTexture(screens[iscreen]);
            }

            UIHelper.PopulateList(cameraList, cameraNames);
            UIHelper.PopulateList(sensorList, cameraNames);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}