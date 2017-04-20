using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmartHome.Systems;
using System;
using UnityEngine.UI;
using SmartHome.UI;
using System.Linq;
namespace SmartHome.UI.Views
{
    public class LightingViewController : MonoBehaviour
    {
        public GameObject lightList;
        public GameObject groupList;

        private List<string> lightNames;
        private List<string> groupNameList;

        LightSystem system;
        GameObject prefab;
        // Use this for initialization
        void Start()
        {

        }

        private void Awake()
        {
            system = SmartHomeController.GetSystem<LightSystem>();
            lightNames = system.GetDeviceNames();
            groupNameList = system.GetGroupNames();
            UIHelper.PopulateList(lightList, lightNames);
            UIHelper.PopulateList(groupList, groupNameList);
            Console.WriteLine("Populate the Group and Light Lists");
        }


        private List<string> GetSelectedDevices() {
            List<string> activeItems = UIHelper.GetSelectedNames(lightList);
            List<string> activeGroupItems = UIHelper.GetSelectedNames(groupList);

            activeItems.AddRange(system.GetNamesFromGroups(activeGroupItems));

            return activeItems;
        }

        public void OnOnButton() {
            List<string> activeItems = GetSelectedDevices();

            foreach (var devName in activeItems.Distinct()) {
                system.GetLight(devName).SetEnable(true);
            }
        }

        public void OnOffButton() {
            List<string> activeItems = GetSelectedDevices();

            foreach (var devName in activeItems.Distinct())
            {
                system.GetLight(devName).SetEnable(false);
            }
        }

        public void OnApplyButton() {
            List<string> activeItems = GetSelectedDevices();

            int red = (int) GameObject.Find("RedSldr").GetComponent<Slider>().value;
            int green = (int)GameObject.Find("GreenSldr").GetComponent<Slider>().value;
            int blue = (int)GameObject.Find("BlueSldr").GetComponent<Slider>().value;

            int intensity = (int)GameObject.Find("IntensitySldr").GetComponent<Slider>().value;

            foreach (var devName in activeItems.Distinct())
            {
                system.GetLight(devName).SetIntensity(intensity);
                system.GetLight(devName).SetColor(new Color(red, green, blue));
            }
        }

    }
}