using System;
using UnityEngine;

public class UISwitcher:MonoBehaviour
{
    private MainMenuController mainMenu;
    private InRunUIController inRunUI;
    private GameOverController gameOver;

    public void InitDependencies(MainMenuController mainMenu, InRunUIController inRunUI,GameOverController gameOver)
    {
        this.mainMenu = mainMenu;
        this.inRunUI = inRunUI;
        this.gameOver = gameOver;
    }

    public void OpenInRunUI()
    {
        mainMenu.Close();
        gameOver.Close();
        inRunUI.Open();
    }

    public void OpenGameOver(int score, int coins, bool canBeRevived,Action onRevive)
    {
        gameOver.Open(score, coins, canBeRevived,onRevive);
        inRunUI.Close();
    }

    public void OpenGameOver(int score,int coins,bool canBeRevived)
    {
        gameOver.Open(score, coins, canBeRevived);
        inRunUI.Close();
    }
}

