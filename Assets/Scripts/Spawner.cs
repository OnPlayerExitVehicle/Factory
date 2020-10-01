using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using Management;
using Extensions;
using Random = System.Random;
                                                                                                                        // Spawner Length = 3.5f
                                                                                                                        // Spawner Width = 1.5f
[RequireComponent(typeof(ObjectPool))]
public class Spawner : BaseObject
{
    // Const Fields
    private const float SpawnerLength = 3f;
    private const float SpawnerWidth = 1.6f;

    // Serialized Collections
    [SerializeField] private List<GameObject> woodPrefabList;
    [SerializeField] private List<GameObject> logPrefabList;

    // Serialized Fields
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnTime;
    [SerializeField] private float minWoodRound = 0.25f;
    [SerializeField] private float maxWoodRound = 1f;
    [SerializeField] private float minWoodLength = 0.5f;
    [SerializeField] private float maxWoodLength = 1f;
    
    // Default Fields
    private readonly Random random = new Random();
    private ObjectPool objectPool;

    public override void ObjectAwake()
    {
        objectPool = GetComponent<ObjectPool>();
        foreach (GameObject woodPrefab in woodPrefabList)
        {
            objectPool.PushWood(woodPrefab);
        }

        foreach (GameObject logPrefab in logPrefabList)
        {
            objectPool.PushLog(logPrefab);
        }
        
        spawnPosition = transform.position;
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnRandomWood();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnRandomWood()
    {
        GameObject wood = objectPool.PopWood((WoodType) random.Next(0, 2));
        wood.transform.position = spawnPosition;
        Vector3 scale = Vector3.one;
        wood.transform.localScale = RandomScale();
        wood.transform.position = new Vector3(0, 11, 3.05f) + Vector3.right * UnityEngine.Random.Range(-0.25f, 0.25f);
    }

    private Vector3 RandomScale()
    {
        float round = UnityEngine.Random.Range(minWoodRound, maxWoodRound);
        return new Vector3(round, UnityEngine.Random.Range(minWoodLength, maxWoodLength), round);
    }
    
    /*public Vector3 RandomSpawnPosition(Vector3 scale)
    {
        float horizontalSpace = SpawnerLength - scale.y * 2;
        float verticalSpace = SpawnerWidth - scale.x;
        float randomPositionX = transform.position.x + UnityEngine.Random.Range(-verticalSpace, verticalSpace);

        return new Vector3(randomPositionX, transform.position.y, transform.position.z);
    }*/
}
