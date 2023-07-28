using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Death",menuName = "ScriptableObjects/Character/Death")]
public class DeathSettings : ScriptableObject
{
    [SerializeField] private string lowerObstacleTag = "Lower obstacle";
    [SerializeField] private string upperObstacleTag = "Upper obstacle";
    [SerializeField] private int timesCanBeRevived = 1;

    public string LowerObstacleTag { get => lowerObstacleTag; }
    public string UpperObstacleTag { get => upperObstacleTag; }
    public int TimesCanBeRevived { get => timesCanBeRevived;  }
}