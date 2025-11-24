using UnityEngine;
public class GameManager : MonoBehaviour
{
    
    public GameObject[] fishPrefabs;
    public Transform[] spawnPoints;

    public float spawnInterval = 2f;
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

    void SpawnFish()
    {
        int fishIndex = Random.Range(0, fishPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(fishPrefabs[fishIndex],
                    spawnPoints[spawnIndex].position,
                    Quaternion.identity);
    }
}