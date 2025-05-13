using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public GameObject chunkPrefab;
    public Transform player;
    public float chunkSize = 20f; // size of one prefab in world units
    public int spawnRange = 1;    // how many chunks around the player to spawn

    private HashSet<Vector2Int> spawnedChunks = new HashSet<Vector2Int>();

    void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
            else Debug.LogError("Player not assigned and no object tagged 'Player' found.");
        }

        if (chunkPrefab == null)
        {
            Debug.LogError("Chunk Prefab is not assigned.");
            return;
        }

        // Optional: auto-detect chunk size from prefab bounds
        SpriteRenderer sr = chunkPrefab.GetComponent<SpriteRenderer>();
        if (sr != null)
            chunkSize = sr.bounds.size.x; // assumes square prefab
    }

    void Update()
    {
        if (player == null) return;

        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Vector2Int currentChunk = new Vector2Int(
            Mathf.FloorToInt(playerPos.x / chunkSize),
            Mathf.FloorToInt(playerPos.y / chunkSize)
        );

        // Spawn chunks in range around the player
        for (int x = -spawnRange; x <= spawnRange; x++)
        {
            for (int y = -spawnRange; y <= spawnRange; y++)
            {
                Vector2Int chunkCoord = new Vector2Int(currentChunk.x + x, currentChunk.y + y);

                if (!spawnedChunks.Contains(chunkCoord))
                {
                    Vector3 worldPos = new Vector3(chunkCoord.x * chunkSize, chunkCoord.y * chunkSize, 0);
                    Instantiate(chunkPrefab, worldPos, Quaternion.identity, transform);
                    spawnedChunks.Add(chunkCoord);
                }
            }
        }
    }
}
