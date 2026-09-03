using UnityEngine;

public class DownEnemy : Enemy
{
    private void Start()
    {
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }
}