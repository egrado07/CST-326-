using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    public void ScorePoint(string player)
    {
        if (player == "Left") leftScore++;
        else rightScore++;

        Debug.Log($"Score: Left {leftScore} - Right {rightScore}");

        if (leftScore == 11 || rightScore == 11)
        {
            Debug.Log($"Game Over, {player} Paddle Wins!");
            leftScore = 0;
            rightScore = 0;
        }
    }
}
