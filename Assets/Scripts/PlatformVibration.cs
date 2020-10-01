using System.Collections;
using System.Collections.Generic;
using Base;
using DG.Tweening;
using Management;
using UnityEngine;

public class PlatformVibration : BaseObject
{
    [SerializeField] private GameObject platform;
    [SerializeField] private float duration = 1.5f;

    public override void ObjectAwake()
    {
        EventManager.onCuttingStarted += Vibrate;
    }

    private void Vibrate()
    {
        platform.transform.DOShakeRotation(duration, 2f, 2);
    }
}
