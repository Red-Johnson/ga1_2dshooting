using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    [SerializeField] private float _spawnInterval = 3f;

    private float _timer;

    // 생성할 프리팹
    [SerializeField] private Enemy _downEnemyPrefab;
    [SerializeField] private Enemy _aimedEnemyPrefab;
    [SerializeField] private Enemy _homingEnemyPrefab;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;

            _spawnInterval = UnityEngine.Random.Range(1f, 3f); // float: 1 ~ 3
            // int randomInt = Random.Range(1, 3); // int: 1 ~ 2 (Range의 특성! 실수형에는 끝 값 포함, 정수형은 미포함)

            Spawn();
        }
    }

    private void Spawn()
    {
        int randomPercent = Random.Range(1, 101);

        Enemy enemyToSpawn = null;

        if (randomPercent <= 50)
        {
            enemyToSpawn = _downEnemyPrefab;
        }
        else if (randomPercent <= 80)
        {
            enemyToSpawn = _aimedEnemyPrefab;
        }
        else if (randomPercent <= 101)
        {
            enemyToSpawn = _homingEnemyPrefab;
        }

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    }
}