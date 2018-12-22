using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{
    [SerializeField] GridModel Grid;
    [SerializeField] MartixModel MartixModel;

    [ContextMenu ("GenerateEmptyMap")]
    public void GenerateEmptyMap()
    {
        MartixModel.Init(Grid);
    }

    public void OnDrawGizmos()
    {
        if (MartixModel == null || MartixModel.Cells == null)
            return;
        foreach (MartixModel.CellData item in MartixModel.Cells)
        {
            Gizmos.color = item.Value == MartixModel.CellValue.Free ? Color.green : Color.red;
            Gizmos.DrawSphere(item.WorldPosition + this.transform.position, .2f);
        }
    }
}
