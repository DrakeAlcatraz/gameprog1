using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;     
    public Transform player;
    public float spawnRadius = 10f;
    public float timeBetweenSpawns = 2f;  

    private float spawnTimer;
    

    void Update()
    {
         float timepassed = Timer.instance.getTimePassed() / 60;
        spawnTimer += Time.deltaTime;
        if (timepassed >= 5)
        {
            timeBetweenSpawns = 0.1f;
        }

        if (spawnTimer >= timeBetweenSpawns)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomspawn = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = player.position + (Vector3)(randomspawn * spawnRadius);

        float timepassed = Timer.instance.getTimePassed() / 60;
       
        if (timepassed < 1.5f)
        {
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 2)];
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        }
        else if (timepassed > 1.5f && timepassed < 2.5f)
        {
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(2, enemyPrefabs.Length)];
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        }
        else if (timepassed > 2.5f)
        {
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        }

      
    }
}
