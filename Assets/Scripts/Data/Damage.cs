using Unity.Entities;

public struct Damage : IComponentData
{
    public int Amount;
    public float SqrDistance;
}
