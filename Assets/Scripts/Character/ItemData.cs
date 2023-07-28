using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private ItemType type;
    [SerializeField] private int count;

    public ItemType Type { get => type; }
    public int Count { get => count; }
}

public enum ItemType
{
    Coin
}