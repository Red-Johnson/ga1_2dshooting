using UnityEngine;

public class HomingEnemy : Enemy
{
    private Transform _playerTransform;


    protected override void Move()
    {
        if (_playerTransform == null)
        {
            transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime, Space.World);
            return;
        }

        Vector2 targetDirection = (_playerTransform.position - transform.position).normalized;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);

        transform.Translate(targetDirection * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            _playerTransform = player.GetComponent<Transform>();
        }
    }
}