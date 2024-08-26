using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawnerBehavior : MonoBehaviour
{
    public GameObject hazardToSpawn;


    [SerializeField] private Transform[] spawnPoints;


    private void OnEnable()
    {
        CollectableBehavior.onCollectableCollected += SpawnHazardAtRandomLocation;
    }

    private void OnDisable()
    {
        CollectableBehavior.onCollectableCollected -= SpawnHazardAtRandomLocation;
    }


   
    public void SpawnHazardAtRandomLocation()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(hazardToSpawn, spawnPoints[randomIndex]);
        Instantiate(hazardToSpawn, spawnPoints[randomIndex]);
        Instantiate(hazardToSpawn, spawnPoints[randomIndex]);
        Instantiate(hazardToSpawn, spawnPoints[randomIndex]);
        Instantiate(hazardToSpawn, spawnPoints[randomIndex]);
    }
}
