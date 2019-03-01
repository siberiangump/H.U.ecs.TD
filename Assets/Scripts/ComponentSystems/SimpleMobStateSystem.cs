using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using UnityEngine;
using Assets.Scripts.MainLogic.Mobs;
using Assets.Scripts.Data;
using Unity.Mathematics;


public class SimpleMobStateSystem : ComponentSystem
{
    private struct MobsGroup
    {
        public readonly int Length;
        public ComponentDataArray<SimpleMob> States;
        public ComponentDataArray<Position> Pos;
        public ComponentDataArray<Health> Health;
        public ComponentArray<StateViewer> Viewer;
    }

    private struct PlayerGroup
    {
        public readonly int Length;
        public ComponentDataArray<PlayerTag> Tag;
        public ComponentDataArray<Position> Pos;
        public ComponentDataArray<Health> Health;        
    }

    [Inject] MobsGroup Mobs;
    [Inject] PlayerGroup Player;

    protected override void OnUpdate()
    {
        float3 playerPos = Player.Pos[0].Value;
        float playerHealth = Player.Health[0].Amount;

        for (int i = 0; i < Mobs.Length; i++)
        {
            float mobHealth = Mobs.Health[i].Amount;
            if (mobHealth <= 0)
            {
                ChangeState(i, MobState.Death);
                continue;
            }

            if (playerHealth <= 0)
            {
                ChangeState(i, MobState.Idle);
                continue;
            }

            float3 mobPos = Mobs.Pos[i].Value;
            float distanceToPlayer = math.distance(playerPos, mobPos);
            int id = Mobs.States[i].Id;
            if (distanceToPlayer < SimpleMobConfig.DistanceToAtack)
            {
                ChangeState(i, MobState.Atack);
            }
            else
            {
                ChangeState(i, MobState.Idle);
            }
        }
    }

    private void ChangeState(int i, MobState state)
    {
        SimpleMob newMob = new SimpleMob();
        newMob.State = state;
        Mobs.States[i] = newMob;
        Mobs.Viewer[i].CurrentState = state;
    }    
}
