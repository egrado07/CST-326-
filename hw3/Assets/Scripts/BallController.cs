using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    public AudioSource audioSource; // 🎵 Attach an Audio Source in Unity
    public AudioClip resetSound;     // 🎵 Sound when the ball resets
    public AudioClip launchSound;    // 🎵 Sound when the ball is launched
    public AudioClip hitSound;       // 🎵 Sound when the ball hits a paddle
    public AudioClip speedBoostSound; // 🎵 Sound when speed boost is applied

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ResetBall());
    }

    public IEnumerator ResetBall()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = new Vector3(0, 0.5f, 0);

        if (audioSource && resetSound)
        {
            audioSource.PlayOneShot(resetSound); // Play reset sound
        }

        yield return new WaitForSeconds(1f);

        int direction = Random.Range(0, 2) == 0 ? -1 : 1;
        LaunchBall(direction);
    }

    public void LaunchBall(int direction)
    {
        float xDirection = direction;
        float zDirection = Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector3(xDirection, 0, zDirection).normalized * speed;

        if (audioSource && launchSound)
        {
            audioSource.PlayOneShot(launchSound); // Play launch sound
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (audioSource && hitSound)
            {
                audioSource.PlayOneShot(hitSound); // Play sound when hitting a paddle
            }
        }
    }

    public void ApplySpeedBoost(float duration)
    {
        StartCoroutine(SpeedBoostCoroutine(duration));
    }

    private IEnumerator SpeedBoostCoroutine(float duration)
    {
        if (audioSource && speedBoostSound)
        {
            audioSource.PlayOneShot(speedBoostSound); // Play speed boost sound
        }

        float originalSpeed = speed;
        speed *= 1.5f;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }
}
