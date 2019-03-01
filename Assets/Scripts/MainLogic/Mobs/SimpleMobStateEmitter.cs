using UnityEngine;
using UnityEngine.Events;
using System;
using Assets.Scripts.Data;

namespace Assets.Scripts.MainLogic.Mobs
{
    class SimpleMobStateEmitter : MonoBehaviour
    {
        [SerializeField] private StateViewer Wrapper;
        [SerializeField] private MaterialByStates[] MobPosibleState;
        [SerializeField] private MeshRenderer MobRenderer;

        private void Update()
        {
            MobState state = Wrapper.CurrentState;
            for (int i = 0; i < MobPosibleState.Length; i++)
            {
                Color stateColor = MobPosibleState[i].StateColor; 
                if (MobPosibleState [i].State == state && MobRenderer.material.color != stateColor)
                {
                    MobRenderer.material.color = stateColor;
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
