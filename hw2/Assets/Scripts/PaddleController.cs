using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string inputAxis; // Set in Inspector (Vertical or Vertical2)
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis(inputAxis) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + new Vector3(0, 0, move));
    }
}
