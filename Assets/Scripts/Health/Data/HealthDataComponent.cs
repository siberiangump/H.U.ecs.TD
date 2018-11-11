﻿using System;
using Unity.Entities;

[Serializable]
public struct HealthData : IComponentData
{
    public int Health;
}

public class HealthDataComponent : ComponentDataWrapper<HealthData> { }
