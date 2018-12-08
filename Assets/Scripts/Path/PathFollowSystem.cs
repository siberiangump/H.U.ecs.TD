using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PathFollowSystem : ComponentSystem
{
    [Inject] SystemInjects Data;
    [Inject] MarkerStructData Markers;

    private Unity.Mathematics.Random RandomGenerator = new Unity.Mathematics.Random(12);

    public struct SystemInjects
    {
        public readonly int Length;
        public ComponentDataArray<Position> Position;
        public ComponentDataArray<MoveData> MoveData;
        public ComponentDataArray<PathFollowData> PathFollowData;
    }

    public struct MarkerStructData
    {
        public readonly int Length;
        public ComponentDataArray<MarkerData> Data;
        public ComponentDataArray<Position> Position;
    }

    protected override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;
        int max = 0;
        for (int i = 0; i < Markers.Length; i++)
        {
            max = math.max(max, Markers.Data[i].Id);
        }
        NativeArray<float3> markerPosition = new NativeArray<float3>(max + 1, Allocator.Temp);
        NativeArray<int> markernext = new NativeArray<int>(max + 1, Allocator.Temp);
        for (int i = 0; i < Markers.Length; i++)
        {
            markerPosition[Markers.Data[i].Id] = Markers.Position[i].Value;
            markernext[Markers.Data[i].Id] = Markers.Data[i].Next_1;
        }
        for (int i = 0; i < Data.Length; i++)
        {
            int markerId = Data.PathFollowData[i].TargetId;
            //if (Data.PathFollowData[i].InstantSet == 1)
            //{
            //    InstantSetPosition(i, markernext[markerId], markerPosition[markerId]); 
            //    return;
            //}
            float3 target = markerPosition[markerId] + Data.PathFollowData[i].Displacement;
            float3 vector = target - Data.Position[i].Value;
            vector.z = 0;
            MoveData moveData = new MoveData(math.normalize(vector), Data.MoveData[i].Speed);
            Data.MoveData[i] = moveData;
            if (Data.PathFollowData[i].ReachDistance > math.length(vector))
            {
                Data.PathFollowData[i] = CreateNewPathFollowData(markernext[markerId], Data.PathFollowData[i].ReachDistance);
            }
        }
        markerPosition.Dispose();
        markernext.Dispose();
    }

    private void InstantSetPosition(int i, int next, float3 position)
    {
        Data.Position[i] = new Position() { Value = position };
        Data.PathFollowData[i] = CreateNewPathFollowData(next, Data.PathFollowData[i].ReachDistance);
    }

    private PathFollowData CreateNewPathFollowData(int nextTarget, float reachDistance)
    {
        float3 displacement = RandomGenerator.NextFloat3();
        displacement.x = (displacement.x - .5f) * .5f;
        displacement.y = (displacement.y - .5f) * .5f;
        displacement.z = 0;
        return new PathFollowData(nextTarget, reachDistance, displacement, 0);
    }

    private struct MarkerBufferData
    {
        public Position Position;
        public int Next;
    }
}
