using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public GameObject chunkPrefab;
    public Transform player;
    public float chunkSize = 20f;
    public int spawnRange = 1;

    private Dictionary<Vector2Int, GameObject> activeChunks = new Dictionary<Vector2Int, GameObject>();

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

        SpriteRenderer sr = chunkPrefab.GetComponent<SpriteRenderer>();
        if (sr != null)
            chunkSize = sr.bounds.size.x;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Vector2Int currentChunk = new Vector2Int(
            Mathf.FloorToInt(playerPos.x / chunkSize),
            Mathf.FloorToInt(playerPos.y / chunkSize)
        );

        HashSet<Vector2Int> neededChunks = new HashSet<Vector2Int>();

        for (int x = -spawnRange; x <= spawnRange; x++)
        {
            for (int y = -spawnRange; y <= spawnRange; y++)
            {
                Vector2Int chunkCoord = new Vector2Int(currentChunk.x + x, currentChunk.y + y);
                neededChunks.Add(chunkCoord);

                if (!activeChunks.ContainsKey(chunkCoord))
                {
                    Vector3 worldPos = new Vector3(chunkCoord.x * chunkSize, chunkCoord.y * chunkSize, 0);
                    GameObject newChunk = Instantiate(chunkPrefab, worldPos, Quaternion.identity, transform);
                    activeChunks.Add(chunkCoord, newChunk);
                }
            }
        }

        // Destroy chunks that are no longer needed
        List<Vector2Int> chunksToRemove = new List<Vector2Int>();

        foreach (var pair in activeChunks)
        {
            if (!neededChunks.Contains(pair.Key))
            {
                Destroy(pair.Value); // Remove the GameObject
                chunksToRemove.Add(pair.Key); // Mark for removal from dictionary
            }
        }

        foreach (var coord in chunksToRemove)
        {
            activeChunks.Remove(coord);
        }
    }
}
