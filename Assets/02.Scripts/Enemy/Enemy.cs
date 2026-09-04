using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3;
    [SerializeField] protected int _health = 100;
    public int Damage = 10;


    public void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            // Enemy 파괴
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(Damage);

            Destroy(this.gameObject);
        }
    }
}