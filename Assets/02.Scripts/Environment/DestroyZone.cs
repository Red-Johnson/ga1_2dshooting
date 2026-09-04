using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //충돌한 다른 게임오브젝트를 가리지 않고 파괴
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}