using UnityEngine;
using TMPro;

public class MainMenuController:MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text usernameValue;
    [SerializeField] private TMP_Text bestScoreValue;
    [SerializeField] private TMP_Text coinsValue;


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
    }

    public void Close()
    {
        panel.SetActive(false);
    }
}

