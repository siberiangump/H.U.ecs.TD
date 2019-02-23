using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MatrixConcatenator
    {
        public MatrixModel Concat(MatrixModel left, Vector2Int concatPoint, MatrixModel right)
        {
            int rows = concatPoint.x + right.Size.x;
            int colums = concatPoint.y + right.Size.y;

            Vector2Int size = new Vector2Int(rows, colums);
            MatrixModel newMatrix = new MatrixModel(size);
            SetLeftValuesToNewMatrix(left, newMatrix);
            SetRightValuesToNewMatrix(concatPoint, right, newMatrix);
            return newMatrix;
        }

        private void SetRightValuesToNewMatrix(Vector2Int concatPoint, MatrixModel right, MatrixModel newMatrix)
        {
            for (int i = concatPoint.x; i < newMatrix.Size.x; i++)
            {
                for (int j = concatPoint.y; j < newMatrix.Size.y; j++)
                {
                    CellValue rightCellValue = right.GetCellData(i - concatPoint.x, j - concatPoint.y).Value;
                    newMatrix.SetCellValue(i, j, rightCellValue);
                }
            }
        }

        private void SetLeftValuesToNewMatrix(MatrixModel left, MatrixModel newMatrix)
        {
            for (int i = 0; i < left.Size.x; i++)
            {
                for (int j = 0; j < left.Size.y; j++)
                {
                    CellValue leftCellValue = left.GetCellData(i, j).Value;
                    newMatrix.SetCellValue(i, j, leftCellValue);
                }
            }
        }
    }
}
