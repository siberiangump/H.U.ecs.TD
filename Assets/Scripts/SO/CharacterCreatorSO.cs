using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Movement;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "CharacterCreatorSO", menuName = "ScriptableObject/Character/CharacterCreatorSO")]
    class CharacterCreatorSO : ScriptableObject
    {
        [SerializeField] private GameObject Character;
        [SerializeField] private Vector3 SpawnPoint;

        [ContextMenu("SpawnCharacter")]
        public void SpawnCharacter()
        {
            GameObject character = Instantiate(Character, SpawnPoint, Quaternion.identity);
            SpawnGuideObject(character);
        }

        private void SpawnGuideObject(GameObject character)
        {
            GameObject guideObj = new GameObject("CharacterGuide");
            guideObj.transform.position = SpawnPoint;

            ITransformReceiver guideObjectControler = guideObj.AddComponent<GuideObjectController>();
            guideObjectControler.Receive(character.transform);

            ITransformReceiver moveCharacterSystem = character.GetComponent<ITransformReceiver>();
            moveCharacterSystem.Receive(guideObj.transform);
        }
    }
}
