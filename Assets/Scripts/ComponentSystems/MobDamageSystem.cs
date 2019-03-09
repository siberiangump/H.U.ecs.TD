using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Mathematics;

public class MobDamageSystem : ComponentSystem
{
    private struct HealtyMobComponents
    {
        public readonly int Length;
        public ComponentDataArray<Health> Helthes;
        public ComponentDataArray<Position> Pos;
        public SubtractiveComponent<PlayerTag> Player;
    }

    private struct DamageComponents
    {
        public readonly int Length;
        public ComponentDataArray<Damage> Damage;
        public ComponentDataArray<Position> Pos;
        public EntityArray Entities;
    }

    [Inject] HealtyMobComponents MobInject;
    [Inject] DamageComponents DamageInject;
    [Inject] MobDamageSystemBarrier Barrier;

    protected override void OnUpdate()
    {
        EntityCommandBuffer buffer = Barrier.CreateCommandBuffer();
        for (int i = 0; i < MobInject.Length; i++)
        {
            for (int j = 0; j < DamageInject.Length; j++)
            {
                int mobHealth = MobInject.Helthes[i].Amount;
                if (mobHealth < 0)
                    continue;

                float sqrDistance = GetSqrDistance(i, j);

                if (sqrDistance < DamageInject.Damage[j].SqrDistance)
                {
                    TakeDamage(i, j);
                    buffer.DestroyEntity(DamageInject.Entities[j]);
                }
            }
        }
    }

    private float GetSqrDistance(int i, int j)
    {
        float3 mobPos = MobInject.Pos[i].Value;
        float3 damagePos = DamageInject.Pos[j].Value;
        float sqrDistance = math.distancesq(mobPos, damagePos);
        return sqrDistance;
    }

    private void TakeDamage(int i, int j)
    {
        int newHealthAmount = MobInject.Helthes[i].Amount - DamageInject.Damage[j].Amount;
        Health health = new Health();
        health.Amount = newHealthAmount;
        MobInject.Helthes[i] = health;
    }
}

public class MobDamageSystemBarrier : BarrierSystem { }
