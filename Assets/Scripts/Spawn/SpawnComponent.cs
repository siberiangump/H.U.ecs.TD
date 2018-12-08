using Unity.Entities;
using UnityEngine;

[System.Serializable]
public struct SpawnData : IComponentData
{
    public float Rate;
    public float LastSpawn;
}

public class SpawnComponent : ComponentDataWrapper<SpawnData>{}
