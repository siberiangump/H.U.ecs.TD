using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts;

namespace Tests
{
    public class RoomPlacerTest
    {
        [Test]
        public void SetRoomTest()
        {
            GridModel mapGrid = new GridModel(5, 5);
            MatrixModel mapMatrix = new MatrixModel(new Vector2Int(10, 10), mapGrid);

            GridModel roomGrid = new GridModel(1, 1);
            MatrixModel roomMatrix = new MatrixModel(new Vector2Int(1, 1), roomGrid);

            RoomPlacer roomPlacer = new RoomPlacer(mapMatrix);
            Test1(mapMatrix, roomMatrix, roomPlacer);
            Test2(roomPlacer);
            Test3(roomMatrix, roomPlacer);
            Test4(roomPlacer);
        }

        private void Test1(MatrixModel mapMatrix, MatrixModel roomMatrix, RoomPlacer roomPlacer)
        {
            Assert.IsTrue(roomPlacer.TryPlace(roomMatrix, Vector2Int.zero));
            CellData cell_0_0 = mapMatrix.GetCellData(Vector2Int.zero);
            Assert.IsTrue(cell_0_0.Value == CellValue.Room);
        }

        private void Test2(RoomPlacer roomPlacer)
        {
            GridModel roomGrid = new GridModel(5, 5);
            MatrixModel roomMatrix1 = new MatrixModel(new Vector2Int(5, 5), roomGrid);
            Assert.IsFalse(roomPlacer.TryPlace(roomMatrix1, Vector2Int.zero));
        }

        private void Test3(MatrixModel roomMatrix, RoomPlacer roomPlacer)
        {
            Assert.IsFalse(roomPlacer.TryPlace(roomMatrix, Vector2Int.zero));           
        }

        private void Test4(RoomPlacer roomPlacer)
        {
            GridModel roomGrid = new GridModel(3, 3);
            MatrixModel roomMatrix1 = new MatrixModel(new Vector2Int(3, 3), roomGrid);
            Assert.IsFalse(roomPlacer.TryPlace(roomMatrix1, new Vector2Int(2,2)));
        }
    }
}

