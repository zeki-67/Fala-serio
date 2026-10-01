using UnityEngine;
using UnityEngine.InputSystem;
public class Move_Player1 : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;
    [SerializeField] private float speed = 5;
    private Rigidbody2D rb;
    private Vector2 movevector;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vidaAtual = vidaMaxima;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movevector = context.ReadValue<Vector2>();
    }
    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        if(vidaAtual <= 0)
        {
            Morrer();
        }
    }
    private void Morrer()
    {
        Debug.Log("Game Over Loser");
        Destroy(gameObject);
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(movevector.x * speed, movevector.y * speed);
    }
}
