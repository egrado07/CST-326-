using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;
    public int maxScore = 11; // First to 11 wins

    public TextMeshProUGUI scoreText; // Drag & Drop in Unity Inspector

    public void ScorePoint(string scoringPlayer)
    {
        if (scoringPlayer == "Left")
        {
            leftScore++;
        }
        else if (scoringPlayer == "Right")
        {
            rightScore++;
        }

        UpdateScoreText();

        if (leftScore >= maxScore || rightScore >= maxScore)
        {
            EndGame();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = leftScore + " - " + rightScore;
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over! Winner: " + (leftScore >= maxScore ? "Left Player" : "Right Player"));
        Time.timeScale = 0; // Stop the game
    }
}
