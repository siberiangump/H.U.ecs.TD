using UnityEngine;
using UnityEngine.Events;
using System;
using Assets.Scripts.Data;

namespace Assets.Scripts.MainLogic.Mobs
{
    class SimpleMobStateEmitter : MonoBehaviour
    {
        [SerializeField] private SimpleMobWrapper Wrapper;
        [SerializeField] private MaterialByStates[] MobPosibleState;
        [SerializeField] private MeshRenderer MobRenderer;

        private void Update()
        {
            MobState state = Wrapper.Value.State;
            for (int i = 0; i < MobPosibleState.Length; i++)
            {
                if (MobPosibleState [i].State == state)
                {
                    MobRenderer.material.color = MobPosibleState[i].StateColor;
                }
            }
        }

        [Serializable]
        private class MaterialByStates
        {
            public MobState State;
            public Color StateColor;
        }
    }


}
