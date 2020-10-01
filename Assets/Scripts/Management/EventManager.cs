using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Management
{
    public static class EventManager
    {
        public delegate void Alert();

        public static event Alert onCuttingStarted;

        public static void OnCuttingStarted()
        {
            onCuttingStarted.Invoke();
        }
    }
}