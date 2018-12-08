using Shooter.Data;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Shooter.System
{
    public class ShotCooldownSystem : ComponentSystem
    {
        [Inject] private ShotCooldownInject ShotCooldownInject;

        protected override void OnUpdate()
        {
            for (int i = 0; i < ShotCooldownInject.Length; i++)
            {
                ShotCooldown shotCooldown = ShotCooldownInject.ShotCooldown[i];
                shotCooldown.Time -= Time.deltaTime;
                ShotCooldownInject.ShotCooldown[i] = shotCooldown;

                if (shotCooldown.Time <= 0)
                {
                    PostUpdateCommands.AddComponent(ShotCooldownInject.Entities[i], new ShotReady());
                    PostUpdateCommands.RemoveComponent<ShotCooldown>(ShotCooldownInject.Entities[i]);
                }
            }
        }
    }

    public struct ShotCooldownInject
    {
        public readonly int Length;
        public EntityArray Entities;
        public ComponentDataArray<ShotCooldown> ShotCooldown;
    }
}