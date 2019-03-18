using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using UnityEngine;

public class SimpleMobStateSystem : ComponentSystem
{
    private struct MobsGroup
    {
        public readonly int Length;
        public ComponentDataArray<SimpleMob> States;
        public ComponentDataArray<Position> Pos;
    }

    [Inject] MobsGroup Mobs;

    protected override void OnUpdate()
    {       
        for (int i = 0; i < Mobs.Length; i++)
        {
            
        }
    }
}
