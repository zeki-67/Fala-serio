
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate = 1f;

    private float baseFireRate;
    [SerializeField] private float attackRange = 10f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Transform target = FindNearestEnemy();

            if (target != null)
            {
                Shoot(target);
                timer = 0f;
            }
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearest = null;
        float nearestDistance = attackRange;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(
                transform.position,
                enemy.transform.position
            );

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }

    private void Awake()
    {
    baseFireRate = fireRate;
    }

    public void IncreaseAttackSpeed(float multiplier)
    {
    fireRate = baseFireRate / multiplier;
    Debug.Log("Velocidade de ataque aumentada!");
    }

    private void Shoot(Transform target)
    {
        GameObject projectile = Instantiate(
            projectilePrefab,
            transform.position,
            Quaternion.identity
        );

        Projectile projectileScript =
            projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.SetTarget(target);
        }
    }
}
