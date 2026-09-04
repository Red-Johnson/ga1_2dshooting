using UnityEngine;

public class DownEnemy : Enemy
{
    protected override void Move()
    {
        transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
    }
}