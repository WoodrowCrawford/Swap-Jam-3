using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    public GameObject enemyToSpawn;


    [SerializeField] private Transform[] spawnPoints;


    private void OnEnable()
    {
        CollectableBehavior.onCollectableCollected += SpawnEnemyAtRandomLocation;
    }

    private void OnDisable()
    {
        CollectableBehavior.onCollectableCollected -= SpawnEnemyAtRandomLocation;
    }


    private void Start()
    {
        SpawnEnemyAtRandomLocation();
    }

    public void SpawnEnemyAtRandomLocation()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyToSpawn, spawnPoints[randomIndex]);
    }
}
