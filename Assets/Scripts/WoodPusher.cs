using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class WoodPusher : BaseObject
{
    [SerializeField] private ObjectPool objectPool;

    private void OnTriggerEnter(Collider other)
    {
        objectPool.PushLog(other.gameObject);
    }
}
