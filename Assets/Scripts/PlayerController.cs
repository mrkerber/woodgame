using UnityEngine;

/// <summary>
/// Controls the player movement and wood-chopping actions.
/// Use WASD or arrow keys to move, Space to chop nearby trees.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Chopping")]
    public float chopRange = 2f;
    public float chopCooldown = 1f;

    private Rigidbody rb;
    private float lastChopTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lastChopTime = -chopCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryChop();
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (movement.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0f, movement.z));
        }
    }

    void TryChop()
    {
        if (Time.time < lastChopTime + chopCooldown)
        {
            return;
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, chopRange);
        foreach (Collider hit in hits)
        {
            Tree tree = hit.GetComponent<Tree>();
            if (tree != null)
            {
                tree.Chop();
                lastChopTime = Time.time;
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chopRange);
    }
}
