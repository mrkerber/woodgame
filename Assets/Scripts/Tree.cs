using UnityEngine;

/// <summary>
/// Represents a tree that can be chopped by the player.
/// Each tree has health and drops wood logs when destroyed.
/// </summary>
public class Tree : MonoBehaviour
{
    [Header("Tree Settings")]
    public int health = 3;
    public int woodYield = 2;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    /// <summary>
    /// Called when the player chops this tree.
    /// Reduces health and destroys the tree when health reaches zero.
    /// </summary>
    public void Chop()
    {
        health--;
        Debug.Log($"Tree chopped! Health remaining: {health}");

        if (health <= 0)
        {
            FallAndDestroy();
        }
    }

    private void FallAndDestroy()
    {
        if (gameManager != null)
        {
            gameManager.AddWood(woodYield);
        }

        Debug.Log($"Tree felled! Collected {woodYield} wood.");
        Destroy(gameObject);
    }
}
