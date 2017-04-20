using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using SmartHome.Systems;

namespace SmartHome.Devices.Virtual
{
    public class MotionSensor : SmartDevice
    {
        public enum DetectionShape
        {
            Line,
            Cone,
            Sphere
        }

        [Header("Sensor Shape")]
        public DetectionShape shape;
        public float range;
        [Range(0, 180)]
        public float anglePeripheral;

        public bool isTriggered = false;
        private LayerMask detectableLayers;
        [SerializeField]
        string[] listOfDetectableLayers = { "Player", "BadGuy" };

        
        public void Start()
        {
            this.DevInfo = new DeviceInfo(this.GetType(), DevInfo.Name, DevInfo.GroupName, SH_SystemType.Security);

            //initialize detection shapes(?)
            detectableLayers = LayerMask.GetMask(listOfDetectableLayers);
        }
        void Update()
        {
            isTriggered = CheckMotion();
            Debug.DrawRay(transform.position, transform.forward * range, (isTriggered) ? Color.red : Color.blue);

            if (shape == DetectionShape.Cone)
                Gizmos.DrawFrustum(transform.position, anglePeripheral, range, 0.0f, 1.0f);
            else if (shape == DetectionShape.Sphere)
                Gizmos.DrawSphere(transform.position, range);
            
        }

        private bool CheckMotion()
        {
            switch (shape)
            {
                case DetectionShape.Line:
                    return LineCast();
                case DetectionShape.Cone:
                    return ConeCast();
                case DetectionShape.Sphere:
                    return SphereCast();
                default:
                    break;
            }
            return false;

        }

        private bool SphereCast()
        {
            var colliders = Physics.OverlapSphere(transform.position, range, detectableLayers);
            return IsLineOfSight(colliders);
        }

        private bool IsLineOfSight(Collider[] colliders)
        {
            foreach (var c in colliders)
            {
                if (Physics.Raycast(transform.position, c.transform.position, detectableLayers))
                    return true;
            }
            return false;
        }

        private bool ConeCast()
        {

            var colliders = Physics.OverlapSphere(transform.position, range, detectableLayers);
            return IsLineOfSight(colliders) && IsInView(colliders);

        }

        private bool IsInView(Collider[] colliders)
        {
            foreach (var c in colliders)
            {
                Vector3 cDirection = c.transform.position - transform.position;
                if (Mathf.Abs(Vector3.Dot(transform.forward.normalized, cDirection.normalized)) <= anglePeripheral)
                    return true;
            }
            return false;
        }

        private bool LineCast()
        {
            return Physics.Raycast(transform.position, transform.forward, range, detectableLayers);
        }
    }
}