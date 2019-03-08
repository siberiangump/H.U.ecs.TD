using Assets.Scripts.MainLogic.Weapons;
using UnityEngine;

namespace Assets.Scripts.SO.Configs
{
    [CreateAssetMenu(fileName = "WeaponsConfigSO", menuName = "ScriptableObject/Configs/WeaponsConfigSO")]
    class WeaponsConfigSO : ScriptableObject
    {
        [SerializeField] private float PistolBulletDamage;
        [SerializeField] private float PistolBulletSpeed;

        [ContextMenu("Init")]
        public void Init()
        {
            WeaponsConfig.PistolBulletDamage = PistolBulletDamage;
            WeaponsConfig.PistolBulletSpeed = PistolBulletSpeed;
        }
    }
}
