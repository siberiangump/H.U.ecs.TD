using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public struct MoveData : IComponentData
{
    public float3 Velocity;
    public float Speed;

    public MoveData(float3 velocity, float speed)
    {
        Velocity = velocity;
        Speed = speed;
    }
} 

public class MoveComponent : ComponentDataWrapper<MoveData>
{
    
}
