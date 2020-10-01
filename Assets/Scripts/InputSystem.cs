using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class InputSystem : BaseObject
{
    [SerializeField] private float sensitivity = .05f;
    [SerializeField] private GameObject controlObject;
    private Touch touch;


    public override void ObjectUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            controlObject.transform.position = new Vector3(Mathf.Clamp(controlObject.transform.position.x + (touch.deltaPosition.x * Time.deltaTime * sensitivity), -1.45f, 1.45f), controlObject.transform.position.y, controlObject.transform.position.z);
        }
    }
}
