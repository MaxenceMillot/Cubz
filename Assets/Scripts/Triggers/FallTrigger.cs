using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public Transform prefab;
    public int numberOfSpawn = 40;
    [Tooltip("In seconds")]
    public float spawnDelay = 0.4f;
    private void OnTriggerEnter()
    {
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Invoke("SpawnPrefab", spawnDelay);
        }
    }

    void SpawnPrefab()
    {
        float playerPosition = FindObjectOfType<Score>().player.position.z;
        float randomPosition = playerPosition + Random.Range(100.0f, 700.0f);
        Instantiate(prefab, new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(10.0f, 50.0f), randomPosition), Quaternion.identity);
    }
}
