using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.MainLogic.SerializeObjects;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "MobsCreator", menuName = "ScriptableObject/Character/MobsCreator")]
    class MobsCreator : ScriptableObject
    {
        [Validate(typeof(ISpawnMobPosProvider))] [SerializeField] private UnityEngine.Object RoomsHolderObj;
        [SerializeField] private GameObjectByName[] MobPrefabs;
        [SerializeField] private int RoomsAmount = 4;

        List<GameObject> Mobs;

        public void CreateMobs()
        {
            Mobs = new List<GameObject>();
            for (int i = 1; i < RoomsAmount; i++)
            {
                GameObject mobPrefab = GetMob();
                Vector3 mobFuturePos = GetCellPos(i);
                GameObject mob = Instantiate(mobPrefab, mobFuturePos, Quaternion.identity);
                Mobs.Add(mob);
            }
        }

        private GameObject GetMob()
        {
            int mobIndex = Random.Range(0, MobPrefabs.Length);
            return MobPrefabs[mobIndex].MobPrefab;
        }

        private Vector3 GetCellPos(int roomIndex)
        {
            return RoomsHolder.GetPos(roomIndex);
        }      

        private ISpawnMobPosProvider RoomsHolder
        {
            get { return (RoomsHolderObj as ISpawnMobPosProvider); }
        }
    }
}
