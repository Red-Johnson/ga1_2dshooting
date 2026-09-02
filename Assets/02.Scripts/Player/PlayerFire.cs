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
    private float CurrentCoolDown;

    public bool IsAutoFire = false;
    
    private void Update()
    {
        
        if (CurrentCoolDown > 0)
        {
            CurrentCoolDown -= Time.deltaTime;
        }

        if (IsAutoFire == false && Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        
        AutoFire();
        

    }

    private void Fire()
    {
        
        if (CurrentCoolDown <= 0)
        {
            // 총알 프리팹을 생성한다.
            // Instantiate는 프리팹을 복사해서 게임 오브젝트를 생성하고 씬에 넣어주는 기능
            GameObject leftDefaultBullet = Instantiate(DefaultBulletPrefab);
            GameObject leftWeakBullet = Instantiate(WeakBulletPrefab);
            leftDefaultBullet.transform.position = LeftFirePoint.position; // 생성한 총알의 위치를 FirePoint의 위치로
            leftWeakBullet.transform.position = LeftWeakFirePoint.position; // 생성한 총알의 위치를 FirePoint의 위치로
            
            
            
            GameObject rightDefaultBullet = Instantiate(DefaultBulletPrefab);
            GameObject rightWeakBullet = Instantiate(WeakBulletPrefab);
            rightDefaultBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 FirePoint의 위치로
            rightWeakBullet.transform.position = RightWeakFirePoint.position; // 생성한 총알의 위치를 FirePoint의 위치로
            
            CurrentCoolDown = AttackCoolDown;
        }
            
            
    }

    private void AutoFire()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            IsAutoFire = !IsAutoFire;
        }

        if (IsAutoFire == true)
        {
            Debug.Log("자동 발사 모드 실행중...");
            Fire();
        }
    }
}
