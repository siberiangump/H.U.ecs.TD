using Unity.Entities;
using System;

[Serializable]
public struct PlayerTag : IComponentData
{    
}

public class PlayerTagProxy : ComponentDataProxy<PlayerTag>
{
}
