using System.Collections.Generic;
using UnityEngine;

public class InfiniteTileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform player;
    public int buffer = 1; // number of extra tiles beyond screen edge

    private int tileSize = 5;
    private Dictionary<Vector2Int, GameObject> spawnedTiles = new Dictionary<Vector2Int, GameObject>();
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
                player = foundPlayer.transform;
            else
                Debug.LogError("Player not assigned and no object tagged 'Player' found.");
        }

        SpriteRenderer sr = tilePrefab.GetComponent<SpriteRenderer>();
        if (sr != null)
            tileSize = Mathf.RoundToInt(sr.bounds.size.x);
    }

    void Update()
    {
        GenerateTilesInView();
    }

    void GenerateTilesInView()
    {
        if (cam == null || player == null || tilePrefab == null)
            return;

        Vector3 camPos = cam.transform.position;
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight;

        int tilesX = Mathf.CeilToInt(camWidth / tileSize) + buffer * 2;
        int tilesY = Mathf.CeilToInt(camHeight / tileSize) + buffer * 2;

        int centerX = Mathf.RoundToInt(camPos.x / tileSize);
        int centerY = Mathf.RoundToInt(camPos.y / tileSize);

        HashSet<Vector2Int> tilesInView = new HashSet<Vector2Int>();

        int startX = centerX - tilesX / 2;
        int startY = centerY - tilesY / 2;

        for (int x = 0; x <= tilesX; x++)
        {
            for (int y = 0; y <= tilesY; y++)
            {
                Vector2Int gridPos = new Vector2Int(startX + x, startY + y);
                tilesInView.Add(gridPos);

                if (!spawnedTiles.ContainsKey(gridPos))
                {
                    Vector3 worldPos = new Vector3(gridPos.x * tileSize, gridPos.y * tileSize, 0);
                    GameObject tile = Instantiate(tilePrefab, worldPos, Quaternion.identity, transform);
                    spawnedTiles[gridPos] = tile;
                }
            }
        }

        // Destroy offscreen tiles
        List<Vector2Int> toRemove = new List<Vector2Int>();
        foreach (var key in spawnedTiles.Keys)
        {
            if (!tilesInView.Contains(key))
                toRemove.Add(key);
        }

        foreach (var key in toRemove)
        {
            Destroy(spawnedTiles[key]);
            spawnedTiles.Remove(key);
        }
    }
}
