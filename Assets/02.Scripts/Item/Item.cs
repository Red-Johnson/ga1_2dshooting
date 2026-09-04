using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 3;

    private void Update()
    {
    }


    public abstract void Effect();

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}