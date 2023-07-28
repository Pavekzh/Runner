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
    private CharacterModel character;
    
    public void InitDependencies(ScoreCounter scoreCounter,CharacterModel character)
    {
        this.scoreCounter = scoreCounter;
        this.character = character;
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(Pause);
    }

    private void Update()
    {
        scoreValue.text = scoreCounter.Score.ToString();
        coinsValue.text = character.Coins.ToString();
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

