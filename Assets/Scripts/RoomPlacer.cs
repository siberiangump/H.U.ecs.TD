using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class RoomPlacer
    {
        private MatrixModel Map;

        public RoomPlacer(MatrixModel matrix)
        {
            Map = matrix;
        }

        public bool TryPlace(MatrixModel room, Vector2Int matrixPos)
        {
            if (IsRoomBiggerThenMap(room))
                return false;

            Vector2Int[] roomPoints = RoomPointsToMapPoints(room, matrixPos);

            if (!IsAllPointsOnMap(roomPoints) || !IsAllPointsFree(roomPoints))
                return false;

            foreach (Vector2Int point in roomPoints)
            {
                CellData cellData = Map.GetCellData(point);
                cellData.Value = CellValue.Room;
            }

            return true;
        }

        private bool IsAllPointsFree(Vector2Int[] roomPoints)
        {
            for (int i = 0; i < roomPoints.Length; i++)
            {
                if (!IsPointFree(roomPoints[i]))
                    return false;
            }
            return true;
        }

        private Vector2Int[] RoomPointsToMapPoints(MatrixModel roomM, Vector2Int roomPos)
        {
            int pointsArrSize = roomM.MatrixSize.x + roomM.MatrixSize.y;
            Vector2Int[] points = new Vector2Int[pointsArrSize];

            int xLenght = roomM.MatrixSize.x;
            int yLenght = roomM.MatrixSize.y;

            for (int i = 0; i < xLenght; i++)
            {
                for (int j = 0; j < yLenght; j++)
                {
                    points[i + j] = new Vector2Int(roomPos.x + i, roomPos.y + j);
                }
            }

            return points;
        }

        private bool IsAllPointsOnMap(Vector2Int[] roomPoints)
        {
            for (int i = 0; i < roomPoints.Length; i++)
            {
                if (!IsPointOnMap(roomPoints[i]))
                    return false;
            }
            return true;
        }

        private bool IsRoomBiggerThenMap(MatrixModel room)
        {
            return room.MatrixSize.x > Map.MatrixSize.x || room.MatrixSize.y > Map.MatrixSize.y;
        }

        private bool IsPointOnMap(Vector2Int point)
        {
            return point.x < Map.MatrixSize.x && point.y < Map.MatrixSize.y;
        }

        private bool IsPointFree(Vector2Int pos)
        {
            CellData pivotPoint = Map.GetCellData(pos);
            if (pivotPoint.Value == CellValue.Free)
                return true;
            return false;
        }
    }
}
