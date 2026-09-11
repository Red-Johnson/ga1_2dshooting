using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3;
    [SerializeField] protected int _health = 100;
    public int Damage = 10;
    private bool _isDead = false;


    [SerializeField] private ItemSpawnDataTableSO _spawnDataTable;
    [SerializeField, Range(0, 100)] private int _itemDropChance = 30;

    private Animator _animator;

    // Todo: 에너미가 공격당할 때 재생시키는 피격 사운드
    public AudioClip DamagedSound;
    private AudioSource _damagedAudioSource;

    // - 생성할 아이템 프리팹들
    [SerializeField] private Item[] _itemPrefabs;

    // - 죽을 때 생성할 이펙트 프리팹
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _damagedAudioSource = GetComponent<AudioSource>();
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

        if (DamagedSound != null)
        {
            _damagedAudioSource.PlayOneShot(DamagedSound);
        }

        _health -= damage;

        if (_animator != null)
        {
            _animator.SetTrigger("doHit");
        }


        if (_health <= 0)
        {
            _isDead = true;

            if (TryGetComponent<Collider2D>(out var col))
            {
                col.enabled = false;
            }

            int randomPercent = Random.Range(1, 101);
            if (randomPercent <= _itemDropChance)
            {
                if (_spawnDataTable != null)
                {
                    Item itemPrefab = GetRandomItemPrefab();
                    if (itemPrefab != null)
                    {
                        Item item = Instantiate(itemPrefab);
                        item.transform.position = transform.position;
                    }
                }
            }


            // 점수 증가
            GameObject smObject = GameObject.Find("ScoreManager");
            if (smObject != null)
            {
                ScoreManager scoreManager = smObject.GetComponent<ScoreManager>();
                scoreManager.CurrentScore++;
            }


            // Enemy 파괴
            Destroy(this.gameObject, 0.2f);
            SpawnDeathEffect();
        }
    }

    private Item GetRandomItemPrefab()
    {
        ItemSpawnData[] spawnDatas = _spawnDataTable.SpawnDatas;
        if (spawnDatas == null || spawnDatas.Length == 0)
        {
            return null;
        }

        int totalWeight = 0;
        foreach (ItemSpawnData data in spawnDatas)
        {
            if (data == null || data.ItemPrefab == null || data.Weight <= 0)
            {
                continue;
            }

            totalWeight += data.Weight;
        }

        if (totalWeight <= 0)
        {
            return null;
        }

        int randomWeight = Random.Range(0, totalWeight);

        int cumulativeWeight = 0;
        foreach (ItemSpawnData data in spawnDatas)
        {
            if (data == null || data.ItemPrefab == null || data.Weight <= 0)
            {
                continue;
            }

            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                return data.ItemPrefab;
            }
        }

        return null;
    }

    private void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player health = other.gameObject.GetComponent<Player>();

        if (health != null)
        {
            health.TakeDamage(Damage);

            SpawnDeathEffect();

            Destroy(this.gameObject);
        }
    }
}