using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3f;
    [SerializeField] protected float _moveStartTimer = 3f;

    private Vector2 _moveDirection;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            _moveDirection = player.transform.position - transform.position;
        }
    }

    private void Update()
    {
        _moveStartTimer -= Time.deltaTime;
    }


    public abstract void Effect();

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}