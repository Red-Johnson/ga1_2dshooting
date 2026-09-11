using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataTableSO", menuName = "Scriptable Objects/EnemySpawnDataTable")]
public class EnemySpawnDataTableSO : ScriptableObject
{
    public EnemySpawnData[] Datas;
}