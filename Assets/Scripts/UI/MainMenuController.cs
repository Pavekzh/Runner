using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuController:MonoBehaviour
{
    [SerializeField] private string RemindMeKey = "RemindMe";
    [Header("Text")]
    [SerializeField] private TMP_Text usernameValue;
    [SerializeField] private TMP_Text bestScoreValue;
    [SerializeField] private TMP_Text coinsValue;
    [Header("Actions")]    
    [SerializeField] private VisibleManager visibleManager;
    [SerializeField] private Button leaderboard;
    [SerializeField] private Button exit;
    [SerializeField] private Button logOut;
    [SerializeField] private LeaderboardController leaderboardController;

    private PlayerProfile playerProfile;
    private SceneLoader sceneLoader;

    public void InitDependencies(PlayerProfile playerProfile,SceneLoader sceneLoader)
    {
        this.playerProfile = playerProfile;
        this.sceneLoader = sceneLoader;
    }

    private void Start()
    {
        playerProfile.GetBestScore(score => bestScoreValue.text = score.ToString());
        playerProfile.GetCoins(coins => coinsValue.text = coins.ToString());
        playerProfile.GetUsername(username => usernameValue.text = username);

        leaderboard.onClick.AddListener(OpenLeaderboard);
        exit.onClick.AddListener(Exit);
        logOut.onClick.AddListener(LogOut);
    }

    public void Close()
    {
        visibleManager.Close();
    }

    public void Open()
    {
        visibleManager.Open();
    }

    private void OpenLeaderboard()
    {
        Close();
        leaderboardController.Open();
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void LogOut()
    {
        PlayerPrefs.SetInt(RemindMeKey,0);
        sceneLoader.LoadStartup();
    }
}

