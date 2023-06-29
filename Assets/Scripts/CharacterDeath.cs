using System;
using UnityEngine;

public class CharacterDeath:MonoBehaviour
{
    [SerializeField] private int lowerObstacleLayer;
    [SerializeField] private int upperObstacleLayer;
    [SerializeField] private int timesCanBeRevived = 1;

    private int DeathCount = 0;

    private GameOverController gameOver;

    public event Action OnRevived;

    public int LowerObstacleLayer { get => lowerObstacleLayer; }
    public int UpperObstacleLayer { get => upperObstacleLayer; }

    public void InitDependecies(GameOverController gameOverController)
    {
        this.gameOver = gameOverController;
        this.gameOver.OnRevive += () => OnRevived?.Invoke();
    }

    public void Die(int score,int coins)
    {
        DeathCount++;
        gameOver.Execute(score, coins, DeathCount <= timesCanBeRevived);
        
    }
}
