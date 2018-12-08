using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnSystem : ComponentSystem
{
    [Inject] SystemInjects Data;

    public struct SystemInjects
    {
        public readonly int Length;
        public ComponentDataArray<Position> Position;
        public ComponentDataArray<SpawnData> Spawn;
    }

    protected override void OnUpdate()
    {
        if (EnemyPoolStatic.Instance == null)
            return;
        float time = Time.realtimeSinceStartup;
        GameObject[] prefabs = EnemyPoolStatic.Instance.Prefabs;
        for (int i = 0; i < Data.Length; i++)
        {
            if (time > Data.Spawn[i].LastSpawn + Data.Spawn[i].Rate)
            {
                float3 position = Data.Position[i].Value + new float3(UnityEngine.Random.Range(-.9f, .9f), UnityEngine.Random.Range(-.9f, .9f), 0);
                Spawn(i, prefabs, position);
                SpawnData spawnData = Data.Spawn[i];
                spawnData.LastSpawn = time;
                Data.Spawn[i] = spawnData;
            }
        }
    }

    private void Spawn(int i, GameObject[] prefabs, float3 position)
    {
        GameObject.Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)]);
    }
}
