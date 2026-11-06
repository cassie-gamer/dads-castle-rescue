using UnityEngine;

/// <summary>
/// Dad's Castle Rescue — Dad the Brave Knight.
/// Dad runs and jumps across the castle platforms to rescue light fury
/// from the top of the tallest tower. Works with keyboard (arrows / WASD
/// + Space) and with on-screen touch buttons (call MoveLeft/MoveRight/
/// Jump from UI buttons). Friendly game: no scary enemies.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class DadKnight : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed = 7f;
    public float jumpForce = 13f;
    public float coyoteTime = 0.12f;

    [Header("Health")]
    public int maxHearts = 3;
    public int hearts = 3;

    [Header("Magic shield")]
    public float shieldTime = 5f;
    public bool hasShield;

    [Header("Dad cheers")]
    public string[] dadCheers = {
        "I'm coming, light fury!",
        "Hold on — Dad is on his way!",
        "Nothing stops a brave dad!",
        "Almost there, my little hero!"
    };

    Rigidbody2D rb;
    float moveInput;       // -1, 0, 1 (keyboard or touch buttons)
    float lastGroundedTime;
    float shieldTimer;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hearts = maxHearts;
    }

    void Update()
    {
        // Keyboard steering (touch buttons set moveInput instead).
        float keys = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(keys) > 0.01f) moveInput = keys;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();

        if (isGrounded) lastGroundedTime = Time.time;

        if (hasShield)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0f) hasShield = false;
        }

        // Face the way Dad is running.
        if (moveInput > 0.01f) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
    }

    // --- Touch-button controls (wire these to the on-screen buttons) ---
    public void MoveLeft()  { moveInput = -1f; }
    public void MoveRight() { moveInput = 1f; }
    public void StopMoving() { moveInput = 0f; }

    public void Jump()
    {
        if (Time.time - lastGroundedTime <= coyoteTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            lastGroundedTime = -99f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }

    /// <summary>Called when a barrel or slime bumps into Dad.</summary>
    public void TakeHit()
    {
        if (hasShield) return; // The magic shield protects Dad.
        hearts = Mathf.Max(0, hearts - 1);
        if (hearts <= 0) CastleLevelManager.Instance.RestartLevel();
    }

    public void HealHeart()
    {
        hearts = Mathf.Min(maxHearts, hearts + 1);
    }

    public void GiveShield()
    {
        hasShield = true;
        shieldTimer = shieldTime;
    }

    public string RandomCheer()
    {
        return dadCheers[Random.Range(0, dadCheers.Length)];
    }
}
