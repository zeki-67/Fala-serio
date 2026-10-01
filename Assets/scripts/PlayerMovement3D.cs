using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            rb.linearVelocity.y,
            movement.z * moveSpeed
        );
    }
}