using Unity.Entities;
using System;

public struct Fire : IComponentData
{
}

[Serializable]
public struct Pistol : IComponentData
{
    public int Id;
    public float ReloadAt;
}

[Serializable]
public struct PistolSpawnPoint : IComponentData
{
    public int Id;
}