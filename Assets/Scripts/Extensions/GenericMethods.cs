using UnityEngine;
using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class GenericMethods
    {
        public static T Random<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static T Random<T>(this T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public static void CallEvents<T>(this IEnumerable<T> list, Action<T> unityEvent)
        {
            foreach (var item in list)
            {
                unityEvent(item);
            }
        }
    }
}