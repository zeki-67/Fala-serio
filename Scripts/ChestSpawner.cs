
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private float spawnInterval = 300f;
    [SerializeField] private float spawnDistance = 4f;

    private Transform player;
    private float timer;

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("ChestSpawner: Player não encontrado!");
        }
    }

    private void Update()
    {
        if (player == null || chestPrefab == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnChest();
            timer = 0f;
        }
    }

    private void SpawnChest()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        if (randomDirection == Vector2.zero)
            randomDirection = Vector2.up;

        Vector2 spawnPosition =
            (Vector2)player.position + randomDirection * spawnDistance;

        Instantiate(chestPrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Um baú apareceu!");
    }
}
