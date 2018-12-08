using UnityEngine;
using System.Collections;
using Unity.Entities;

namespace Shooter.Data
{
    public struct ShotCooldown : IComponentData
    {
        public float Time;
    }
}
