using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Base;
using DG.Tweening;
using Management;
using UnityEditor;
using UnityEngine;

[DisallowMultipleComponent]
public class Saw : BaseObject
{
    [SerializeField] private ObjectPool objectPool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CutBorder"))
        {
            EventManager.OnCuttingStarted();
            GameObject[] logs = new GameObject[2];
            Transform oTransform = other.transform.parent;
            WoodType woodType = (WoodType) other.gameObject.layer - 8;

            logs[0] = objectPool.PopLog((WoodType) other.transform.parent.gameObject.layer - 8);
            logs[1] = objectPool.PopLog((WoodType)other.transform.parent.gameObject.layer - 8);

            float offset = transform.position.x - oTransform.position.x;

            logs[0].transform.localScale = new Vector3(oTransform.localScale.x, oTransform.localScale.y / 2 - Math.Abs(offset), oTransform.localScale.z);
            logs[1].transform.localScale = new Vector3(oTransform.localScale.x, oTransform.localScale.y / 2 - Math.Abs(offset), oTransform.localScale.z);

            if (offset < 0) // Bıçak merkezin solundaysa
            {
                logs[0].transform.position = new Vector3(transform.position.x - ((logs[0].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);
                logs[1].transform.position = new Vector3(transform.position.x + ((logs[1].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);

            }
            else // Bıçak merkezin sağındaysa
            {
                logs[0].transform.position = new Vector3(transform.position.x + ((logs[0].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);
                logs[1].transform.position = new Vector3(transform.position.x - ((logs[1].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);
            }

            

            objectPool.PushWood(other.transform.parent.gameObject);
        }
    }
}
