using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using DG.Tweening;

public class GateModule : BaseObject
{
    [SerializeField] private List<GameObject> doorsList = new List<GameObject>();
    private Tween[] tween = new Tween[2];

    public override void ObjectAwake()
    {
        SetLoops();
    }

    private void SetLoops()
    {   /*
        DOTween.KillAll(true);
        foreach (var door in doorsList)
        {
            tween = door.transform.DOMoveX(door.transform.position.x < 0 ? door.transform.position.x - 1.5f : door.transform.position.x + 1.5f, 0.5f).SetLoops(2, LoopType.Yoyo).SetDelay(5f).OnComplete(() => SetLoops());
        }
        */

        StartCoroutine(GateCoroutine());
    }

    private IEnumerator GateCoroutine()
    {
        while (true)
        {
            tween[0] = doorsList[0].transform.DOMoveX(doorsList[0].transform.position.x + 1.5f, 0.5f)
                .SetLoops(2, LoopType.Yoyo);
            tween[1] = doorsList[1].transform.DOMoveX(doorsList[1].transform.position.x - 1.5f, 0.5f)
                .SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(4);
        }
    }
}
