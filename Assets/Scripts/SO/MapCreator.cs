using Assets.Scripts.Interfaces;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "MapCreator", menuName = "ScriptableObject/Map/MapCreator")]
    class MapCreator : ScriptableObject
    {
        [Validate(typeof(IMapHolder))] [SerializeField] private UnityEngine.Object MapHolderObj;
        [Validate(typeof(ITilePositionProvider))] [SerializeField] private UnityEngine.Object TilePositionProviderObj;
        [SerializeField] private PrefabByCellValue[] TilePrefabs;

        private List<GameObject> Tiles;
        private Transform Root;

        [ContextMenu("CreateMap")]
        public void CreateMap()
        {
            Tiles = new List<GameObject>();
            CreateRoot();

            Debug.LogWarning(Map.Size);
            foreach (CellData cell in Map.Cells)
            {
                Vector3 cellPos = GetTilePosition(cell.MartixIndex);
                // Debug.LogWarning(cell.MartixIndex +" " + cell.Value);
                if (cell.Value != CellValue.Free)
                {
                    
                    InstatiateTile(cell.Value, cellPos);
                }
                else
                {
                    InstatiateTile(CellValue.Corridor, cellPos);
                }

            }
        }

        private void InstatiateTile(CellValue value, Vector3 worldPosition)
        {
            GameObject tilePrefab = GetPrefab(value);
            GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity, Root);
            // tile.transform.SetParent(Root);
            Tiles.Add(tile);
        }

        private void CreateRoot()
        {
            if (Root == null)
            {
                GameObject rootGo = new GameObject("MapRoot");
                Root = rootGo.transform;
            }
        }

        private GameObject GetPrefab(CellValue value)
        {
            return TilePrefabs.FirstOrDefault(x => x.Value == value).TilePrefab;
        }

        [ContextMenu("DestroyMap")]
        public void DestroyMap()
        {
            Destroy(Root.gameObject);
            Root = null;

            foreach (GameObject tile in Tiles)
            {
                Destroy(tile);
            }
            Tiles = new List<GameObject>();
        }

        private Vector3 GetTilePosition(Vector2Int indexes)
        {
            return TilePositionProviderGetter.GetPos(indexes);
        }

        private MatrixModel Map
        {
            get { return MapHolderGetter.Map; }
        }

        private IMapHolder MapHolderGetter
        {
            get { return MapHolderObj as IMapHolder; }
        }

        private ITilePositionProvider TilePositionProviderGetter
        {
            get { return TilePositionProviderObj as ITilePositionProvider; }
        }

        [Serializable]
        private class PrefabByCellValue
        {
            public CellValue Value;
            public GameObject TilePrefab;
        }
    }
}
