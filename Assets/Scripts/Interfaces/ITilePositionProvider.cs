using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ITilePositionProvider
    {
        Vector3 GetPos(int row, int column);
        Vector3 GetPos(Vector2Int matixIndexes);
    }
}
