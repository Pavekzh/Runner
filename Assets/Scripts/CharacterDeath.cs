using UnityEngine;

public class CharacterDeath:MonoBehaviour
{
    [SerializeField] private int lowerObstacleLayer;
    [SerializeField] private int upperObstacleLayer;

    private GameOverController gameOver;

    public int LowerObstacleLayer { get => lowerObstacleLayer; }
    public int UpperObstacleLayer { get => upperObstacleLayer; }

    public void InitDependecies(GameOverController gameOverController)
    {
        this.gameOver = gameOverController;
    }

    public void Die(int score,int coins)
    {
        gameOver.Execute(score, coins);
    }
}
