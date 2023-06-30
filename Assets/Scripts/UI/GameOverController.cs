﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController:MonoBehaviour
{
    [SerializeField] private MessageController messenger;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text scoreField;
    [SerializeField] private TMP_Text coinsField;
    [SerializeField] private Button revive;
    [SerializeField] private Button menu;

    private Action onRevive;

    private PlayerProfile playerProfile;
    private SceneLoader sceneLoader;

    private bool scoreSaved = false;
    private bool coinsSaved = false;

    private bool canBeRevived = true;    
    private int score;
    private int coins;

    public void InitDependecies(PlayerProfile playerProfile,SceneLoader sceneLoader)
    {
        this.playerProfile = playerProfile;
        this.sceneLoader = sceneLoader;
    }

    private void Start()
    {
        revive.onClick.AddListener(ReviveClick);
        menu.onClick.AddListener(MenuClick);
    }


    public void Open(int score, int coins, bool canBeRevived,Action onRevive)
    {
        this.onRevive = onRevive;
        Open(score, coins, canBeRevived);
    }

    public void Open(int score, int coins,bool canBeRevived)
    {
        this.score = score;
        this.coins = coins;
        this.canBeRevived = canBeRevived;

        Open();
        scoreField.text = score.ToString();
        coinsField.text = coins.ToString();

    }    
        
    public void Close()
    {
        panel.gameObject.SetActive(false);
    }

    private void Open()
    {
        DeactivateReviveButton();
        panel.gameObject.SetActive(true);

        if(canBeRevived)
            Advertisements.Instance.LoadRewarded(ActivateReviveButton, ShowError);
    }



    private void DeactivateReviveButton()
    {
        revive.interactable = false;
    }

    private void ActivateReviveButton()
    {
        revive.interactable = true;
    }

    private void ShowError(string message)
    {
        messenger.ShowMessage("Error", message);
    }

    private void Revive()
    {
        onRevive?.Invoke();
    }

    private void Menu()
    {
        if (scoreSaved && coinsSaved)
            sceneLoader.LoadGame();
    }

    private void ReviveClick()
    {
        Advertisements.Instance.ShowRewarded(Revive, ShowError);
    }

    private void MenuClick()
    {
        playerProfile.SaveScore(score,ScoreSaved);
        playerProfile.AddCoins(coins,CoinsSaved);
        menu.interactable = false;
        revive.interactable = false;
    }

    private void ScoreSaved()
    {
        scoreSaved = true;
        Menu();
    }
    private void CoinsSaved()
    {
        coinsSaved = true;
        Menu();
    }
}
