using UnityEngine;
using System.Collections; // Required for coroutine

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ResetBall()); // Start with ball reset
    }

   public IEnumerator ResetBall()
{
    rb.linearVelocity = Vector3.zero; // Stop the ball
    transform.position = new Vector3(0, 1, 0); // Make sure it's above the table
    yield return new WaitForSeconds(1f); // Delay before relaunching

    int direction = Random.Range(0, 2) == 0 ? -1 : 1; // Random direction
    LaunchBall(direction);
}


    public void LaunchBall(int direction)
    {
        float xDirection = direction; // -1 or 1 based on who got scored on
        float zDirection = Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector3(xDirection, 0, zDirection).normalized * speed;
    }
}
