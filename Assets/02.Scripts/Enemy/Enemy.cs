using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3;
    [SerializeField] protected int _health = 100;
    public int Damage = 10;
    private bool _isDead = false;

    // Enemy가 드랍하는 아이템 목록
    [SerializeField] private Item _attackSpeedUpItem;
    [SerializeField] private Item _healthUpItem;
    [SerializeField] private Item _moveSpeedUpItem;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (_isDead) return;
        Move();
    }

    protected abstract void Move();

    public void TakeDamage(int damage)
    {
        if (_isDead) return;

        _health -= damage;

        if (_animator != null)
        {
            _animator.SetTrigger("doHit");
        }


        if (_health <= 0)
        {
            int randomDropPercent = Random.Range(1, 101);
            int randomItemPercent = Random.Range(1, 91);

            Item itemToSpawn = null;

            _isDead = true;

            if (TryGetComponent<Collider2D>(out var col))
            {
                col.enabled = false;
            }

            if (randomDropPercent <= 30)
            {
                if (randomItemPercent <= 30)
                {
                    itemToSpawn = _attackSpeedUpItem;
                }
                else if (randomItemPercent <= 60)
                {
                    itemToSpawn = _healthUpItem;
                }
                else if (randomItemPercent <= 90)
                {
                    itemToSpawn = _moveSpeedUpItem;
                }
            }

            if (itemToSpawn != null)
            {
                Instantiate(itemToSpawn, transform.position, Quaternion.identity);
            }

            // Enemy 파괴
            Destroy(this.gameObject, 0.2f);

            // 일정 확률로 Item 생성
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player health = other.gameObject.GetComponent<Player>();

        if (health != null)
        {
            health.TakeDamage(Damage);

            Destroy(this.gameObject);
        }
    }
}