using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MatrixModel
{
    GridModel Grid;
    public Vector2Int MatrixSize;
    public List<CellData> Cells = new List<CellData>();

    public MatrixModel(Vector2Int matrixSize, GridModel gridModel)
    {
        MatrixSize = matrixSize;
        Grid = gridModel;
        Init(gridModel);
    }

    public void Init(GridModel grid)
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
        cellData.WorldPosition = Grid.GetDisplacement(index);

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

public enum CellValue { Free, Taken, Room }

[System.Serializable]
public class CellData
{
    public Vector2Int MartixIndex;
    public CellValue Value;
    public Vector3 WorldPosition;
}
