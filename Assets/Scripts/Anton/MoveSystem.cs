using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MoveSystem : ComponentSystem
{
    [Inject] SystemInjects Data;
    private const float R2D = 57.29578F;

    public struct SystemInjects
    {
        public readonly int Length;
        //public ComponentArray<Transform> Transform;
        public ComponentDataArray<MoveData> MoveData;
        public ComponentDataArray<Position> Position;
        public ComponentDataArray<Rotation> Rotation;
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < Data.Length; i++)
        {
            Move(i, deltaTime);
            Rotation(i);

            //Transform(i, deltaTime);
        }
    }

    private void Move(int i, float deltaTime)
    {
        Position position = new Position();
        position.Value = Data.Position[i].Value + Data.MoveData[i].Velocity * Data.MoveData[i].Speed * deltaTime;
        Data.Position[i] = position;
    }

    private void Rotation(int i)
    {
        Rotation rotation = new Rotation();
        float angle = math.atan2(-Data.MoveData[i].Velocity.x, Data.MoveData[i].Velocity.y) * R2D;

        float angler = math.atan2(-Data.MoveData[i].Velocity.y, Data.MoveData[i].Velocity.x) * R2D;
        rotation.Value = Quaternion.Euler(0, 0, angle);
        Data.Rotation[i] = rotation;
    }

    private void Transform(int i, float deltaTime)
    {
        //Data.Transform[i].position = (float3) Data.Transform[i].position + Data.MoveData[i].Velocity * Data.MoveData[i].Speed * deltaTime;
        //
        //float angle = math.atan2(-Data.MoveData[i].Velocity.x, Data.MoveData[i].Velocity.y) * R2D;
        //Data.Transform[i].rotation = Quaternion.Euler(0, 0, angle);
    }
}
