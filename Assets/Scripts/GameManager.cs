using UnityEngine;

/// <summary>
/// Manages global game state including wood inventory and score tracking.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Inventory")]
    public int woodCount = 0;

    [Header("Spawning")]
    public GameObject treePrefab;
    public int initialTreeCount = 10;
    public float spawnRadius = 20f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        if (treePrefab != null)
        {
            SpawnTrees();
        }
    }

    /// <summary>
    /// Adds wood to the player's inventory.
    /// </summary>
    /// <param name="amount">Number of wood logs to add.</param>
    public void AddWood(int amount)
    {
        woodCount += amount;
        Debug.Log($"Wood collected! Total: {woodCount}");
    }

    private void SpawnTrees()
    {
        for (int i = 0; i < initialTreeCount; i++)
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPos = new Vector3(randomCircle.x, 0f, randomCircle.y);

            if (spawnPos.magnitude > 3f)
            {
                Instantiate(treePrefab, spawnPos, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            }
            else
            {
                i--;
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), $"Wood: {woodCount}");
    }
}
