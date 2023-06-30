using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuController:MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text usernameValue;
    [SerializeField] private TMP_Text bestScoreValue;
    [SerializeField] private TMP_Text coinsValue;
    [SerializeField] private Button leaderboard;
    [SerializeField] private LeaderboardController leaderboardController;

    private PlayerProfile playerProfile;

    public void InitDependencies(PlayerProfile playerProfile)
    {
        this.playerProfile = playerProfile;
    }

    private void Start()
    {
        playerProfile.GetBestScore(score => bestScoreValue.text = score.ToString());
        playerProfile.GetCoins(coins => coinsValue.text = coins.ToString());
        playerProfile.GetUsername(username => usernameValue.text = username);

        leaderboard.onClick.AddListener(OpenLeaderboard);
    }

    public void Close()
    {
        panel.SetActive(false);
    }

    private void OpenLeaderboard()
    {
        leaderboardController.Open();
    }
}

