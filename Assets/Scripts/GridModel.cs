using UnityEngine;
using System.Collections;
using Assets.Scripts;

[System.Serializable]
public class GridModel
{
    private float ColumsDisplacment;
    private float RowsDisplacment;

    public GridModel(float columsDisplacment, float rowsDisplacement)
    {
        ColumsDisplacment = columsDisplacment;
        RowsDisplacment = rowsDisplacement;
    }

    public Vector3 GetDisplacement(Vector2Int index)
    {
        Vector3 value = new Vector3();
        value.x = Mathf.RoundToInt(index.x * ColumsDisplacment);
        value.z = Mathf.RoundToInt(index.y * ColumsDisplacment);
        return value;
    }
}
