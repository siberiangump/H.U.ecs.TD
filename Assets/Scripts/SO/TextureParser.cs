using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "TextureParser", menuName = "ScriptableObject/Map/TextureParser")]
    class TextureParser : ScriptableObject, IMapHolder
    {
        [SerializeField] private Texture2D Map;
        [SerializeField] private CellValueByColor[] PixelValues;

        Comparator ColorComporator = new Comparator();

        MatrixModel IMapHolder.Map
        {
            get { return FillMap(); }
        }

        [ContextMenu("FillMap")]
        public MatrixModel FillMap()
        {
            int width = Map.width;
            int height = Map.height;
            MatrixModel mapMatrix = new MatrixModel(new Vector2Int(width, height));

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color32 pixelColor = Map.GetPixel(i, j);
                    CellData cellData = mapMatrix.GetCellData(new Vector2Int(i, j));
                    cellData.Value = GetCellValue(pixelColor);
                }
            }
            return mapMatrix;
        }

        private CellValue GetCellValue(Color32 pixelColor)
        {
            CellValue cellValue = CellValue.Free;

            foreach (CellValueByColor item in PixelValues)
            {
                if (ColorComporator.Equal(item.PixelColor, pixelColor))
                    cellValue = item.PointValue;
            }

            return cellValue;
        }

        [Serializable]
        private class CellValueByColor
        {
            public CellValue PointValue;
            public Color32 PixelColor;
        }
    }
}
