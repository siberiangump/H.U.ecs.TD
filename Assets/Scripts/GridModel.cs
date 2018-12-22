using UnityEngine;
using System.Collections;

[System.Serializable]
public class GridModel : MonoBehaviour
{
    [SerializeField] GridData GridSettings;

    public Vector3 GetDisplacement(Vector2Int index)
    {
        Vector3 value = new Vector3();
        value.x = Mathf.RoundToInt(index.x * GridSettings.ColumsDisplacment);
        value.y = Mathf.RoundToInt(index.y * GridSettings.RowsDisplacment);
        return value;
    }

    [System.Serializable]
    public class GridData
    {
        public float RowsDisplacment = 1;
        public float ColumsDisplacment = 1;
    }
}
