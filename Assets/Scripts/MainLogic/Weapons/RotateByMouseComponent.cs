using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.MainLogic.Weapons
{
    class RotateByMouseComponent : MonoBehaviour
    {
        [SerializeField] private Transform Target;
        [SerializeField] private float MinSqrDistanceToTarget = 0.25f;

        Camera MainCamera;

        private void Awake()
        {
            MainCamera = Camera.main;
        }

        private void Update()
        {
            Vector3 mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - Target.position;

            if (direction.sqrMagnitude < MinSqrDistanceToTarget)
                return;

            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion desireRotation = Quaternion.Euler(Target.eulerAngles.x, angle, Target.eulerAngles.z);
            Target.rotation = desireRotation;
        }
    }
}
