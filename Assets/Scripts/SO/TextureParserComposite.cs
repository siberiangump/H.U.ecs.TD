using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "TextureParserComposite", menuName = "ScriptableObject/Map/TextureParserComposite")]
    class TextureParserComposite : ScriptableObject, IMapHolder
    {
        [Validate(typeof(IMapHolder))] [SerializeField] private UnityEngine.Object[] MapHolderObjects;
        [Validate(typeof(IMapAddable))] [SerializeField] private UnityEngine.Object MapAddabeObj;

        public MatrixModel Map { get { return ConcatanetaMatrices(); } }

        private MatrixModel ConcatanetaMatrices()
        {
            MatrixModel concatMatrix = (MapHolderObjects[0] as IMapHolder).Map;
            MatrixConcatenator concatenator = new MatrixConcatenator();
            RoomHolder.Add(concatMatrix, Vector2Int.zero);

            for (int i = 1; i < MapHolderObjects.Length; i++)
            {
                IMapHolder mapHolder = MapHolderObjects[i] as IMapHolder;
                Vector2Int concatPoint = GetConcatPoint(concatMatrix);
                concatMatrix = concatenator.Concat(concatMatrix, concatPoint, mapHolder.Map);
                RoomHolder.Add(mapHolder.Map, concatPoint);
            }

            return concatMatrix;
        }

        private Vector2Int GetConcatPoint(MatrixModel matrix)
        {
            return new Vector2Int(matrix.Size.x, 0);
        }

        private IMapAddable RoomHolder { get { return MapAddabeObj as IMapAddable; } }
    }
}
