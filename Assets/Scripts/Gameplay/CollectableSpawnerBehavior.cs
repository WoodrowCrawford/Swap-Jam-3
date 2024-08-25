
using UnityEngine;

public class CollectableSpawnerBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;


    [SerializeField] private Transform[] spawnPoints;


    private void OnEnable()
    {
        CollectableBehavior.onCollectableCollected += SpawnObjectAtRandomLocation;
    }

    private void OnDisable()
    {
        CollectableBehavior.onCollectableCollected -= SpawnObjectAtRandomLocation;
    }


    private void Start()
    {
        SpawnObjectAtRandomLocation();
    }

    public void SpawnObjectAtRandomLocation()
    {
       int randomIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(objectToSpawn, spawnPoints[randomIndex]);
    }
}
