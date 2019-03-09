using Assets.Scripts.MainLogic.Weapons;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.SO.Configs
{
    [CreateAssetMenu(fileName = "WeaponsConfigSO", menuName = "ScriptableObject/Configs/WeaponsConfigSO")]
    class WeaponsConfigSO : ScriptableObject
    {
        [SerializeField] private float PistolBulletDamage;
        [SerializeField] private float PistolBulletSpeed;
        [SerializeField] private float3 PistolBulletRotation;
        [SerializeField] private float3 PistolBulletScale;

        [ContextMenu("Init")]
        public void Init()
        {
            WeaponsConfig.PistolBulletDamage = PistolBulletDamage;
            WeaponsConfig.PistolBulletSpeed = PistolBulletSpeed;
            WeaponsConfig.PistolBulletRotation = PistolBulletRotation;
            WeaponsConfig.PistolBulletScale = PistolBulletScale;
        }
    }
}
