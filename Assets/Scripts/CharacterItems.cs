using UnityEngine;
using System.Collections.Generic;

public class CharacterItems:MonoBehaviour
{
    [SerializeField] private string coinsTypeId;
    [SerializeField] private int itemsLayer;

    public int ItemsLayer { get => itemsLayer; }

    public Dictionary<string, int> items { get; private set; } = new Dictionary<string, int>();
    public int Coins { get; private set; }

    public void AddItem(ItemData item)
    {
        if (item.TypeId == coinsTypeId)
            Coins += item.Count;
        else
        {
            if (items.ContainsKey(item.TypeId))
                items[item.TypeId] += item.Count;
            else
                items.Add(item.TypeId, item.Count);
        }

    }
}
