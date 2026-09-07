using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3f;
    [SerializeField] private float _delayTime = 1.5f;

    private float _timer;
    private Transform _playerTransform;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _delayTime)
        {
            Move();
        }
    }

    public virtual void Move()
    {
        if (_playerTransform != null)
        {
            Vector2 targetDirection = (_playerTransform.position - transform.position).normalized;

            transform.Translate(targetDirection * _moveSpeed * Time.deltaTime);
        }
    }

    protected abstract void Effect(GameObject targetPlayer);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Effect(other.gameObject);

            Destroy(this.gameObject);
        }
    }
}