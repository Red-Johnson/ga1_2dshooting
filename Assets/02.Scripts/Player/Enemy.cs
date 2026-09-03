using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float MoveSpeed;
    public float Health = 100;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    }
}