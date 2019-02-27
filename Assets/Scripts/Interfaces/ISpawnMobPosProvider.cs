using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ISpawnMobPosProvider
    {
        Vector3 GetPos(int roomIndex);
    }
}
