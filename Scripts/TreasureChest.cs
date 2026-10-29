
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    private bool collected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected || !other.CompareTag("Player"))
            return;

        PlayerShooter shooter = other.GetComponent<PlayerShooter>();

        if (shooter != null)
        {
            collected = true;
            shooter.IncreaseAttackSpeed(2f);

            Debug.Log("Baú coletado: ataque 2x mais rápido!");
            Destroy(gameObject);
        }
    }
}
