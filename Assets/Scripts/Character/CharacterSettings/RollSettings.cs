using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "RollSettings", menuName = "ScriptableObjects/Character/Roll")]
public class RollSettings : ScriptableObject
{
    [SerializeField] private float rollTime;

    public float RollTime { get => rollTime; set => rollTime = value; }
}