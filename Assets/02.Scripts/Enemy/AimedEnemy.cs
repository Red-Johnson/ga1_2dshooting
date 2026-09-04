using UnityEngine;

public class AimedEnemy : Enemy
{
    private Vector2 _targetDirection;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            _targetDirection = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        }
        else
        {
            _targetDirection = Vector2.down;
        }
    }

    protected override void Move()
    {
        transform.Translate(_targetDirection * _moveSpeed * Time.deltaTime, Space.World);
    }
}