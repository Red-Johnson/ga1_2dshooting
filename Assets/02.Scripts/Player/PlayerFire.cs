using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;

    public Transform LeftFirePoint;
    public Transform RightFirePoint;

    public float AttackCoolDown;
    private float CurrentCoolDown;
    
    private void Update()
    {
        if (CurrentCoolDown > 0)
        {
            CurrentCoolDown -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && CurrentCoolDown <= 0)
        {
            Fire();
            CurrentCoolDown = AttackCoolDown;
        }
        
        
    }

    private void Fire()
    {
        
            // 총알 프리팹을 생성한다.
            // Instantiate는 프리팹을 복사해서 게임 오브젝트를 생성하고 씬에 넣어주는 기능
            GameObject leftBullet = Instantiate(BulletPrefab);
            leftBullet.transform.position = LeftFirePoint.position; // 생성한 총알의 위치를 FirePoint의 위치로
            
            GameObject rightBullet = Instantiate(BulletPrefab);
            rightBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 FirePoint의 위치로
            
    }
}
