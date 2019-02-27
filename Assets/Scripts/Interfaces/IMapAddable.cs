using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IMapAddable
    {
        void Add(MatrixModel map, Vector2Int concatPoint);
    }
}
