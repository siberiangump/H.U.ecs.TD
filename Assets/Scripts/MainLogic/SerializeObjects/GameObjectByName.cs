using System;
using UnityEngine;

namespace Assets.Scripts.MainLogic.SerializeObjects
{
    [Serializable]
    public class GameObjectByName
    {
        public string Name;
        public GameObject MobPrefab;
    }
}
