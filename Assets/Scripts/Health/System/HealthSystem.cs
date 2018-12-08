﻿using System.Collections.Generic;
 using Unity.Entities;
using UnityEngine;

public class HealthSystem : ComponentSystem
{
    [Inject] private Data DataInstance;

    protected override void OnUpdate()
    {
        List<GameObject> toDestroy = new List<GameObject>();
        
        for (int i = 0; i < DataInstance.Length; i++)
        {
            if (DataInstance.Healths[i].Health <= 0)
            {
                toDestroy.Add(DataInstance.GameObjectArray[i]);
            }
        }

        foreach (var gameObject in toDestroy)
        {
            Object.Destroy(gameObject);
        }
    }

    public struct Data
    {
        public readonly int Length;
        public GameObjectArray GameObjectArray;
        public ComponentDataArray<HealthData> Healths;
    }
}
