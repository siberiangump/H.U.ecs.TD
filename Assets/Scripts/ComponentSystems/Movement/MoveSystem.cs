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
        for (int i = 0; i < MoveInject.Length; i++)
        {
            float3 newPosValue = MoveInject.Pos[i].Value + MoveInject.Vel[i].Value;
            Position newPos = new Position();
            newPos.Value = newPosValue * Time.deltaTime;
            MoveInject.Pos[i] = newPos ;
        }
    }
}
