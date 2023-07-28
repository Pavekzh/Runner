using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsSettings", menuName = "ScriptableObjects/Character/Itemes")]
public class ItemsSettings : ScriptableObject
{
    [SerializeField] private ItemType coinsType;
    [SerializeField] private string itemsTag = "Item";

    public ItemType CoinsType { get => coinsType;  }
    public string ItemsTag { get => itemsTag; }
}