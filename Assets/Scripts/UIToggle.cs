using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace SmartHome.Simulator.Utility
{
    public class UIToggle : MonoBehaviour
    {
        public KeyCode GUIToggleKey = KeyCode.M;
        public GameObject guiTablet;


        private bool isGUIUp;
        
        private FirstPersonController fpc;

        // Use this for initialization
        void Awake()
        {
            if(guiTablet == null)
                guiTablet = GameObject.FindObjectOfType<Canvas>().gameObject;
            isGUIUp = guiTablet.activeInHierarchy;
            fpc = GameObject.FindObjectOfType<FirstPersonController>();
            SetGUIActive(isGUIUp);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(GUIToggleKey))
                ToggleGUI();
        }

        void ToggleGUI()
        {
            SetGUIActive(!isGUIUp);
        }
        public void SetGUIActive(bool turnOnGui)
        {
            guiTablet.SetActive(turnOnGui);
            Cursor.lockState = (turnOnGui) ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = turnOnGui;
            fpc.enabled = !guiTablet.activeInHierarchy;
            isGUIUp = turnOnGui;
        }
    }
}