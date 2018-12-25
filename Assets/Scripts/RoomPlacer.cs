using UnityEngine;

namespace Assets.Scripts
{
    class RoomPlacer
    {
        public bool TryPlace(MatrixModel room, Vector2Int matrixPos, MatrixModel map)
        {
            if (room.MatrixSize.x > map.MatrixSize.x || room.MatrixSize.y > map.MatrixSize.y)
                return false;


            return true;
        }
    }
}
