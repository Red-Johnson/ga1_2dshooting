using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    // - 데이터 은닉
    // - 메서드를 통한 상태 변경
    [SerializeField] private int _health = 100;

    public int Health
    {
        get { return _health; }
    }
    // public int Health => _health;    람다식 문법을 활용한 읽기 전용 프로퍼티 (위의 get과 동일한 효과)

    // 잘 설계된 클래스는
    // - 필드 (인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게 막고, 정상적으로 동작하는 메서드

    // getter/setter : 특정 데이터를 get/set 해주는 메서드
    public int GetHealth()
    {
        return _health;
    }

    [SerializeField] private GameObject _deathEffectPrefab;
    [SerializeField] private GameObject _hitEffectPrefab;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        Debug.Log($"[현재 체력] : {_health}");

        if (_health <= 0)
        {
            SpawnDeathEffect();
            Destroy(this.gameObject);
        }
        else
        {
            SpawnHitEffect();
        }
    }

    private void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    private void SpawnHitEffect()
    {
        Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
    }

    public void Heal()
    {
        if (_health < 100)
        {
            if (_health + 10 > 100)
            {
                _health = 100;
            }
            else
            {
                _health += 10;
            }

            Debug.Log($"[체력 회복]");
        }
    }
}