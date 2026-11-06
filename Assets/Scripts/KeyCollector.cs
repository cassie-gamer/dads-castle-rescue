using UnityEngine;

/// <summary>
/// Dad's Castle Rescue — golden keys.
/// Dad must collect all the golden keys in a level to unlock the way up:
/// Castle Gardens 5, The Great Hall 7, The Tallest Tower 8 — 20 in all.
/// Attach to each key pickup (with a trigger Collider2D). Also handles
/// heart and magic-shield pickups, which reuse the same pickup shape.
/// </summary>
public class KeyCollector : MonoBehaviour
{
    public enum PickupKind { GoldenKey, Heart, MagicShield }

    [Header("What is this pickup?")]
    public PickupKind kind = PickupKind.GoldenKey;

    [Header("Sparkle")]
    public float spinSpeed = 90f;
    public float bobHeight = 0.15f;
    public float bobSpeed = 2f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Golden keys twinkle and bob so Dad can spot them.
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * bobSpeed) * bobHeight;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var dad = other.GetComponent<DadKnight>();
        if (dad == null) return;

        switch (kind)
        {
            case PickupKind.GoldenKey:
                CastleLevelManager.Instance.CollectKey();
                break;
            case PickupKind.Heart:
                dad.HealHeart();
                break;
            case PickupKind.MagicShield:
                dad.GiveShield();
                break;
        }

        Destroy(gameObject);
    }
}
