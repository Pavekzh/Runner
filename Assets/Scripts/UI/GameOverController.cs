using System;
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
    [SerializeField] private Button retry;

    public Action OnRevive;

    private bool canBeRevived = true;

    private void Start()
    {
        revive.onClick.AddListener(ReviveClick);
        retry.onClick.AddListener(RetryClick);
    }

    public void Execute(int score, int coins,bool canBeRevived)
    {        
        this.canBeRevived = canBeRevived;

        Open();
        scoreField.text = score.ToString();
        coinsField.text = coins.ToString();

    }    
    
    private void Open()
    {
        DeactivateReviveButton();
        panel.gameObject.SetActive(true);

        if(canBeRevived)
            Advertisements.Instance.LoadRewarded(ActivateReviveButton, ShowError);
    }

    private void Close()
    {
        panel.gameObject.SetActive(false);
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
        OnRevive?.Invoke();
        this.Close();
    }

    private void ReviveClick()
    {
        Advertisements.Instance.ShowRewarded(Revive, ShowError);
    }

    private void RetryClick()
    {
        throw new NotImplementedException();
    }
}
