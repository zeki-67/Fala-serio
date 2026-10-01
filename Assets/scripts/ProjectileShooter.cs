using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float attackInterval = 0.5f;
    public float attackRange = 10f;

    private float attackTimer;

    private void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            Shoot();

            attackTimer = attackInterval;
        }
    }

    private void Shoot()
    {
        Enemy target = FindClosestEnemy();

        if (target == null)
            return;

        GameObject projectile = Instantiate(
            projectilePrefab,
            transform.position,
            Quaternion.identity
        );

        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            Vector3 direction = target.transform.position - transform.position;

            direction.y = 0f;

            projectileScript.SetDirection(direction);
        }
    }

    private Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        Enemy closestEnemy = null;

        float closestDistance = attackRange;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(
                transform.position,
                enemy.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}