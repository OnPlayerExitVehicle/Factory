using UnityEngine;
using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class GenericRandomizer
    {
        public static T Random<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}