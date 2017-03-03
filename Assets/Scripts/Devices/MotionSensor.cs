
using System;
using SmartHomeSystems;
using UnityEngine;

namespace SmartDevices {
    class MotionSensor : ISmartDevice<SecuritySystem>
    {
        public enum DetectionShape
        {
            Line,
            Cone,
            Sphere
        }

        public DetectionShape shape;
        public float range;
        public float anglePeripheral;
        private bool isTriggered;
        private LayerMask detectableLayers = LayerMask.GetMask("Player", "Badguy");

        public void Start()
        {
            //initialize detection shapes(?)
        }
        void Update()
        {
            
            isTriggered = (isEnabled) ? CheckMotion() : false;

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
            return (colliders.Length > 0) && IsLineOfSite(colliders);
        }

        private bool IsLineOfSite(Collider[] colliders)
        {
            foreach( var c in colliders)
            {
                if (Physics.Raycast(transform.position, c.transform.position)) 
                    return true;
            }
            return false;
        }

        private bool ConeCast()
        {
            var colliders = Physics.OverlapSphere(transform.position, range, detectableLayers);
            return (colliders.Length > 0) && IsLineOfSite(colliders) && IsInView(colliders);

        }

        private bool IsInView(Collider[] colliders)
        {
            foreach (var c in colliders)
            {
                Vector3 cDirection = c.transform.position - transform.position;
                if (Vector3.Dot(transform.forward.normalized,cDirection.normalized) <= anglePeripheral)
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