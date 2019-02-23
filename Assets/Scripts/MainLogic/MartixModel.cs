using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

[System.Serializable]
public class MatrixModel
{
    public Vector2Int Size;
    public List<CellData> Cells = new List<CellData>();

    public MatrixModel(Vector2Int matrixSize)
    {
        Size = matrixSize;
        Init();
    }

    public void Init()
    {
        Cells.Clear();
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Cells.Add(InitCell(x, y));
            }
        }
    }

    private CellData InitCell(int x, int y)
    {
        Vector2Int index = new Vector2Int { x = x, y = y };
        CellData cellData = new CellData();
        cellData.MartixIndex = index;
        cellData.Value = CellValue.Free;

        return cellData;
    }

    public CellData GetCellData(Vector2Int matrixIndex)
    {
        foreach (CellData cell in Cells)
        {
            if (matrixIndex == cell.MartixIndex)
                return cell;
        }
        return null;
    }

    public CellData GetCellData(int row, int column)
    {
        Vector2Int matrixIndex = new Vector2Int(row,column);
        return GetCellData(matrixIndex);
    }

    public void SetCellValue(int row, int column, CellValue cellValue)
    {
        for (int i = 0; i < Cells.Count; i++)
        {
            if (Cells[i].MartixIndex.x == row && Cells[i].MartixIndex.y == column)
            {
                Cells[i].Value = cellValue;
            }
        }
    }
}

public enum CellValue { Free, Taken, Room, Corridor }

