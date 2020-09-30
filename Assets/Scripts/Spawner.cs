using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using Management;
using Extensions;
using Packages.Rider.Editor.UnitTesting;

                                                                                                                        // Spawner Length = 3.5f
                                                                                                                        // Spawner Width = 1.5f
public class Spawner : BaseObject
{
    // Serialized Fields
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float minWoodLength;
    [SerializeField] private float maxWoodLength;
    [SerializeField] private float minWoodRound;
    [SerializeField] private float maxWoodRound;
    [SerializeField] private Vector3 minSpawnPosition;
    [SerializeField] private Vector3 maxSpawnPosition;
    [SerializeField] private List<Material> materialList;
    [SerializeField] private List<Vector3> scaleList;

    // Default Fields
    private readonly WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    public override void ObjectAwake()
    {
        spawnPosition = transform.position; //
        StartCoroutine(SpawnTimer());
        EventManager.onEvent += Test; //
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            RandomWood();
            yield return waitForSeconds;
        }
    }

    public void Test()
    {
        
    }

    public void RandomWood()
    {
        GameObject wood = Instantiate(woodPrefab, spawnPosition, woodPrefab.transform.rotation);
        wood.SetActive(true);
        wood.transform.localScale = scaleList.Random();
        wood.GetComponent<Renderer>().material = materialList.Random();
    }
}
