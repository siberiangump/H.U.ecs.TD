using Unity.Entities;

public struct Pistol : IComponentData
{
    public int Id;
    public float ReloadAt;
}

public struct PistolSpawnPoint : IComponentData
{
    public int Id;
}