using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목적: 총알을 위로 움직이고 싶다.
    public float Speed;
    public int Damage;

    private void Start()
    {
    }

    private void Update()
    {
        Vector2 direction = Vector2.up; // new Vector2(1,0);
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    // 트리거 관련 이벤트
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
    }

    // 충돌 관련 이벤트 (Enter -> Stay -> Exit)

    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 대상이 Enemy일 때만 서로를파괴한다!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조


            // 응집도는 높히고, 결합도는 낮춰라
            // 결합도란 묻는 것... 매번 묻는 것 ex) 너 체력 몇이니? 너 체력 몇이니? 너 체력 몇이니?...
            // 무적모드 검사하고
            // 방어력 검사하고.....
            /*
            enemy.Health -= Damage;
            if (enemy.Health <= 0)
            {
                // Enemy 파괴
                Destroy(collision.gameObject);
            }

            // Bullet 파괴
            Destroy(this.gameObject);
            */
            // 이걸 Enemy로 옮겨서 굳이 물어볼 필요가 없게!
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"충돌중이다...!");
    }
}