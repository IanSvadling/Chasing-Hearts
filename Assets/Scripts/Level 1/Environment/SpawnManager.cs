using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs; 
    [SerializeField] private GameObject lifeUp;
    [SerializeField] private GameObject collectibleHearts;

    private float xRange = 19.0f;
    private float startDelayObstacles = 0.8f;
    private float spawnIntervalObstacles = 0.2f;
    private float startDelayRoses = 8.0f;
    private float spawnIntervalRoses = 10.0f;
    private float spawnDelayHearts = 6.0f;
    private float spawnIntervalHearts = 10.0f;
    
    private void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelayObstacles, spawnIntervalObstacles);
        InvokeRepeating("SpawnLifeUps", startDelayRoses, spawnIntervalRoses);
        InvokeRepeating("SpawnCollectibleHearts", spawnDelayHearts, spawnIntervalHearts);
    }

    private void SpawnRandomObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        float spawnRange = Random.Range(-xRange, xRange);

        Instantiate(obstaclePrefabs[obstacleIndex],
            new Vector3(spawnRange, 0, 5),
            GetRandomYaw(obstaclePrefabs[obstacleIndex])
        );
    }

    private void SpawnLifeUps()
    {
        float spawnRange = Random.Range(-xRange, xRange);

        Instantiate(lifeUp, new Vector3(spawnRange, 0, 4), lifeUp.transform.rotation);
    }

    private void SpawnCollectibleHearts()
    {
        float spawnRange = Random.Range(-xRange, xRange);

        Instantiate(collectibleHearts, new Vector3(spawnRange, 0, 4), collectibleHearts.transform.rotation);
    }

    private Quaternion GetRandomYaw(GameObject prefab)
    {
        float randYaw = Random.Range(0.0f, 180.0f);
        return prefab.transform.rotation * Quaternion.Euler(0.0f, randYaw, 0.0f);
    }
}
