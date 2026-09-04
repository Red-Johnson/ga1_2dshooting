using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;


    public void TakeDamage(int damage)
    {
        Health -= damage;

        Debug.Log($"[현재 체력] : {Health}");

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}