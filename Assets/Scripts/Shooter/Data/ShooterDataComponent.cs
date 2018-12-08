using System;
using Unity.Entities;

namespace Shooter.Data
{
    [Serializable]
    public struct ShoooterData : IComponentData
    {
        public int Damage;
        public float Radius;
        public float Cooldown;
    }
    
    public class ShooterDataComponent : ComponentDataWrapper<ShoooterData>
    {
    }
}