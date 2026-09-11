using UnityEngine;

[System.Serializable]
public class ItemSpawnData
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField, Min(0)] private int _weight = 1;

    public Item ItemPrefab => _itemPrefab;
    public int Weight => _weight;
}