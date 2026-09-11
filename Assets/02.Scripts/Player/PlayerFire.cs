using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject DefaultBulletPrefab;
    public GameObject WeakBulletPrefab;

    // - 폭탄 프리팹
    public GameObject BombPrefab;

    // - 폭탄이 발사될 위치
    public Transform BombFirePoint;


    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    public Transform LeftWeakFirePoint;
    public Transform RightWeakFirePoint;

    public float AttackCoolDown;
    private float _currentCoolDown;

    public float BombCoolDown = 10f;
    private float _currentBombCoolDown = 0f;

    public bool IsAutoFire = false;

    private void Update()
    {
        if (_currentCoolDown > 0)
        {
            _currentCoolDown -= Time.deltaTime;
        }

        if (_currentBombCoolDown > 0)
        {
            _currentBombCoolDown -= Time.deltaTime;
        }

        if (IsAutoFire == false && Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            BombFire();
        }

        AutoFire();
    }

    private void Fire()
    {
        if (_currentCoolDown <= 0)
        {
            // 총알 프리팹을 생성한다.
            // Instantiate는 프리팹을 복사해서 게임 오브젝트를 생성하고 씬에 넣어주는 기능

            // Todo: 직접 생성이 아니라 총알 창고에서 총알을 꺼내야 함!

            Bullet leftDefaultBullet = BulletPool.Instance.GetBullet(BulletType.Default);
            leftDefaultBullet.transform.position = LeftFirePoint.position;
            Bullet leftWeakBullet = BulletPool.Instance.GetBullet(BulletType.Weak);
            leftWeakBullet.transform.position = LeftWeakFirePoint.position;


            Bullet rightDefaultBullet = BulletPool.Instance.GetBullet(BulletType.Default);
            rightDefaultBullet.transform.position = RightFirePoint.position;
            Bullet rightWeakBullet = BulletPool.Instance.GetBullet(BulletType.Weak);
            rightWeakBullet.transform.position = RightWeakFirePoint.position;

            _currentCoolDown = AttackCoolDown;
        }
    }

    private void AutoFire()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IsAutoFire = !IsAutoFire;

            if (IsAutoFire)
            {
                Debug.Log("자동 발사 모드 ON");
            }
            else
            {
                Debug.Log("자동 발사 모드 OFF");
            }
        }

        if (IsAutoFire == true)
        {
            Fire();
        }
    }

    private void BombFire()
    {
        if (_currentBombCoolDown <= 0)
        {
            Instantiate(BombPrefab, BombFirePoint.position, BombFirePoint.rotation);
            _currentBombCoolDown = BombCoolDown;
        }
    }
}