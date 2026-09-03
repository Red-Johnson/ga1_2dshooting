using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private void Start()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
    }
}