using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;


    public void TakeDamage(int damage)
    {
        _health -= damage;

        Debug.Log($"[현재 체력] : {_health}");

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}