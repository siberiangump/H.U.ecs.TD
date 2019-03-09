using Assets.Scripts.MainLogic.Weapons;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.SO.Configs
{
    [CreateAssetMenu(fileName = "PistolBulletConfigSO", menuName = "ScriptableObject/Configs/PistolBulletConfigSO")]
    class PistolBulletConfigSO : ScriptableObject
    {
        [SerializeField] private int PistolBulletDamage;
        [SerializeField] private float PistolBulletSpeed;
        [SerializeField] private float3 PistolBulletRotation;
        [SerializeField] private float3 PistolBulletScale;
        [SerializeField] private float PistolBulletSqrDistance = 0.25f;
        [SerializeField] private float TimeToDestroy = 5.0f;

        [ContextMenu("Init")]
        public void Init()
        {
            PistolBulletConfig.Damage = PistolBulletDamage;
            PistolBulletConfig.Speed = PistolBulletSpeed;
            PistolBulletConfig.Rotation = PistolBulletRotation;
            PistolBulletConfig.Scale = PistolBulletScale;
            PistolBulletConfig.SqrDistanceToTakeDamage = PistolBulletSqrDistance;
            PistolBulletConfig.TimeToDestroy = TimeToDestroy;
        }
    }
}
