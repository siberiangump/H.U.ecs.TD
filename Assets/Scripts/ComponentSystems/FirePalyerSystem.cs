using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public class FirePalyerSystem : ComponentSystem
{
    private struct PlayerComponents
    {
        public readonly int Length;
        public ComponentDataArray<PlayerTag> Player;
        public SubtractiveComponent<Fire> Fire;
        public EntityArray Entities;
    }

    [Inject] PlayerComponents PlayerInject;

    protected override void OnUpdate()
    {
        for (int i = 0; i < PlayerInject.Length; i++)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire fire = new Fire();
                EntityManager.AddComponentData(PlayerInject.Entities[i], fire);
            }
        }
    }
}
