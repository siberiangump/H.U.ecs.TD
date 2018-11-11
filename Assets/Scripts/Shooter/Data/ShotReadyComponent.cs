using Unity.Entities;

namespace Shooter.Data
{
    public struct ShotReady : IComponentData
    {
        
    }
    
    public class ShotReadyComponent : ComponentDataWrapper<ShotReady> {}
}