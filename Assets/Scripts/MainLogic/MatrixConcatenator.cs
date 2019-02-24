using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MatrixConcatenator
    {
        public MatrixModel Concat(MatrixModel left, Vector2Int concatPoint, MatrixModel right)
        {
            int colums = GetColumnSize(left, concatPoint, right);
            int rows = GetRowsSize(left, concatPoint, right);

            Vector2Int size = new Vector2Int(colums, rows);
            MatrixModel newMatrix = new MatrixModel(size);
            SetLeftValuesToNewMatrix(left, newMatrix);
            SetRightValuesToNewMatrix(concatPoint, right, newMatrix);
            return newMatrix;
        }

        private int GetColumnSize(MatrixModel left, Vector2Int concatPoint, MatrixModel right)
        {
            int columns = concatPoint.x + right.Size.x;
            if (columns < left.Size.x)
                columns = left.Size.x;
            return columns;
        }

        private int GetRowsSize(MatrixModel left, Vector2Int concatPoint, MatrixModel right)
        {
            int rows = concatPoint.y + right.Size.y;
            if (rows < left.Size.y)
                rows = left.Size.y;
            return rows;
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

        private void SetRightValuesToNewMatrix(Vector2Int concatPoint, MatrixModel right, MatrixModel newMatrix)
        {
            for (int i = concatPoint.x; i < newMatrix.Size.x; i++)
            {
                for (int j = concatPoint.y; j < newMatrix.Size.y; j++)
                {
                    CellData cellData = right.GetCellData(i - concatPoint.x, j - concatPoint.y);
                    if (cellData != null)
                    {
                        CellValue rightCellValue = cellData.Value;
                        newMatrix.SetCellValue(i, j, rightCellValue);
                    }
                }
            }
        }        
    }
}
