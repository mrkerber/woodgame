using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Spawns trees in the game world at start and periodically respawns them.
/// Tracks active trees to avoid the cost of FindObjectsOfType each interval.
/// </summary>
public class TreeSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject treePrefab;
    public int maxTrees = 15;
    public float spawnAreaRadius = 22f;
    public float minDistanceFromCenter = 3f;
    public float respawnInterval = 30f;

    private float nextRespawnTime;
    private List<GameObject> activeTrees = new List<GameObject>();

    void Start()
    {
        nextRespawnTime = Time.time + respawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextRespawnTime)
        {
            TryRespawnTree();
            nextRespawnTime = Time.time + respawnInterval;
        }
    }

    private void TryRespawnTree()
    {
        if (treePrefab == null) return;

        activeTrees.RemoveAll(t => t == null);
        if (activeTrees.Count >= maxTrees) return;

        for (int attempt = 0; attempt < 10; attempt++)
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnAreaRadius;
            Vector3 spawnPos = new Vector3(randomCircle.x, 0f, randomCircle.y);

            if (spawnPos.magnitude >= minDistanceFromCenter)
            {
                GameObject tree = Instantiate(treePrefab, spawnPos, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
                activeTrees.Add(tree);
                break;
            }
        }
    }
}
