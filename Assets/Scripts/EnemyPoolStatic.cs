using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolStatic : MonoBehaviour
{
    public GameObject[] Prefabs;

    public static EnemyPoolStatic Instance;

    void Awake()
    {
        Instance = this;
    }
}
