using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InRunUIController:MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text scoreValue;
    [SerializeField] private TMP_Text coinsValue;
    [SerializeField] private Button menu;

    private ScoreCounter scoreCounter;
    private CharacterItems coinsCounter;
    
    public void InitDependencies(ScoreCounter scoreCounter,CharacterItems coinsCounter)
    {
        this.scoreCounter = scoreCounter;
        this.coinsCounter = coinsCounter;
    }

    private void Start()
    {
        menu.onClick.AddListener(OpenMenu);
    }

    private void Update()
    {
        scoreValue.text = scoreCounter.Score.ToString();
        coinsValue.text = coinsCounter.Coins.ToString();
    }

    private void OpenMenu()
    {
        throw new NotImplementedException();
    }

    public void Open()
    {
        panel.SetActive(true);
    }

    public void Close()
    {
        panel.SetActive(false);
    }


}

