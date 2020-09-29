using System;
using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Management
{
    [DisallowMultipleComponent]
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private List<BaseObject> baseObjects = new List<BaseObject>();

        private void Awake()
        {
            for (int i = 0; i < baseObjects.Count; i++)
            {
                baseObjects[i].ObjectAwake();
            }
        }

        private void Start()
        {
            for (int i = 0; i < baseObjects.Count; i++)
            {
                baseObjects[i].ObjectStart();
            }
        }

        private void Update()
        {
            for (int i = 0; i < baseObjects.Count; i++)
            {
                baseObjects[i].ObjectUpdate();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < baseObjects.Count; i++)
            {
                baseObjects[i].ObjectFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < baseObjects.Count; i++)
            {
                baseObjects[i].ObjectLateUpdate();
            }
        }
    }
}