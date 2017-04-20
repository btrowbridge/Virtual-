using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartHome.Devices.Virtual
{
    public class SmartTV : SmartDevice
    {

        [SerializeField]
        private bool on = false;

        // Use this for initialization
        void Start()
        {
            on = true;
        }

        public bool GetOnStatus()
        {
            return on;
        }

        void Update()
        {
            if (Input.GetKeyDown("t"))
                ToggleOnOff();
            if (on)
            {
                // play screen
                this.gameObject.GetComponent<AudioSource>().mute = false;
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                // turn off scren
                this.gameObject.GetComponent<AudioSource>().mute = true;
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

        }

        public void ToggleOnOff()
        {
            if (on)
                on = false;
            else
                on = true;
        }
    }
}