using UnityEngine;

public class SpawnScript : MonoBehaviour


{
    public GameObject InstantiatedEnemy;
    public EnemyStats reset;
    float spawnTimer = 1.0f;
    public float SpawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= SpawnRate)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        Instantiate(InstantiatedEnemy, transform.position, transform.rotation);
    }
}
