using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Mathematics;
using Assets.Scripts.MainLogic.Weapons;

public class RotationSystem : ComponentSystem
{
    private struct RotationComponents
    {
        public readonly int Length;
        public ComponentDataArray<Rotation> Rotation;       
    }

  //  [Inject] RotationComponents RotationInject;

    protected override void OnUpdate()
    {
        //for (int i = 0; i < RotationInject.Length; i++)
        //{
        //    Rotation rot = CreaateRotationComponent();
        //    RotationInject.Rotation[i] = rot;
        //}
    }

    private Rotation CreaateRotationComponent()
    {
        Rotation rot = new Rotation();
        rot.Value = quaternion.Euler(PistolBulletConfig.Rotation);
        return rot;
    }
}
