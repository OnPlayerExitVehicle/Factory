using System;
using System.Collections.Generic;
using Base;
using UnityEngine;
using Extensions;

namespace Management
{
    [DisallowMultipleComponent]
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private List<BaseObject> baseObjects = new List<BaseObject>();
        
        #region Unity Events
        private void Awake()
        {
            baseObjects.CallEvents( baseObject => baseObject.ObjectAwake());
        }

        private void Start()
        {
            baseObjects.CallEvents(baseObject => baseObject.ObjectStart());
        }

        private void Update()
        {
            baseObjects.CallEvents(baseObject => baseObject.ObjectUpdate());
        }

        private void FixedUpdate()
        {
            baseObjects.CallEvents(baseObject => baseObject.ObjectFixedUpdate());
        }

        private void LateUpdate()
        {
            baseObjects.CallEvents(baseObject => baseObject.ObjectLateUpdate());
        }
        #endregion
    }
}