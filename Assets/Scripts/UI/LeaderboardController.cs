using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Pool;

public class LeaderboardController:MonoBehaviour
{
    [Header("Leaderboard")]
    [SerializeField] private int recordsCount = 10;
    [SerializeField] private string statisticsName;
    [Header("UI")]
    [SerializeField] private MainMenuController mainMenu;
    [SerializeField] private VisibleManager visibleManager;
    [SerializeField] private Button close;
    [SerializeField] private VerticalLayoutGroup layoutGroup;
    [SerializeField] private GameObject recordsPoolParent;
    [SerializeField] private GameObject recordPrefab;

    ObjectPool<GameObject> recordsPool;
    Queue<GameObject> usedRecords;

    private void Start()
    {
        if (recordPrefab.GetComponent<LeaderboardRecord>() == null)
            Debug.LogError("Record prefab must have LeaderboardRecord component");

        recordsPool = new ObjectPool<GameObject>(
            () => Instantiate(recordPrefab, recordsPoolParent.transform),
            record =>
            {
                record.transform.parent = layoutGroup.transform;
                record.SetActive(true);
                usedRecords.Enqueue(record);
            },
            record => 
            {
                record.transform.parent = recordsPoolParent.transform;
                record.SetActive(false);
            });

        usedRecords = new Queue<GameObject>();
        close.onClick.AddListener(Close);
    }

    public void Open()
    {
        Open(0);
    }

    public void Open(int startPosition)
    {
        visibleManager.Open();
        LoadLeaderboard(startPosition);
    }

    public void Close()
    {
        mainMenu.Open();

        visibleManager.Close();
        while (usedRecords.Count > 0)
            recordsPool.Release(usedRecords.Dequeue());
    }

    private void ShowLeaderboard(List<PlayerLeaderboardEntry> leaderboard)
    {
        foreach(PlayerLeaderboardEntry player in leaderboard)
        {
            GameObject record = recordsPool.Get();
            record.GetComponent<LeaderboardRecord>().SetRecord(player.DisplayName, player.StatValue.ToString(),player.Position);
        }
    }

    private void LoadLeaderboard(int startPosition)
    {
        GetLeaderboardRequest request = new GetLeaderboardRequest()
        {
            StartPosition = startPosition,
            StatisticName = statisticsName,
            MaxResultsCount = recordsCount
        };

        PlayFabClientAPI.GetLeaderboard(request, LeaderboardGot, error => Error(error.ErrorMessage));
    }

    private void LeaderboardGot(GetLeaderboardResult result)
    {
        if (result != null)
            ShowLeaderboard(result.Leaderboard);
    }

    private void Error(string message)
    {
        Debug.LogError(message);
    }


}
