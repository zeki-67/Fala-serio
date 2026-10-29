
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private GameManager gameManager;

    private int currentHealth;
    private float damageCooldown = 1f;
    private float nextDamageTime;
    private bool isDead;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        if (gameManager == null)
            gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isDead || !collision.gameObject.CompareTag("Enemy"))
            return;

        if (Time.time < nextDamageTime)
            return;

        TakeDamage(1);
        nextDamageTime = Time.time + damageCooldown;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Vida do jogador: " + currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;

            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            else
            {
                Debug.LogError("GameManager não encontrado!");
            }
        }
    }
}
