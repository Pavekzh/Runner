using UnityEngine;

public class CharacterDeath:MonoBehaviour
{
    [SerializeField] private int lowerObstacleLayer;
    [SerializeField] private int upperObstacleLayer;
    [SerializeField] private int groundLayer;

    public int LowerObstacleLayer { get => lowerObstacleLayer; }
    public int UpperObstacleLayer { get => upperObstacleLayer; }
    public int GroundLayer { get => groundLayer; }
}
