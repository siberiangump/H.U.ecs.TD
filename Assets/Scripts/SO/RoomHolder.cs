using UnityEngine;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using Assets.Scripts.MainLogic.SerializeObjects;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "RoomHolder", menuName = "ScriptableObject/Map/RoomHolder")]
    class RoomHolder : ScriptableObject, IMapAddable, ISpawnMobPosProvider
    {
        [Validate(typeof(ITilePositionProvider))] [SerializeField] private UnityEngine.Object TilePositionProviderObj;

        private List<List<Vector3>> Rooms;

        public void Init()
        {
            Rooms = new List<List<Vector3>>();
        }

        public void Add(MatrixModel map, Vector2Int concatPoint)
        {
            List<Vector3> rooms = new List<Vector3>();
            foreach (CellData cell in map.Cells)
            {
                if (cell.Value == CellValue.Room)
                {
                    Vector2Int indexInConcatMatrix = cell.MartixIndex + concatPoint;
                    Vector3 tilePos = GetTilePosition(indexInConcatMatrix);
                    rooms.Add(tilePos);
                }
            }

            Rooms.Add(rooms);
        }


        private Vector3 GetTilePosition(Vector2Int indexes)
        {
            return TilePositionProviderGetter.GetPos(indexes);
        }

        public Vector3 GetPos(int roomIndex)
        {
            List<Vector3> rooms = Rooms[roomIndex];
            int index = Random.Range(0, rooms.Count);
            return rooms[index];
        }

        private ITilePositionProvider TilePositionProviderGetter
        {
            get { return TilePositionProviderObj as ITilePositionProvider; }
        }
    }
}
