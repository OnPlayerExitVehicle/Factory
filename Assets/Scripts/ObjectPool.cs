using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool: MonoBehaviour
{
    private List<Stack<GameObject>> pool = new List<Stack<GameObject>>();
    
    private readonly int layerOffset = 8;
    private readonly int maxObjects = 5;

    private Random random = new Random();

    public ObjectPool()
    {
        for (int i = 0; i < 2; i++)
        {
            pool.Add(new Stack<GameObject>());
        }
        
    }
    public GameObject PopWood(WoodType type)
    {
        GameObject wood;
        int typeNumber = (int) type;
        Debug.Log($"{typeNumber}.inci stack'te {pool[typeNumber].Count} obje var");
        if (pool[typeNumber].Count > 1)
        {
            wood = pool[typeNumber].Pop();
            wood.SetActive(true);
            return wood;
        }
        else
        {
            GameObject instanceWood = pool[typeNumber].Pop();
            wood = Instantiate(instanceWood);
            PushWood(instanceWood);
            wood.SetActive(true);
            return wood;
        }
        
    }

    public void PushWood(GameObject gameObject)
    {
        if (pool[gameObject.layer - layerOffset].Count < maxObjects)
        {
            gameObject.SetActive(false);
            pool[gameObject.layer - layerOffset].Push(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log($"{gameObject.layer - layerOffset}.inci stack'e obje eklendi. Artik {pool[gameObject.layer - layerOffset].Count} obje var");
    }
}
