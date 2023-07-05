using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseController:MonoBehaviour
{
    [SerializeField] private VisibleManager visibleManager;    
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;

    private bool isPaused;

    private SceneLoader sceneLoader;

    public void InitDependencies(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    private void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(Menu);
    }

    private void Open()
    {
        visibleManager.Open();
    }

    private void Close()
    {
        visibleManager.Close();
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Open();
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    private void Resume()
    {
        if (isPaused)
        {
            Close();
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    private void Menu()
    {
        sceneLoader.LoadGame();
        Time.timeScale = 1;
    }
}

