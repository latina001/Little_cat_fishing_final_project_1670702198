using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fishPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnFish();
            timer = 0f;
        }
    }

    private void SpawnFish()
    {
        int fishIndex = Random.Range(0, fishPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(fishPrefabs[fishIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
