using UnityEngine;
using UnityEngine.InputSystem;
public class Move_Player1 : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Rigidbody2D rb;
    private Vector2 movevector;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movevector = context.ReadValue<Vector2>();
    }

    
    void Update()
    {
        rb.linearVelocity = new Vector2(movevector.x * speed, movevector.y * speed);
    }
}
