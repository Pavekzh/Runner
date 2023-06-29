using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController:MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text scoreField;
    [SerializeField] private TMP_Text coinsField;
    [SerializeField] private Button revive;
    [SerializeField] private Button retry;

    public Action OnRevive;

    private void Start()
    {
        revive.onClick.AddListener(Revive);
        retry.onClick.AddListener(Retry);
    }

    public void Execute(int score, int coins)
    {
        Open();
        scoreField.text = score.ToString();
        coinsField.text = coins.ToString();
    }    
    
    private void Open()
    {
        panel.gameObject.SetActive(true);
    }

    private void Close()
    {
        panel.gameObject.SetActive(false);
    }

    private void Revive()
    {
        throw new NotImplementedException();
    }

    private void Retry()
    {
        throw new NotImplementedException();
    }
}
