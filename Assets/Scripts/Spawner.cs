using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using Management;
using Extensions;
using Random = System.Random;
                                                                                                                        // Spawner Length = 3.5f
                                                                                                                        // Spawner Width = 1.5f
public class Spawner : BaseObject
{
    private const float SpawnerLength = 3.5f;
    private const float SpawnerWidth = 1.6f;

    // Serialized Fields
    [SerializeField] private List<GameObject> woodPrefabList;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnTime;
    
    //Serialized Collections
    [SerializeField] private List<Material> materialList;
    [SerializeField] private List<Vector3> scaleList;
    
    
    // Default Fields
    private readonly Random random = new Random();
    private ObjectPool objectPool = new ObjectPool();

    public override void ObjectAwake()
    {
        foreach (GameObject woodPrefab in woodPrefabList)
        {
            objectPool.PushWood(woodPrefab);
        }
        
        spawnPosition = transform.position; //
        StartCoroutine(SpawnCoroutine());
        EventManager.onEvent += Test; //
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnRandomWood();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void Test()
    {
        
    }

    private void SpawnRandomWood()
    {
        GameObject wood = objectPool.PopWood((WoodType) random.Next(0, 1));
        wood.transform.position = spawnPosition;
        wood.transform.localScale = scaleList.Random();
        //wood.transform.position = RandomSpawnPosition(transform.localScale);
        Debug.Log(transform.position);
        wood.GetComponent<Renderer>().material = materialList.Random();
    }

    
    /*public Vector3 RandomSpawnPosition(Vector3 scale)
    {
        float horizontalSpace = SpawnerLength - scale.y;
        float verticalSpace = SpawnerWidth - scale.x;
        float randomPositionX = transform.position.x + random.Next(-verticalSpace, verticalSpace);
        float randomPositionZ = transform.position.z + random.Next(-horizontalSpace, horizontalSpace);
        
        return new Vector3(randomPositionX, transform.position.y, randomPositionZ);
    }

    private Transform SetRandomTransform(){}
    */
  
}
