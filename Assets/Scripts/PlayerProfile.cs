using System;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerProfile:MonoBehaviour
{
    private const string BestScoreKey = "BestScore";
    private const string CoinsKey = "Coins";

    private bool isUserDataLoading = false;
    private bool isUserProfileLoading = false;
    private bool isUserDataLoaded = false;
    private bool isUserProfileLoaded = false;

    private int bestScore = 0;
    private int coins = 0;
    private string username = "username";

    private Action<int> onBestScoreGot;
    private Action<int> onCoinsGot;
    private Action<string> onUsernameGot;

    public void GetBestScore(Action<int> setResult)
    {
        if (isUserDataLoaded)
            setResult(bestScore);
        else
        {
            if(!isUserDataLoading)
                LoadUserData();

            onBestScoreGot = setResult;
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

            onCoinsGot = setResult;
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
            onUsernameGot = setResult;
        }

    }

    public void SaveScore(int score)
    {
        if(score > this.bestScore)
        {
            this.bestScore = score;
            Dictionary<string, string> data = new Dictionary<string, string>() { { BestScoreKey, score.ToString() } };
            UpdateUserDataRequest request = new UpdateUserDataRequest() { Data = data };
            PlayFabClientAPI.UpdateUserData(request, result => Succes("saving score"), error => Error(error.ErrorMessage));
        }
    }

    public void AddCoins(int coins)
    {
        this.coins += coins;
        Dictionary<string, string> data = new Dictionary<string, string>() { { CoinsKey, this.coins.ToString() } };
        UpdateUserDataRequest request = new UpdateUserDataRequest() { Data = data };
        PlayFabClientAPI.UpdateUserData(request, result => Succes("adding coins"), error => Error(error.ErrorMessage));
    }

    public void TakeCoins(int coins)
    {
        if (this.coins < coins)
            return;

        this.coins -= coins;
        Dictionary<string, string> data = new Dictionary<string, string>() { { CoinsKey, coins.ToString() } };
        UpdateUserDataRequest request = new UpdateUserDataRequest() { Data = data };
        PlayFabClientAPI.UpdateUserData(request, result => Succes("taking coins"), error => Error(error.ErrorMessage));
    }

    private void LoadUserData()
    {
        isUserDataLoading = true;
        GetUserDataRequest request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, GotUserData, error => Error(error.ErrorMessage));
    }

    private void LoadUserProfile()
    {
        isUserProfileLoading = true;
        GetPlayerProfileRequest request = new GetPlayerProfileRequest();
        PlayFabClientAPI.GetPlayerProfile(request, GotUserProfile, error => Error(error.ErrorMessage));
    }

    private void GotUserProfile(GetPlayerProfileResult result)
    {
        if(result != null)
        {
            username = result.PlayerProfile.DisplayName;

            isUserProfileLoaded = true;
            isUserProfileLoading = false;
            onUsernameGot?.Invoke(this.username);
        }

        Debug.Log("Got profile");
    }

    private void GotUserData(GetUserDataResult result)
    {
        if(result != null)
        {
            if(result.Data.ContainsKey(BestScoreKey))
                this.bestScore = Int32.Parse(result.Data[BestScoreKey].Value);
            if (result.Data.ContainsKey(CoinsKey))
                this.coins = Int32.Parse(result.Data[CoinsKey].Value);        
            
            isUserDataLoaded = true;
            isUserDataLoading = false;
            onBestScoreGot?.Invoke(this.bestScore);
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
        Debug.Log(message);
    }
}

