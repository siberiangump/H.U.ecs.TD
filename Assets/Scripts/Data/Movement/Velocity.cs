using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Data.Movement
{
    public struct Velocity : IComponentData
    {
        public float3 Value;
    }
}
