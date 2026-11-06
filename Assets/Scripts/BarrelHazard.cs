using UnityEngine;

/// <summary>
/// Dad's Castle Rescue — rolling barrels and friendly bouncy slimes.
/// Barrels roll down the castle slopes and cost Dad a heart if they bump
/// him (unless he has a magic shield). Slimes are friendly: they only
/// bounce Dad gently and never hurt him — they are just in the way.
/// Attach to a barrel or slime (with a trigger Collider2D).
/// </summary>
public class BarrelHazard : MonoBehaviour
{
    public enum HazardKind { RollingBarrel, FriendlySlime }

    [Header("What is this?")]
    public HazardKind kind = HazardKind.RollingBarrel;

    [Header("Barrel")]
    public float rollSpeed = 3f;
    public float rollDirection = -1f; // -1 rolls left, 1 rolls right

    [Header("Slime bounce")]
    public float bounceForce = 9f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (kind == HazardKind.RollingBarrel && rb != null)
        {
            // Roll along the floor.
            rb.velocity = new Vector2(rollDirection * rollSpeed, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var dad = other.GetComponent<DadKnight>();
        if (dad == null) return;

        if (kind == HazardKind.RollingBarrel)
        {
            dad.TakeHit();
            // The barrel bounces away after the bump so Dad can carry on.
            Destroy(gameObject);
        }
        else
        {
            // Friendly slime: a soft bounce, no harm at all.
            var dadRb = other.GetComponent<Rigidbody2D>();
            if (dadRb != null)
                dadRb.velocity = new Vector2(dadRb.velocity.x, bounceForce);
        }
    }
}
