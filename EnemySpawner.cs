using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnInterval = 1f;
    public float spawnDistance = 12f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();

            spawnTimer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        if (player == null || enemyPrefab == null)
            return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector3 spawnPosition = player.position;

        spawnPosition.x += randomDirection.x * spawnDistance;
        spawnPosition.z += randomDirection.y * spawnDistance;

        Instantiate(
            enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}