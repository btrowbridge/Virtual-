
using System;
using UnityEngine;
using UnityEngine.UI;
using SmartHome.Systems;

namespace SmartHome.Devices.Virtual
{
    public class SecurityCamera : SmartDevice
    {

        private RenderTexture renderTexture;

        public bool IsControllable;

        public float rotSpeed = 10f;
        public float autoRotateAmount;

        private bool IsUserControlling = false;
        private Camera cam;
        private Transform swivel;

        void Start()
        {
            this.DevInfo = new DeviceInfo(this.GetType(),SH_SystemType.Security);

            swivel = this.gameObject.transform.GetChild(1);
            cam = this.gameObject.GetComponentInChildren<Camera>();
            renderTexture = new RenderTexture(256,256,24);
            SetRenderTarget(renderTexture);
           
        }
        public void BindTargetTexture(RawImage target)
        {
            target.texture = renderTexture;
        }


        void SetRenderTarget (RenderTexture targetTexture)
        {
            cam.targetTexture = targetTexture;
        }

        void Update()
        {
            if (swivel == null) return;

            if (IsControllable && IsUserControlling)
            {
                UserControls();
            }
            else
            {
                swivel.rotation = Quaternion.Euler(swivel.eulerAngles.x, (Mathf.Cos(Time.realtimeSinceStartup) * autoRotateAmount) + swivel.eulerAngles.y, swivel.eulerAngles.z);
                WaitForSeconds wait = new WaitForSeconds(1f / rotSpeed);
            }
        }

        void SetIsUserControlling(bool isuser)
        {
            IsUserControlling = isuser;
        }

        private void UserControls()
        {
            float xIn = Input.GetAxisRaw("Horizontal");
            float yIn = Input.GetAxisRaw("Vertical");
            float pitch = 0, yaw = 0;
            if(xIn != 0)
            {
                pitch = Mathf.Sign(xIn) * rotSpeed;
            }
            if (yIn != 0)
            {
                yaw = Mathf.Sign(yIn) * rotSpeed;
            }

            transform.Rotate(yaw, pitch, 0.0f);

        }
    }

}