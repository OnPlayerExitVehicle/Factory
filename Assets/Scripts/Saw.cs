using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Base;
using UnityEditor;
using UnityEngine;

public class Saw : BaseObject
{
    private float sensitivity = .01f;

    //private readonly float cuttingBorderScale = 0.05f;
    [SerializeField] private ObjectPool objectPool;

    /*public override void ObjectUpdate() // Input sistemine taşınacak
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = new Vector3( Mathf.Clamp(transform.position.x + (touch.deltaPosition.x * Time.deltaTime * sensitivity), -0.9f, 0.9f), transform.position.y, transform.position.z);
        }
    }*/

    public override void ObjectAwake()
    {
        Debug.Log(transform.localScale.y);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CutBorder"))
        {
            GameObject[] logs = new GameObject[2];
            Transform oTransform = other.transform.parent;
            WoodType woodType = (WoodType) other.gameObject.layer - 8;

            logs[0] = objectPool.PopLog((WoodType) other.transform.parent.gameObject.layer - 8);
            logs[1] = objectPool.PopLog((WoodType)other.transform.parent.gameObject.layer - 8);

            float offset = transform.position.x - oTransform.position.x;

            if (offset < 0) // Bıçak merkezin solundaysa
            {
                Debug.Log($"oTransform.position.x={oTransform.position.x}, transform.position.x={transform.position.x}");
                Debug.Log($"$oTransform.localScale.y={oTransform.localScale.y}, offset={offset} ");
                logs[0].transform.localScale = new Vector3(oTransform.localScale.x, oTransform.localScale.y / 2 + offset, oTransform.localScale.z);
                logs[1].transform.localScale = new Vector3(oTransform.localScale.x, oTransform.localScale.y / 2 - offset, oTransform.localScale.z);

                logs[0].transform.position = new Vector3(transform.position.x - ((logs[0].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);
                logs[1].transform.position = new Vector3(transform.position.x + ((logs[1].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);

            }
            else // Bıçak merkezin sağındaysa
            {
                Debug.Log($"oTransform.position.x={oTransform.position.x}, transform.position.x={transform.position.x}");
                Debug.Log($"$oTransform.localScale.y={oTransform.localScale.y}, offset={offset} ");
                logs[0].transform.localScale = new Vector3(oTransform.localScale.x, oTransform.localScale.y / 2 - offset, oTransform.localScale.z);
                logs[1].transform.localScale = new Vector3(oTransform.localScale.x, oTransform.localScale.y / 2 + offset, oTransform.localScale.z);

                logs[0].transform.position = new Vector3(transform.position.x + ((logs[0].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);
                logs[1].transform.position = new Vector3(transform.position.x - ((logs[1].transform.localScale.y) + transform.localScale.y * 2), oTransform.position.y, oTransform.position.z);
            }

            logs[0].GetComponent<Rigidbody>().angularDrag = 10f;
            logs[1].GetComponent<Rigidbody>().angularDrag = 10f;
            objectPool.PushWood(other.transform.parent.gameObject);
        }
    }
}
