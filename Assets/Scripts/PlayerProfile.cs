using System;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerProfile:MonoBehaviour
{
    private const string CoinsKey = "Coins";
    private const string BestScoreStatisticName = "BestScore";

    private bool isUserDataLoading = false;
    private bool isUserProfileLoading = false;
    private bool isUserStatsLoading = false;
    private bool isUserStatsLoaded = false;
    private bool isUserDataLoaded = false;
    private bool isUserProfileLoaded = false;

    private int bestScore = 0;
    private int coins = 0;
    private string username = "username";

    private Action<int> onBestScoreGot;
    private Action<int> onCoinsGot;
    private Action<string> onUsernameGot;

    private Action onSavedScore;
    private Action onAddedCoins;
    private Action onTakedCoins;

    public void GetBestScore(Action<int> setResult)
    {
        if (isUserStatsLoaded)
            setResult(bestScore);
        else
        {
            if(!isUserStatsLoading)
                LoadUserStats();

            onBestScoreGot += setResult;
        }

    }

    public void GetCoins(Action<int> setResult)
    {
        if (isUserDataLoaded)
            setResult(coins);
        else
        {
            if (!isUserDataLoading)
                LoadUserData();

            onCoinsGot += setResult;
        }
    }

    public void GetUsername(Action<string> setResult)
    {
        if (isUserProfileLoaded)
            setResult(username);
        else
        {
            if(!isUserProfileLoading)
                LoadUserProfile();
            onUsernameGot += setResult;
        }

    }


    public void SaveScore(int score, Action onComplete)
    {        
        onSavedScore = onComplete;
        SaveScore(score);

    }

    public void AddCoins(int coins, Action onComplete)
    {        
        onAddedCoins = onComplete;
        AddCoins(coins);

    }

    public bool TakeCoins(int coins,Action onComplete)
    {        
        onTakedCoins = onComplete;
        return TakeCoins(coins);
    }

    public void SaveScore(int score)
    {
        if (score > this.bestScore)
        {
            this.bestScore = score;
            UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest()
            {
                Statistics = new List<StatisticUpdate> { new StatisticUpdate() { StatisticName = BestScoreStatisticName, Value = this.bestScore } }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(request,
                result =>
                {
                    onSavedScore?.Invoke();
                    Succes("saving score");
                },
                error => Error(error.ErrorMessage));
        }
        else
            onSavedScore?.Invoke();
    }

    public void AddCoins(int coins)
    {
        this.coins += coins;
        Dictionary<string, string> data = new Dictionary<string, string>() { { CoinsKey, this.coins.ToString() } };
        UpdateUserDataRequest request = new UpdateUserDataRequest() { Data = data };
        PlayFabClientAPI.UpdateUserData(request,
                result =>
                {
                    onAddedCoins?.Invoke();
                    Succes("adding coins");
                },
                error => Error(error.ErrorMessage));
    }

    public bool TakeCoins(int coins)
    {
        if (this.coins < coins)
            return false;

        this.coins -= coins;
        Dictionary<string, string> data = new Dictionary<string, string>() { { CoinsKey, coins.ToString() } };
        UpdateUserDataRequest request = new UpdateUserDataRequest() { Data = data };
        PlayFabClientAPI.UpdateUserData(request,
                result =>
                {
                    onTakedCoins?.Invoke();
                    Succes("taking coins");
                },
                error => Error(error.ErrorMessage));

        return true;
    }


    private void LoadUserStats()
    {
        isUserStatsLoading = true;
        GetPlayerStatisticsRequest request = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(request, GotUserStats, error => 
        {
            isUserStatsLoading = false;
            Error(error.ErrorMessage);
        });
    }

    private void LoadUserData()
    {
        isUserDataLoading = true;
        GetUserDataRequest request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, GotUserData, error =>
        {
            isUserDataLoading = false;
            Error(error.ErrorMessage);
        });
    }

    private void LoadUserProfile()
    {
        isUserProfileLoading = true;
        GetPlayerProfileRequest request = new GetPlayerProfileRequest();
        PlayFabClientAPI.GetPlayerProfile(request, GotUserProfile, 
            error => 
            {
                isUserProfileLoading = false;
                Error(error.ErrorMessage);
            });
    }

    private void GotUserStats(GetPlayerStatisticsResult result)
    {           
        isUserStatsLoaded = true;
        if(result != null)
        {
            StatisticValue bestScore = result.Statistics.Find(stat => stat.StatisticName == BestScoreStatisticName);
            if (bestScore != null)
                this.bestScore = bestScore.Value;


            isUserStatsLoading = false;
            onBestScoreGot?.Invoke(this.bestScore);
        }

        Debug.Log("Got stats");
    }

    private void GotUserProfile(GetPlayerProfileResult result)
    {            
        isUserProfileLoaded = true;
        if(result != null)
        {
            username = result.PlayerProfile.DisplayName;


            isUserProfileLoading = false;
            onUsernameGot?.Invoke(this.username);
        }

        Debug.Log("Got profile");
    }

    private void GotUserData(GetUserDataResult result)
    {            
        isUserDataLoaded = true;
        if(result != null)
        {
            if (result.Data.ContainsKey(CoinsKey))
                this.coins = Int32.Parse(result.Data[CoinsKey].Value);                  

            isUserDataLoading = false;
            onCoinsGot?.Invoke(this.coins);
        }


        Debug.Log("Got data");
    }

    private void Succes(string actionName)
    {
        Debug.Log("Succes "+ actionName);
    }

    private void Error(string message)
    {
        Debug.LogError(message);
    }
}

