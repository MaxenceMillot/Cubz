using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    private float distanceBetweenSpawn = 1000f;
    private Transform player;
    private float lastPositionRegistered;
    private float lastObstaclePositionZ;

    private void Start()
    {
        player = gameObject.transform;
        lastPositionRegistered = lastObstaclePositionZ = player.position.z;

        // Call Spawn
        SpawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn obstacles every X distance
        if (player.position.z > lastPositionRegistered + distanceBetweenSpawn)
        {
            // spawn (coroutine?)
            SpawnObstacles();

            // reset countdown
            lastPositionRegistered = player.position.z;
        }
    }

    void SpawnObstacles()
    {
        lastObstaclePositionZ = player.position.z + Random.Range(75.00f, 100.00f);
        // TODO : Create a list of Objects containing prefab, type and position
        // TODO 2 : then, use this to regulate number of identical objects (ex: every 15-20 obstacle add a powerup/ramp
        for (int i = 0; i < 17; i++)
        {
            int randomObjectIndex = (int)Random.Range(0f, obstacles.Length-1);

            // If prefab contains a power up, place it on the ground
            float randomPositionY=1;
            if (!obstacles[randomObjectIndex].GetComponentInChildren<PowerUp>())
                randomPositionY = Random.Range(1.00f, 10.00f);

            float randomPositionZ = lastObstaclePositionZ + Random.Range(30.00f, 75.00f);

            GameObject lastPrefab = Instantiate(obstacles[randomObjectIndex], new Vector3(0, randomPositionY, randomPositionZ), Quaternion.identity);

            lastObstaclePositionZ = randomPositionZ;
        }
    }
}
