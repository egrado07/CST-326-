using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, PaddleSizeBoost }
    public PowerUpType powerUpType;
    public float effectDuration = 5f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallController ball = other.GetComponent<BallController>();

            if (powerUpType == PowerUpType.SpeedBoost && ball != null)
            {
                ball.ApplySpeedBoost(effectDuration); // Apply speed boost instantly
            }
            else if (powerUpType == PowerUpType.PaddleSizeBoost)
            {
                PaddleController[] paddles = FindObjectsOfType<PaddleController>();
                foreach (PaddleController paddle in paddles)
                {
                    paddle.ApplySizeBoost(1.5f, effectDuration); // Increase paddle size
                }
            }

            Destroy(gameObject); // Remove the power-up after collection
        }
    }
}
