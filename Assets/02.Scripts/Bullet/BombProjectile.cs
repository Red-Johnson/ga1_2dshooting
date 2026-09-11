using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    // - 폭탄 속도
    public float moveSpeed = 5f;
    public float travelTime = 1f;
    public GameObject explosionPrefab;

    private float _timer = 0f;

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        _timer += Time.deltaTime;

        if (_timer >= travelTime)
        {
            Detonate();
        }
    }

    private void Detonate()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}