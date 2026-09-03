using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목적: 총알을 위로 움직이고 싶다.
    public float Speed;
    public float Damage = 50;

    private void Start()
    {
    }

    private void Update()
    {
        Vector2 direction = Vector2.up; // new Vector2(1,0);
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    // 충돌 관련 이벤트 (Enter -> Stay -> Exit)

    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"충돌해브렀다잉~");


        // 충돌한 대상이 Enemy일 때만 서로를파괴한다!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Health -= Damage;

            if (enemy.Health <= 0)
            {
                // Enemy 파괴
                Destroy(collision.gameObject);
            }

            // Bullet 파괴
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"충돌중이다...!");
    }
}