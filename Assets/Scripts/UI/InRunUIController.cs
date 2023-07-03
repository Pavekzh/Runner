using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InRunUIController:MonoBehaviour
{
    [SerializeField] private PauseController pause;
    [SerializeField] private VisibleManager visibleManager;
    [SerializeField] private TMP_Text scoreValue;
    [SerializeField] private TMP_Text coinsValue;
    [SerializeField] private Button pauseButton;

    private ScoreCounter scoreCounter;
    private CharacterItems coinsCounter;
    
    public void InitDependencies(ScoreCounter scoreCounter,CharacterItems coinsCounter)
    {
        this.scoreCounter = scoreCounter;
        this.coinsCounter = coinsCounter;
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(Pause);
    }

    private void Update()
    {
        scoreValue.text = scoreCounter.Score.ToString();
        coinsValue.text = coinsCounter.Coins.ToString();
    }

    private void Pause()
    {
        pause.Pause();
    }

    public void Open()
    {
        visibleManager.Open();
    }

    public void Close()
    {
        visibleManager.Close();
    }


}

