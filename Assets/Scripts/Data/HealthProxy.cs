using Unity.Entities;
using System;

[Serializable]
public struct Health : IComponentData
{
    public float Amount;
}

public class HealthProxy : ComponentDataProxy<Health>
{
}
