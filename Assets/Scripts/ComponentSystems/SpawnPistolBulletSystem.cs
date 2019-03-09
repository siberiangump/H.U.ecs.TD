using Unity.Entities;
using Assets.Scripts.MainLogic.Weapons;
using Unity.Transforms;
using Unity.Mathematics;
using Assets.Scripts.Data.Movement;
using Unity.Rendering;

public class SpawnPistolBulletSystem : ComponentSystem
{
    private EntityArchetype BulletArchetype;

    protected override void OnCreateManager()
    {
        base.OnCreateManager();
        BulletArchetype = EntityManager.CreateArchetype(typeof(RenderMeshProxy), typeof(Damage), typeof(Position), typeof(Rotation), typeof(Velocity), typeof(Scale));
    }

    private struct PistolComponents
    {
        public readonly int Length;
        public ComponentDataArray<Pistol> Pistol;
        public ComponentDataArray<Fire> Fire;
        public ComponentDataArray<Position> Pos;
        public EntityArray Entities;
    }

    private struct SpawnPointComponetnts
    {
        public readonly int Length;
        public ComponentDataArray<PistolSpawnPoint> SpawnPoint;
        public ComponentDataArray<Position> Pos;
    }

    [Inject] PistolComponents PistolInject;
    [Inject] SpawnPointComponetnts SpawnPointInject;
    [Inject] SpawnPistolBulletBarrier Barrier;

    EntityCommandBuffer comandBuffer;

    protected override void OnUpdate()
    {
        for (int i = 0; i < PistolInject.Length; i++)
        {
            for (int j = 0; j < SpawnPointInject.Length; j++)
            {
                if (PistolInject.Pistol[i].Id == SpawnPointInject.SpawnPoint[j].Id)
                {
                    comandBuffer = Barrier.CreateCommandBuffer();
                    SpawnBullet(i, j);

                    comandBuffer.RemoveComponent<Fire>(PistolInject.Entities[i]);
                }
            }
        }
    }

    private void SpawnBullet(int i, int j)
    {
        Damage damage = CreateDamageComponent();
        Position position = CreatePositionComponent(j);
        Velocity vel = CreateVelocityComponent(i, j);
        Rotation rot = CreateRotationComponent();
        Scale scale = CreateScaleComponent();

        Entity bullet = comandBuffer.CreateEntity(BulletArchetype);
        comandBuffer.AddSharedComponent(bullet, WeaponsMeshes.BulletMeshProxy.Value);
        comandBuffer.SetComponent(bullet, damage);
        comandBuffer.SetComponent(bullet, position);
        comandBuffer.SetComponent(bullet, vel);
        comandBuffer.SetComponent(bullet, rot);
        comandBuffer.SetComponent(bullet, scale);
    }    

    private Damage CreateDamageComponent()
    {
        Damage damage = new Damage();
        damage.Amount = WeaponsConfig.PistolBulletDamage;
        return damage;
    }

    private Position CreatePositionComponent(int j)
    {
        Position bulletPos = new Position();
        bulletPos.Value = SpawnPointInject.Pos[j].Value;
        return bulletPos;
    }

    private Velocity CreateVelocityComponent(int i, int j)
    {
        float3 velocity = SpawnPointInject.Pos[j].Value - PistolInject.Pos[i].Value;
        velocity = math.normalize(velocity) * WeaponsConfig.PistolBulletSpeed;
        Velocity velocityComponent = new Velocity();
        velocityComponent.Value = velocity;
        return velocityComponent;
    }

    private Rotation CreateRotationComponent()
    {
        Rotation rot = new Rotation();
        rot.Value = quaternion.Euler(WeaponsConfig.PistolBulletRotation);
        return rot;
    }

    private Scale CreateScaleComponent()
    {
        Scale scale = new Scale();
        scale.Value = WeaponsConfig.PistolBulletScale;
        return scale;
    }
}

public class SpawnPistolBulletBarrier : BarrierSystem { }