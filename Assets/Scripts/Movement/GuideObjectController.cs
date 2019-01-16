using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Movement
{
    class GuideObjectController : MonoBehaviour, ITransformReceiver
    {
        [SerializeField] private Transform GuideObj;

        private Transform CharacterTransform;

        private void Awake()
        {
            if (GuideObj == null)
                GuideObj = transform;
        }

        public void Receive(Transform transform)
        {
            CharacterTransform = transform;
        }

        private void Update()
        {
            if (CharacterTransform == null)
                return;

            float hor = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");
            Vector3 characterPos = CharacterTransform.position;
            GuideObj.position = characterPos + new Vector3(hor,0,vert);
        }

    }
}
