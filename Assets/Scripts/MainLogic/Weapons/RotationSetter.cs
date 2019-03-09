using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.MainLogic.Weapons
{
    class RotationSetter : MonoBehaviour
    {
        [SerializeField] private float3 Rotation;

        public void Update()
        {
            WeaponsConfig.PistolBulletRotation = Rotation;
        }
    }
}
