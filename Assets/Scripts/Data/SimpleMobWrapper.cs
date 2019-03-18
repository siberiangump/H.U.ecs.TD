using Unity.Entities;
using System;
using Assets.Scripts.Data;

[Serializable]
public struct SimpleMob : IComponentData
{
    public MobState State;
}

public class SimpleMobWrapper : ComponentDataProxy<SimpleMob>
{
}
