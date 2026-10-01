using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;

    [Header("Contact Damage")]
    public int damage = 1;
    public float damageCooldown = 0.5f;
    public float damageDistance = 1.2f;

    private Transform player;
    private float damageTimer;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        damageTimer -= Time.deltaTime;

        // Movimento
        Vector3 direction = player.position - transform.position;

        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            direction.Normalize();

            Vector3 newPosition =
                transform.position + direction * speed * Time.deltaTime;

            // Mantém o inimigo na altura do Player.
            newPosition.y = player.position.y;

            transform.position = newPosition;
        }

        // Dano por proximidade
        float distance = Vector3.Distance(
            transform.position,
            player.position
        );

        if (distance <= damageDistance && damageTimer <= 0f)
        {
            PlayerDeath playerHealth =
                player.GetComponent<PlayerDeath>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                damageTimer = damageCooldown;
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}