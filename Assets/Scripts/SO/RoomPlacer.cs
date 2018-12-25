using UnityEngine;
using System;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "RoomPlacer", menuName = "ScriptableObject/RoomPlacer")]
    class RoomPlacer : ScriptableObject
    {
        [SerializeField] private Item[] RoomItems;

        private MartixModel Map;

        public void ReciveMap(MartixModel martixModel)
        {
            Map = martixModel;
        }


        [Serializable]
        private class Item
        {
            public Map Map;
            public int Id;
        }

    }
}
