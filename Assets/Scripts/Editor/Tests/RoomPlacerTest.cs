using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RoomPlacerTest
    {        
        [Test]
        public void SetRoomTest()
        {
            GridModel mapGrid = new GridModel(10,10);
            MatrixModel mapMatrix = new MatrixModel(new Vector2Int(10,10), mapGrid);

            GridModel roomGrid = new GridModel(2, 2);
            MatrixModel roomMatrix = new MatrixModel(new Vector2Int(2, 2), roomGrid);
        }        
    }
}

