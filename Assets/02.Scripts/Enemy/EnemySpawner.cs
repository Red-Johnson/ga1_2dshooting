using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    [SerializeField] private float _spawnInterval = 3f;

    private float _timer;

    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;


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
        // 가중치 랜덤 선택
        // 각 아이템에 가중치를 부여, 가중치가 클수록 높은 확률로 선택되도록 한다.

        // 1. 추첨할 수 있는 모든 가중치를 더한다.
        int totalWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        // 2. 전체 가중치 범위에서 랜덤한 정수를 뽑는다.
        int randomWeight = Random.Range(0, totalWeight);

        // 3. 가중치를 누적하면서 선택된 구간을 찾는다.
        int cumulativeWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                GameObject enemy = Instantiate(data.EnemyPrefab);
                enemy.transform.position = transform.position;
                break;
            }
        }
    }
}