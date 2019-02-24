using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "TilePositionProvider", menuName = "ScriptableObject/Map/TilePositionProvider")]
    class TilePositionProvider : ScriptableObject, ITilePositionProvider
    {
        [SerializeField] private float ColumsDisplacment = 1.0f;
        [SerializeField] private float RowsDisplacment = 1.0f;

        public Vector3 GetPos(int row, int column)
        {
            return GetPos(new Vector2Int(row, column));
        }

        public Vector3 GetPos(Vector2Int matixIndexes)
        {
            Vector3 value = new Vector3();
            value.z = Mathf.RoundToInt(matixIndexes.y * RowsDisplacment);
            value.x = Mathf.RoundToInt(matixIndexes.x * ColumsDisplacment);
            return value;
        }
    }
}
