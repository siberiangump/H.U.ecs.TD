using Unity.Entities;
using Unity.Transforms;
using Assets.Scripts.Data.Movement;
using Unity.Mathematics;
using UnityEngine;

public class MoveSystem : ComponentSystem
{
    private struct MoveComponents
    {
        public readonly int Length;
        public ComponentDataArray<Position> Pos;
        public ComponentDataArray<Velocity> Vel;
    }

    [Inject] MoveComponents MoveInject;

    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < MoveInject.Length; i++)
        {
            float3 movObjPos = MoveInject.Pos[i].Value;
            float3 movObjVel = new float3(MoveInject.Vel[i].Value.x, 0, MoveInject.Vel[i].Value.z);
            float3 newPosValue = movObjPos + movObjVel * deltaTime;
            Position newPos = new Position();
            newPos.Value = newPosValue;
            MoveInject.Pos[i] = newPos;
        }
    }
}
