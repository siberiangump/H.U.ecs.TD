using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int Amount = 1000;
    [SerializeField] GameObject[] Prefabs;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] float Rate = 1;

    float LastSpawn = 0;

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        Position spawnPosition = GetSpawnPosition();
        spawnPosition.Value = new float3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z);
        for (int i = 0; i < Amount; i++)
        {
            GameObject gmo = Instantiate(Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)]);
            gmo.GetComponent<PositionComponent>().Value = spawnPosition;
        }
    }

    public Position GetSpawnPosition()
    {
        Position spawnPosition = new Position();
        spawnPosition.Value = new float3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z);
        return spawnPosition;
    }

    private void SpawnOne()
    {
        GameObject gmo = Instantiate(Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)]);
        gmo.GetComponent<PositionComponent>().Value = GetSpawnPosition();
    }

    public void Update()
    {
        if (Time.realtimeSinceStartup > LastSpawn + Rate)
        {
            SpawnOne();
            LastSpawn = Time.realtimeSinceStartup;
        }
    }
}
