using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string typeId;
    [SerializeField] private int count;

    public string TypeId { get => typeId; }
    public int Count { get => count; }
}