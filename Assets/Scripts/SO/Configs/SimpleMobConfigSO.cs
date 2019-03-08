using UnityEngine;
using Assets.Scripts.MainLogic.Mobs;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "SimpleMobConfigSO", menuName = "ScriptableObject/Mobs/SimpleMobConfigSO")]
    class SimpleMobConfigSO : ScriptableObject
    {
        [SerializeField] private float SqrDistanceToAtack;

        public void Init()
        {
            SimpleMobConfig.DistanceToAtack = SqrDistanceToAtack;
        }
    }
}
