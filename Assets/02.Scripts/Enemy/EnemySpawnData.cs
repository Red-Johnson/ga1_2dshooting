// 데이터 클래스: 순수하게 데이터 전달 및 보관을 목적으로 만들어진 특별 클래스
// 로직이 있으면 안 되고 데이터만 있어야 함!!!

using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    public GameObject EnemyPrefab;
    public int Weight;
}