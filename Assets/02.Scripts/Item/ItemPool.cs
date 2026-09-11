using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    public static ItemPool Instance;
    private Dictionary<string, Queue<Item>> _pool = new Dictionary<string, Queue<Item>>();

    private void Awake() => Instance = this;

    public Item GetItem(Item prefab)
    {
        string key = prefab.name;

        if (!_pool.ContainsKey(key))
        {
            _pool[key] = new Queue<Item>();
        }

        if (_pool[key].Count > 0)
        {
            Item item = _pool[key].Dequeue();
            item.gameObject.SetActive(true);
            return item;
        }

        else
        {
            Item newItem = Instantiate(prefab, transform);
            newItem.name = key;
            return newItem;
        }
    }

    public void ReturnItem(Item item)
    {
        string key = item.name;
        item.gameObject.SetActive(false);
        _pool[key].Enqueue(item);
    }
}