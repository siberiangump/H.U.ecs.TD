using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Map : MonoBehaviour
{     
    [SerializeField] public MatrixModel MartixModel;
    [SerializeField] private GridSettings Settings;

    private GridModel Grid;

    private void Awake()
    {
        Grid = new GridModel(Settings.Settings.ColumsDisplacment, Settings.Settings.RowsDisplacment);
    }

    [ContextMenu ("GenerateEmptyMap")]
    public void GenerateEmptyMap()
    {
        MartixModel.Init();
    }

    public void OnDrawGizmos()
    {
        if (MartixModel == null || MartixModel.Cells == null)
            return;
        foreach (CellData item in MartixModel.Cells)
        {
            Gizmos.color = item.Value == CellValue.Free ? Color.green : Color.red;
            //Gizmos.DrawSphere(item.Position + this.transform.position, .2f);
        }
    }
}
