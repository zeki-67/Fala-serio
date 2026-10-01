using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDeath : MonoBehaviour
{
    public int maxHealth = 5;

    private int currentHealth;
    private bool dead;

    private Vector3 spawnPosition;

    private UIDocument deathUI;
    private VisualElement deathScreen;

    private void Start()
    {
        currentHealth = maxHealth;
        spawnPosition = transform.position;

        deathUI = FindFirstObjectByType<UIDocument>();

        if (deathUI != null)
        {
            deathScreen = deathUI.rootVisualElement.Q<VisualElement>("DeathScreen");

            if (deathScreen != null)
            {
                deathScreen.style.display = DisplayStyle.None;
            }
            else
            {
                Debug.LogError("DeathScreen não foi encontrado!");
            }
        }
        else
        {
            Debug.LogError("UIDocument não foi encontrado!");
        }
    }

    public void TakeDamage(int damage)
    {
        if (dead)
            return;

        currentHealth -= damage;

        Debug.Log("Vida do jogador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }

        if (deathScreen != null)
        {
            deathScreen.style.display = DisplayStyle.Flex;
        }
    }

    private void Update()
    {
        if (!dead)
            return;

        if (Input.anyKeyDown)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        currentHealth = maxHealth;
        dead = false;

        transform.position = spawnPosition;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }

        if (deathScreen != null)
        {
            deathScreen.style.display = DisplayStyle.None;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}