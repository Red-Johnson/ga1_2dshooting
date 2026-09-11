using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    // 프리팹의 이름을 키(Key)로, 큐(Queue)를 값(Value)으로 가지는 딕셔너리
    private Dictionary<string, Queue<GameObject>> _pool = new Dictionary<string, Queue<GameObject>>();

    private void Awake() => Instance = this;

    public GameObject GetEnemy(GameObject prefab)
    {
        string key = prefab.name;

        // 1. 해당 몬스터의 창고(큐)가 없다면 새로 만들어줍니다.
        if (!_pool.ContainsKey(key))
        {
            _pool[key] = new Queue<GameObject>();
        }

        // 2. 창고에 남은 몬스터가 있다면 꺼내줍니다.
        if (_pool[key].Count > 0)
        {
            GameObject enemy = _pool[key].Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        // 3. 창고가 비어있다면 새로 만들어서 줍니다.
        else
        {
            GameObject newEnemy = Instantiate(prefab, transform);
            newEnemy.name = key; // 🚨 중요: 반납할 때 키값으로 쓰기 위해 원본 이름과 똑같이 맞춤!
            return newEnemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        string key = enemy.name;
        enemy.SetActive(false);
        _pool[key].Enqueue(enemy); // 창고로 다시 줄 세우기
    }
}