using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float Speed;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }
}