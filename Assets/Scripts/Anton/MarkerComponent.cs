using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public struct MarkerData : IComponentData
{
    public int Id;
    public int Next_1;
}

public class MarkerComponent : ComponentDataWrapper<MarkerData>
{

}
