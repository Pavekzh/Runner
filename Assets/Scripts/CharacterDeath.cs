using UnityEngine;

public class CharacterDeath:MonoBehaviour
{
    [SerializeField] private int lowerObstacleLayer;
    [SerializeField] private int upperObstacleLayer;

    public int LowerObstacleLayer { get => lowerObstacleLayer; }
    public int UpperObstacleLayer { get => upperObstacleLayer; }
}
