using Shooter.Data;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Shooter.System
{
    public class ShooterSystem : ComponentSystem
    {
        [Inject] private ShooterDataInject ShooterDataInject;
        [Inject] private HealthDataInject HealthDataInject;

        protected override void OnUpdate()
        {
            for (int i = 0; i < ShooterDataInject.Length; i++)
            {
                float minDistance = float.MaxValue;
                int? cachedIndex = null;

                for (int j = 0; j < HealthDataInject.Length; j++)
                {
                    float distance = math.distance(ShooterDataInject.Positions[i].Value, HealthDataInject.Positions[j].Value);
                    if (distance < math.min(ShooterDataInject.Shooters[i].Radius, minDistance))
                    {
                        minDistance = distance;
                        cachedIndex = j;
                    }
                }

                if (cachedIndex.HasValue)
                {
                    var health = HealthDataInject.Health[cachedIndex.Value];
                    health.Health -= ShooterDataInject.Shooters[i].Damage;
                    HealthDataInject.Health[cachedIndex.Value] = health;

                    PostUpdateCommands.AddComponent(ShooterDataInject.Entities[i], new ShotCooldown() { Time = ShooterDataInject.Shooters[i].Cooldown });
                    PostUpdateCommands.RemoveComponent<ShotReady>(ShooterDataInject.Entities[i]);
                }
            }
        }
    }

    public struct ShooterDataInject
    {
        public readonly int Length;
        public EntityArray Entities;
        public ComponentDataArray<Position> Positions;
        public ComponentDataArray<ShoooterData> Shooters;
        public ComponentDataArray<ShotReady> ShooterReadyFlags;
    }

    public struct HealthDataInject
    {
        public readonly int Length;
        public readonly ComponentDataArray<Position> Positions;
        public ComponentDataArray<HealthData> Health;
    }
}