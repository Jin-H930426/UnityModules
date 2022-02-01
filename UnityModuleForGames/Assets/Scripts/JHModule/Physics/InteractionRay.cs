using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JHModule.Events;

namespace JHModule.Interaction
{
    public enum RaycastType
    {
        ObjectRay,
        CameraRay
    }
    public class InteractionRay : MonoBehaviour
    {
        [Header("Raycast Set")]
        public RaycastType raycastType = RaycastType.ObjectRay;
        [Header("Mask")]
        public LayerMask mask;
        public InputSystem.InputMask inputMask = InputSystem.InputMask.Player;
        [Header("For object type")]
        public Transform targetObject = null;
        [SerializeField] Vector3 _direction = Vector3.zero;
        public Vector3 direction {get {return targetObject.InverseTransformDirection(_direction);}}
        [Header("For camera(Touch/Click pointer) type")]
        public Camera targetCamera = null;
        public float maxDistance = 100f;
        [Header("castingTime Set")]
        public float castTime = .2f;
        float time = 0;
        [Header("Event")]
        public UnityRayEvent RayHitEvent = null;
        private void Update()
        {
            ShootRay();
        }
        
        bool ShootRay()
        {
            if (time < castTime)
            {
                time += (inputMask & InputSystem.InputMask.UI) > 0 ? TimeProperty.ui_DeltaTime : TimeProperty.runtime_DeltaTime;
                return false;
            }
            time -= castTime;
            RaycastHit hit;

            Ray ray = raycastType == RaycastType.ObjectRay ? new Ray(targetObject.position, direction):
            InputSystem.InputManager.GetMouseRayPoint(targetCamera);
#if UNITY_EDITOR
            Debug.DrawLine(ray.origin, ray.origin + (ray.direction * maxDistance), Color.green);
#endif
            if (Physics.Raycast(ray.origin, ray.direction, out hit, maxDistance, mask))
            {
                RayHitEvent?.Invoke(hit);
                return true;
            }
            return false;
        }

    }
}