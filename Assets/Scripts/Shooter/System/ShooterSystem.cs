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
                for (int j = 0; j < HealthDataInject.Length; j++)
                {
                    float distance = math.distance(ShooterDataInject.Positions[i].Value.Value, HealthDataInject.Positions[j].Value.Value);
                    if (distance < ShooterDataInject.Shooters[i].Value.Damage)
                    {
                        var health = HealthDataInject.Health[j].Value;
                        health.Health -= ShooterDataInject.Shooters[i].Value.Damage;
                        HealthDataInject.Health[j].Value = health;
                        
                        //EntityManager.RemoveComponent<ShotReadyComponent>(ShooterDataInject.Entities[i]);
                    }
                }
            }
        }
    }
    
    public struct ShooterDataInject
    {
        public readonly int Length;
        //public EntityArray Entities;
        [ReadOnly] public ComponentArray<PositionComponent> Positions;
        [ReadOnly] public ComponentArray<ShooterDataComponent> Shooters;
        //[ReadOnly] public ComponentArray<ShotReadyComponent> ShooterReadyFlags;
    }
    
    public struct HealthDataInject
    {
        public readonly int Length;
        [ReadOnly] public readonly ComponentArray<PositionComponent> Positions;
        public ComponentArray<HealthDataComponent> Health;
    }
}