using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MartixModel
{
    GridModel Grid;
    public Vector2Int MatrixSize;
    public List<CellData> Cells = new List<CellData>();

    public void Init(GridModel grid)
    {
        Cells.Clear();
        for (int x = 0; x < MatrixSize.x; x++)
        {
            for (int y = 0; y < MatrixSize.y; y++)
            {
                Cells.Add(InitCell(x,y));
            }
        }
    }

    private CellData InitCell(int x, int y)
    {
        Vector2Int index = new Vector2Int { x = x, y = y };
        return new CellData
        {
            MartixIndex = index,
            Value = CellValue.Free,
            WorldPosition = Grid.GetDisplacement(index)
        };
    }

    [System.Serializable]
    public struct CellData
    {
        public Vector2Int MartixIndex;
        public CellValue Value;
        public Vector3 WorldPosition;
    }

    public enum CellValue {Free, Taken}
}
