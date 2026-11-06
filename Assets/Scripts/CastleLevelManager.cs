using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Dad's Castle Rescue — level manager.
/// 3 levels, 20 golden keys in all:
///   Level 1 — Castle Gardens: 5 keys
///   Level 2 — The Great Hall: 7 keys
///   Level 3 — The Tallest Tower: 8 keys
/// Collect every key in a level to unlock the door up. On the top of the
/// tallest tower Dad finds light fury waving, and the game ends with hugs
/// and a "Best Dad in the Whole Kingdom!" trophy.
/// </summary>
public class CastleLevelManager : MonoBehaviour
{
    public static CastleLevelManager Instance { get; private set; }

    [Header("Levels (keys needed per level)")]
    public int[] keysPerLevel = { 5, 7, 8 };
    public string[] levelNames = { "Castle Gardens", "The Great Hall", "The Tallest Tower" };

    [Header("Current level (0 = Gardens, 1 = Great Hall, 2 = Tallest Tower)")]
    public int levelIndex;

    public int keysCollected;
    public int keysTotal { get { return keysPerLevel[levelIndex]; } }
    public bool levelComplete;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        keysCollected = 0;
        levelComplete = false;
    }

    /// <summary>Called by KeyCollector when Dad picks up a golden key.</summary>
    public void CollectKey()
    {
        if (levelComplete) return;
        keysCollected++;

        if (keysCollected >= keysTotal)
            CompleteLevel();
    }

    void CompleteLevel()
    {
        levelComplete = true;

        if (levelIndex >= 2)
        {
            // The rescue! Light fury is waving at the top of the tower.
            WinGame();
        }
        else
        {
            // Unlock the door up and move Dad to the next level.
            levelIndex++;
            SceneManager.LoadScene("Level" + (levelIndex + 1));
        }
    }

    void WinGame()
    {
        // Show the win screen: hugs, confetti and the trophy.
        // Hook your win UI up here, e.g. winPanel.SetActive(true).
        Debug.Log("Best Dad in the Whole Kingdom! Dad rescued light fury!");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public string CurrentLevelName()
    {
        return levelNames[levelIndex];
    }

    public int TotalKeysInGame()
    {
        int total = 0;
        foreach (int k in keysPerLevel) total += k;
        return total; // 20
    }
}
