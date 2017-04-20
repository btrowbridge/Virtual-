using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartHome.Simulator.Utility
{
    public class DoorOpener : MonoBehaviour
    {

        public KeyCode OpenDoorKey = KeyCode.E;
        public float reach = 2.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(OpenDoorKey))
            {
                OpenDoor();
            }
        }

        private void OpenDoor()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hitInfo, reach))
            {
                GameObject door = hitInfo.transform.gameObject;
                if (door.tag == "DOOR" || door.tag == "DRAWER")
                {
                    door.SendMessage("sandAnimOpen");
                    door.SendMessage("sandAnimOn", true);
                }
            }
        }
    }
}