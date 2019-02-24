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
            Test_2();
        }

        private void Test_1()
        {
            MatrixModel left = new MatrixModel(new Vector2Int(3, 3));
            left.SetCellValue(1, 1, CellValue.Room);

            MatrixModel right = new MatrixModel(new Vector2Int(3, 3));
            right.SetCellValue(0, 0, CellValue.Room);
            Vector2Int concatPoint = new Vector2Int(3, 0);

            MatrixConcatenator concatenator = new MatrixConcatenator();
            MatrixModel concatMatrix = concatenator.Concat(left, concatPoint, right);
            DrawMatrix(concatMatrix);

            Assert.AreEqual(6, concatMatrix.Size.x);
            Assert.AreEqual(3, concatMatrix.Size.y);


            CellValue cellValueFromLeft = concatMatrix.GetCellData(1, 1).Value;
            Assert.IsTrue(cellValueFromLeft == CellValue.Room);

            CellValue cellValueFromRight = concatMatrix.GetCellData(3, 0).Value;
            Assert.IsTrue(cellValueFromRight == CellValue.Room);
        }

        private void Test_2()
        {
            MatrixModel left = new MatrixModel(new Vector2Int(5, 5));
            MatrixModel right = new MatrixModel(new Vector2Int(5, 3));
            right.SetCellValue(4, 2, CellValue.Room);
            Vector2Int concatPoint = new Vector2Int(5, 0);

            MatrixConcatenator concatenator = new MatrixConcatenator();
            MatrixModel concatMatrix = concatenator.Concat(left, concatPoint, right);
            DrawMatrix(concatMatrix);

            Assert.AreEqual(10, concatMatrix.Size.x);
            Assert.AreEqual(5, concatMatrix.Size.y);

            CellValue cellValueFromRight = concatMatrix.GetCellData(9, 2).Value;
            Assert.IsTrue(cellValueFromRight == CellValue.Room);
            cellValueFromRight = concatMatrix.GetCellData(5, 4).Value;
            Assert.IsTrue(cellValueFromRight == CellValue.Free);

            concatPoint = new Vector2Int(5, 3);
            concatMatrix = concatenator.Concat(left, concatPoint, right);
            DrawMatrix(concatMatrix);
            Assert.AreEqual(concatMatrix.Size.x, 10);
            Assert.AreEqual(concatMatrix.Size.y, 6);

            cellValueFromRight = concatMatrix.GetCellData(9, 5).Value;
            Assert.IsTrue(cellValueFromRight == CellValue.Room);
        }

        private void DrawMatrix(MatrixModel concatMatrix)
        {
            string m = "";
            for (int j = 0; j < concatMatrix.Size.y; j++)
            {
                for (int i = 0; i < concatMatrix.Size.x; i++)
                {
                    int val = concatMatrix.GetCellData(i, j).Value == CellValue.Room ? 1 : 0;
                    m += val + " ";
                }
                m += "\n";
            }
            Debug.LogWarning(m);
        }
    }
}
