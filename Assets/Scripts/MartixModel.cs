using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

[System.Serializable]
public class MatrixModel
{  
    public Vector2Int MatrixSize;
    public List<CellData> Cells = new List<CellData>();

    public MatrixModel(Vector2Int matrixSize)
    {
        MatrixSize = matrixSize;       
        Init();
    }

    public void Init()
    {
        Cells.Clear();
        for (int x = 0; x < MatrixSize.x; x++)
        {
            for (int y = 0; y < MatrixSize.y; y++)
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
}

public enum CellValue { Free, Taken, Room, Corridor }

