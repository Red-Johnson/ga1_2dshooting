using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public float ExplosionDuration = 3f;
    private float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= ExplosionDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(9999);
        }
    }
}