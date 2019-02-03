using UnityEngine;
using UnityEngine.Events;
using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.MainLogic;
using UnityEngine.AI;

namespace Assets.Scripts.Movement
{
    class CameraMoveController : MonoBehaviour
    {
        [SerializeField] private OffsetsFromCenter Offsets;
        [SerializeField] private Camera MainCamera;
        [SerializeField] private float CameraMoveSpeed = 2.0f;
        [SerializeField] private float CameraRadius = 2.0f;

        private Transform HeroTransform;
        private Transform CameraTr;
        NavMeshAgent NavAgent;

        private void Awake()
        {
            CameraTr = MainCamera.transform;
        }

        private void LateUpdate()
        {
            FillHeroTransform();

            if (HeroTransform == null)
                return;

            //if (IsHeroOutsideRect)
            //{
            //    Vector3 target = new Vector3(HeroTransform.position.x, CameraTr.position.y, HeroTransform.position.z);
            //    Vector3 newCameraPos = Vector3.Lerp(CameraTr.position, target, CameraMoveSpeed * Time.deltaTime);
            //    //newCameraPos.y = CameraTr.position.y;
            //    Debug.Log($"hero :{HeroTransform.position} camera {CameraTr.position}");
            //    CameraTr.position = newCameraPos;
            //}

            Vector3 cameraPos = new Vector3(CameraTr.position.x, 0, CameraTr.position.z);
            Vector3 offSet = HeroTransform.position - cameraPos;

            if (offSet.sqrMagnitude > CameraRadius * CameraRadius)
            {
                Vector3 direction = offSet.normalized;
                float diff = offSet.magnitude - CameraRadius;
                Vector3 newCameraPos = CameraTr.position + direction * Time.deltaTime * GetSpeed(diff);
                CameraTr.position = newCameraPos;
            }
        }

        private float GetSpeed(float diff)
        {
            float speed = NavAgent.speed * diff;

            //if (diff > 1)
            //{
            //    speed *= CameraMoveSpeed;
            //}

            return speed;
        }

        private void FillHeroTransform()
        {
            if (HeroTransform == null)
            {
                HeroTransform = GameContext.GetInstance<Transform>(Constants.HeroTransform);
                if (HeroTransform != null)
                {
                    NavAgent = HeroTransform.gameObject.GetComponent<NavMeshAgent>();
                }
            }
        }

        private bool IsHeroOutsideRect
        {
            get
            {
                (Vector3 leftVector, Vector3 rightVector, Vector3 upVector, Vector3 downVector) = GetRectPoints();
                Vector3 PlayerPos = HeroTransform.position;

                if (PlayerPos.z > upVector.z || PlayerPos.z < downVector.z || PlayerPos.x > rightVector.x || PlayerPos.x < leftVector.x)
                    return true;
                return false;
            }
        }

        private (Vector3 leftVector, Vector3 rightVector, Vector3 upVector, Vector3 downVector) GetRectPoints()
        {
            float halfWidth = MainCamera.pixelWidth * 0.5f;
            float halfHeight = MainCamera.pixelHeight * 0.5f;

            float high = Offsets.Top;
            float down = Offsets.Bottom;
            float right = Offsets.Right;
            float left = Offsets.Left;

            Vector3 leftVector = MainCamera.ScreenToWorldPoint(new Vector2(halfWidth - halfWidth * left, halfHeight));
            Vector3 rightVector = MainCamera.ScreenToWorldPoint(new Vector2(halfWidth + halfWidth * right, halfHeight));
            Vector3 upVector = MainCamera.ScreenToWorldPoint(new Vector2(halfWidth, halfHeight + halfHeight * high));
            Vector3 downVector = MainCamera.ScreenToWorldPoint(new Vector2(halfWidth, halfHeight - halfHeight * down));

            return (leftVector, rightVector, upVector, downVector);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            (Vector3 leftVector, Vector3 rightVector, Vector3 upVector, Vector3 downVector) = GetRectPoints();

            Vector3 bottomLeft = new Vector3(leftVector.x, 0, downVector.z);
            Vector3 upLeft = new Vector3(leftVector.x, 0, upVector.z);
            Vector3 upRight = new Vector3(rightVector.x, 0, upVector.z);
            Vector3 bottomRight = new Vector3(rightVector.x, 0, downVector.z);

            //Gizmos.DrawLine(bottomLeft, upLeft);
            //Gizmos.DrawLine(upLeft, upRight);
            //Gizmos.DrawLine(upRight, bottomRight);
            //Gizmos.DrawLine(bottomRight, bottomLeft);
            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            Gizmos.DrawWireSphere(pos, CameraRadius);
        }

        [Serializable]
        private class OffsetsFromCenter
        {
            public float Top;
            public float Bottom;
            public float Right;
            public float Left;
        }
    }
}
