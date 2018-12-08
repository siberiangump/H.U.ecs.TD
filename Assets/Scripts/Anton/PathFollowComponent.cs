using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public struct PathFollowData : IComponentData
{
    public int TargetId;
    public float ReachDistance;
    public float3 Displacement;
    public int InstantSet;

    public PathFollowData(int targetId, float reachDistance, float3 displacement, int instantSet)
    {
        TargetId = targetId;
        ReachDistance = reachDistance;
        Displacement = displacement;
        InstantSet = instantSet;
    }
}

public class PathFollowComponent : ComponentDataWrapper<PathFollowData>
{
}