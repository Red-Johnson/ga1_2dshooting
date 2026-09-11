using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;

    // 오브젝트 풀링이란: 오브젝트의 Pool(웅덩이: 창고)을 만들어두고,
    // 그 창고 안에 게임 오브젝트를 미리 필요할 만큼 만들어두고,
    // 필요할 때마다 꺼내서 사용하고 필요가 없으면 반환하는 식으로 (활성화 / 비활성화)
    // 메모리 할당(객체 생성)과 해제(객체 파괴)를 최소화하여 성능을 최적화!

    // 필요 속성
    // 총알 프리팹
    [SerializeField] private Bullet _bulletPrefab;

    // 총알 풀 크기
    [SerializeField] private int _poolSize = 50;

    // 생성한 총알을 담아둘 풀
    private Bullet[] _pool;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 풀을 풀 크기만큼 만든다
        _pool = new Bullet[_poolSize];

        // 풀 크기만큼 총알을 미리 만들어서 집어넣는다.
        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.gameObject.SetActive(false); // 당장 사용하지 않으므로 초기는 비활성화!
            _pool[i] = bullet;
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in _pool)
        {
            // 비활성화 되어있는(즉, 누가 빌려가지 않은) 총알 반환
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                bullet.PlaySound();
                return bullet;
            }
        }

        return null;
    }
}