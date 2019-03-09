using Unity.Entities;
using Unity.Collections;
using Assets.Scripts.Data;
using UnityEngine;

public class CleanUpByTimeSystem : ComponentSystem
{
    private struct DestroyComponents
    {
        public readonly int Length;
        public EntityArray Entities;
        public ComponentDataArray<DestroyAt> Destroyeble;
    }

    [Inject] DestroyComponents DestroyInject;

    protected override void OnUpdate()
    {        
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < DestroyInject.Length; i++)
        {
            if (DestroyInject.Destroyeble[i].Remains < 0)
            {               
                PostUpdateCommands.DestroyEntity(DestroyInject.Entities[i]);
            }
            else
            {
                DestroyAt destroyAt = new DestroyAt();
                destroyAt.Remains = DestroyInject.Destroyeble[i].Remains - deltaTime;
                DestroyInject.Destroyeble[i] = destroyAt;
            }
        }
    }
}