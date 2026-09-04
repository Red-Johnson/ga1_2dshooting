using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject DefaultBulletPrefab;
    public GameObject WeakBulletPrefab;

    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    public Transform LeftWeakFirePoint;
    public Transform RightWeakFirePoint;

    public float AttackCoolDown;
    private float _currentCoolDown;

    public bool IsAutoFire = false;

    private void Update()
    {
        if (_currentCoolDown > 0)
        {
            _currentCoolDown -= Time.deltaTime;
        }

        if (IsAutoFire == false && Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        AutoFire();
    }

    private void Fire()
    {
        if (_currentCoolDown <= 0)
        {
            // 총알 프리팹을 생성한다.
            // Instantiate는 프리팹을 복사해서 게임 오브젝트를 생성하고 씬에 넣어주는 기능
            GameObject leftDefaultBullet =
                Instantiate(DefaultBulletPrefab, LeftFirePoint.position, Quaternion.identity);
            GameObject leftWeakBullet = Instantiate(WeakBulletPrefab, LeftWeakFirePoint.position, Quaternion.identity);
            // 게임 오브젝트 생성과 동시에 위치, 회전 값 지정!

            GameObject rightDefaultBullet =
                Instantiate(DefaultBulletPrefab, RightFirePoint.position, Quaternion.identity);
            GameObject rightWeakBullet =
                Instantiate(WeakBulletPrefab, RightWeakFirePoint.position, Quaternion.identity);

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
}