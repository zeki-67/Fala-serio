
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private int damage = 1;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction =
            ((Vector2)target.position - (Vector2)transform.position).normalized;

        transform.position +=
            (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        EnemyHealth health = other.GetComponent<EnemyHealth>();

        if (health != null)
            health.TakeDamage(damage);

        Destroy(gameObject);
    }

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
