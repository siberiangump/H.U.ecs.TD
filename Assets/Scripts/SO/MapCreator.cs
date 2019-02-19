﻿using Assets.Scripts.Interfaces;
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
        [SerializeField] private PrefabByCellValue[] TilePrefabs;

        private List<GameObject> Tiles;
        private Transform Root;

        [ContextMenu("CreateMap")]
        public void CreateMap()
        {
            Tiles = new List<GameObject>();
            CreateRoot();

            foreach (CellData cell in Map.Cells)
            {
                //if (cell.Value != CellValue.Free)
                //    InstatiateTile(cell.Value, cell.Position);
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

        private MatrixModel Map
        {
            get { return MapHolderGetter.Map; }
        }

        private IMapHolder MapHolderGetter
        {
            get { return MapHolderObj as IMapHolder; }
        }

        [Serializable]
        private class PrefabByCellValue
        {
            public CellValue Value;
            public GameObject TilePrefab;
        }
    }
}