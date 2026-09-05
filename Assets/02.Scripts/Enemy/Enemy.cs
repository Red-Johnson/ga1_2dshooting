using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3;
    [SerializeField] protected int _health = 100;
    public int Damage = 10;

    // Enemy가 드랍하는 아이템 목록
    [SerializeField] private Item _attackSpeedUpItem;
    [SerializeField] private Item _healthUpItem;
    [SerializeField] private Item _moveSpeedUpItem;

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
            int randomDropPercent = Random.Range(1, 101);
            int randomItemPercent = Random.Range(1, 91);

            Item itemToSpawn = null;

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
            Destroy(this.gameObject);

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