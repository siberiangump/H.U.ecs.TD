using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    class MatrixConcatenate
    {
        [Test]
        [Category("DungeonCreation")]
        public void MatrixConcat()
        {
            Test_1();
        }

        private void Test_1()
        {
            MatrixModel left = new MatrixModel(new Vector2Int(3, 3));
            left.SetCellValue(1, 1, CellValue.Room);

            MatrixModel right = new MatrixModel(new Vector2Int(3, 3));
            right.SetCellValue(1, 1, CellValue.Room);
            Vector2Int concatPoint = new Vector2Int(0, 3);

            MatrixConcatenator concatenator = new MatrixConcatenator();
            MatrixModel concatMatrix = concatenator.Concat(left, concatPoint, right);
            Assert.AreEqual(concatMatrix.Size.x, 3);
            Assert.AreEqual(concatMatrix.Size.y, 6);

            CellValue cellValueFromLeft = concatMatrix.GetCellData(1, 1).Value;
            Assert.IsTrue(cellValueFromLeft == CellValue.Room);

            CellValue cellValueFromRight = concatMatrix.GetCellData(1, 4).Value;
            Assert.IsTrue(cellValueFromRight == CellValue.Room);
        }

        private void Test_2()
        {
            MatrixModel left = new MatrixModel(new Vector2Int(5, 5));
            MatrixModel right = new MatrixModel(new Vector2Int(5, 3));
            Vector2Int concatPoint = new Vector2Int(0, 5);

            MatrixConcatenator concatenator = new MatrixConcatenator();
            MatrixModel concatMatrix = concatenator.Concat(left, concatPoint, right);
            Assert.AreEqual(concatMatrix.Size.x, 5);
            Assert.AreEqual(concatMatrix.Size.y, 8);

            concatPoint = new Vector2Int(2, 5);
            concatMatrix = concatenator.Concat(left, concatPoint, right);
            Assert.AreEqual(concatMatrix.Size.x, 7);
            Assert.AreEqual(concatMatrix.Size.y, 8);
        }
    }
}
