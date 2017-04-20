using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

namespace SmartHome.UI.Utility
{
    public class PanelSwitcher : MonoBehaviour
    {

        [Serializable]
        public struct MyPanel
        {
            public string Name;
            public GameObject panel;
        }

        [SerializeField]
        //click and drag from scene to canvas
        public List<MyPanel> panelMenus;
        void Start()
        {
        }
        //button even
        public void ChangePanelTo(string name)//index of panel
        {
            panelMenus.ForEach(p => p.panel.SetActive(p.Name == name));
        }

    }
}