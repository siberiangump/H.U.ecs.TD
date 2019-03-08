using Assets.Scripts.MainLogic.Weapons;
using Unity.Rendering;
using UnityEngine;

namespace Assets.Scripts.SO.Configs
{
    [CreateAssetMenu(fileName = "WeaponMeshConfigSO", menuName = "ScriptableObject/Configs/WeaponMeshConfigSO")]
    class WeaponMeshConfigSO : ScriptableObject
    {
        [SerializeField] private RenderMeshProxy PistolBullet;

        public void Init()
        {
            WeaponsMeshes.BulletMeshProxy = PistolBullet;
        }
    }
}
