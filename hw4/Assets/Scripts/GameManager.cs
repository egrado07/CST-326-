using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { get; private set; } = 1;
    public int stage { get; private set; } = 1;
    public int lives { get; private set; } = 3;
    public int coins { get; private set; } = 0;
    private float levelTime = 300f;  // 5 minutes

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        coinsText = GameObject.Find("CoinsText").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        UpdateUI();
        InvokeRepeating(nameof(UpdateTimer), 1f, 1f); // Calls UpdateTimer() every second
    }

    private void UpdateTimer()
    {
        levelTime -= 1f;
        timerText.text = $"TIME: {Mathf.Max(0, Mathf.FloorToInt(levelTime))}";

        if (levelTime <= 0)
        {
            ResetLevel();
        }
    }

    public void AddCoin()
    {
        coins++;
        coinsText.text = $"COINS: {coins:D2}";

        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddScore(int amount)
    {
        int score = int.Parse(scoreText.text.Replace("SCORE: ", ""));
        score += amount;
        scoreText.text = $"SCORE: {score:D6}";
    }

    public void AddLife()
    {
        lives++;
    }

    private void UpdateUI()
    {
        scoreText.text = "SCORE: 000000";
        coinsText.text = "COINS: 00";
        timerText.text = $"TIME: {Mathf.Max(0, Mathf.FloorToInt(levelTime))}";
    }

   public void ResetLevel()
{
    lives--; // Decrease lives when resetting level

    if (lives > 0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    else
    {
        GameOver();
    }
}

// This allows calls with a delay (Fixes error)
public void ResetLevel(float delay)
{
    CancelInvoke(nameof(ResetLevel));
    Invoke(nameof(ResetLevel), delay);
}

    public void LoadLevel(int world, int stage)
{
    this.world = world;
    this.stage = stage;

    SceneManager.LoadScene($"{world}-{stage}");
}
public void GameOver()
{
    Debug.Log("Game Over! Restarting Game...");
    NewGame(); // Restart game when player runs out of lives
}
public void NewGame()
{
    Debug.Log("Starting a New Game...");
    lives = 3;
    coins = 0;
    levelTime = 300f;  // Reset timer to 5 minutes
    UpdateUI();
    LoadLevel(1, 1);
}


}
