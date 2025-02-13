using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string inputAxis; // "Vertical" for Left Paddle, "Vertical2" for Right Paddle
    private Rigidbody rb;

    private Vector3 originalSize;
    private float originalSpeed;

    public AudioSource audioSource; // 🎵 Attach an Audio Source in Unity
    public AudioClip hitSound;       // 🎵 Sound when the paddle hits the ball
    public AudioClip powerUpSound;   // 🎵 Sound when a power-up is activated

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSize = transform.localScale;
        originalSpeed = speed;
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis(inputAxis) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + new Vector3(0, 0, move));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (audioSource && hitSound)
            {
                audioSource.PlayOneShot(hitSound); // Play sound when hitting the ball
            }
        }
    }

    // 🔹 Paddle Size Boost (Power-Up)
    public void ApplySizeBoost(float multiplier, float duration)
    {
        StartCoroutine(SizeBoostCoroutine(multiplier, duration));
    }

    private IEnumerator SizeBoostCoroutine(float multiplier, float duration)
    {
        if (audioSource && powerUpSound)
        {
            audioSource.PlayOneShot(powerUpSound); // Play power-up sound
        }

        transform.localScale = new Vector3(originalSize.x, originalSize.y, originalSize.z * multiplier);
        yield return new WaitForSeconds(duration);
        transform.localScale = originalSize;
    }

    // 🔹 Speed Boost (Power-Up)
    public void ApplySpeedBoost(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoostCoroutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier, float duration)
    {
        if (audioSource && powerUpSound)
        {
            audioSource.PlayOneShot(powerUpSound); // Play power-up sound
        }

        speed *= multiplier;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }
}
