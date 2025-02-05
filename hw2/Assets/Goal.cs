using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    public string scoringPlayer; // Left or Right

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            gameManager.ScorePoint(scoringPlayer);

            Rigidbody ballRb = other.gameObject.GetComponent<Rigidbody>();
            BallController ballController = other.gameObject.GetComponent<BallController>();

            // Stop the ball immediately
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;

            // Reset and relaunch after a delay
            ballController.StartCoroutine(ballController.ResetBall());

            Debug.Log($"{scoringPlayer} Scored! Ball Reset.");
        }
    }
}
