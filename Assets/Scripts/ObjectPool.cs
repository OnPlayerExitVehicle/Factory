using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPool: MonoBehaviour
{
    public List<Stack<GameObject>> woodPool = new List<Stack<GameObject>>();
    public List<Stack<GameObject>> logPool = new List<Stack<GameObject>>();
    
    private readonly int layerOffset = 8;
    private readonly int maxWood = 5;
    private readonly int maxLog = 20;
    private readonly Quaternion defaultRotation = Quaternion.Euler(0, 0, 90);

    public ObjectPool()
    {
        for (int i = 0; i < 2; i++)
        {
            woodPool.Add(new Stack<GameObject>());
            logPool.Add(new Stack<GameObject>());
        }
        
    }
    public GameObject PopWood(WoodType type)
    {
        GameObject wood;
        int typeNumber = (int) type;
        
        Debug.Log($"{typeNumber}.inci stack'te {woodPool[typeNumber].Count} obje var");
        if (woodPool[typeNumber].Count > 1)
        {
            wood = woodPool[typeNumber].Pop();
            wood.SetActive(true);
            
            wood.transform.rotation = defaultRotation;
            Rigidbody rigidbody = wood.GetComponent<Rigidbody>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            
            return wood;
        }
        else
        {
            GameObject instanceWood = woodPool[typeNumber].Pop();
            wood = Instantiate(instanceWood);
            PushWood(instanceWood);
            
            wood.SetActive(true);
            return wood;
        }
        
    }

    public GameObject PopLog(WoodType type)
    {
        Debug.Log("LogPOPPED");
        GameObject log;
        int typeNumber = (int) type;
        
        if (logPool[typeNumber].Count > 1)
        {
            log = logPool[typeNumber].Pop();
            log.SetActive(true);
            return log;
        }
        else
        {
            GameObject instanceLog = logPool[typeNumber].Pop();
            log = Instantiate(instanceLog);
            PushLog(instanceLog);
            
            log.SetActive(true);
            return log;
        }
    }

    public void PushWood(GameObject wood)
    {
        if (woodPool[wood.layer - layerOffset].Count < maxWood)
        {
            wood.SetActive(false);
            woodPool[wood.layer - layerOffset].Push(wood);
        }
        else
        {
            Destroy(wood);
        }
        Debug.Log($"{wood.layer - layerOffset}.inci stack'e obje eklendi. Artik {woodPool[wood.layer - layerOffset].Count} obje var");
    }

    public void PushLog(GameObject log)
    {
        if (woodPool[log.layer - layerOffset].Count < maxLog)
        {
            log.SetActive(false);
            logPool[log.layer - layerOffset].Push(log);
        }
        else
        {
            Destroy(log);
        }
    }
}
