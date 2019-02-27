using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Movement
{
    class CharacterMoveSystem : MonoBehaviour, ITransformReceiver
    {
        [SerializeField] private NavMeshAgent NavAgent;
        [SerializeField] private Transform GuideTransform;

        public void Receive(Transform transform)
        {
            GuideTransform = transform;
        }

        public void Update()
        {
            if (GuideTransform != null)
                NavAgent.SetDestination(GuideTransform.position);
        }
    }
}
