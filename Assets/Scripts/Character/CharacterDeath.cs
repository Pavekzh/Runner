using System;
using UnityEngine;

public class CharacterDeath:MonoBehaviour
{
    [SerializeField] private int lowerObstacleLayer;
    [SerializeField] private int upperObstacleLayer;
    [SerializeField] private int timesCanBeRevived = 1;

    public bool CanBeRevived
    {
        get => DeathCount <= timesCanBeRevived;
    }

    public int DeathCount { get; private set; } = 0;

    public int LowerObstacleLayer { get => lowerObstacleLayer; }
    public int UpperObstacleLayer { get => upperObstacleLayer; }

    public void Die()
    {
        DeathCount++;        
    }
}
