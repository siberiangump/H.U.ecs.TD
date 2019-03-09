using Unity.Entities;
using System;

[Serializable]
public struct Health : IComponentData
{
    public int Amount;
}

public class HealthProxy : ComponentDataProxy<Health>
{
}
