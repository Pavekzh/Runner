using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Authentication:MonoBehaviour
{
    public const string RemindMeKey = "RemindMe";
    public const string AuthDataKey = "AuthData";

    public void SilentLogin(Action onComplete, Action<string> onError)
    {
        AuthData authData = JsonUtility.FromJson<AuthData>(PlayerPrefs.GetString(AuthDataKey));

        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest()
        {
            Email = authData.Email,
            Password = authData.Password,
            TitleId = PlayFabSettings.TitleId
        };

        PlayFabClientAPI.LoginWithEmailAddress(request,
           result =>
           {
               onComplete();
           },
           error =>
           {
               onError(error.ErrorMessage);
           });
    }

    public void LogIn(AuthData authData, Action onComplete, Action<string> onError)
    {
        LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest()
        {
            Email = authData.Email,
            Password = authData.Password,
            TitleId = PlayFabSettings.TitleId
        };

        PlayFabClientAPI.LoginWithEmailAddress(request,
            result =>
            {
                PlayerPrefs.SetString(AuthDataKey, JsonUtility.ToJson(authData));
                onComplete();
            },
            error =>
            {
                onError(error.ErrorMessage);
            });
    }

    public void SignUp(AuthData authData, Action onComplete, Action<string> onError)
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest()
        {
            Email = authData.Email,
            Password = authData.Password,
            DisplayName = authData.Username,
            TitleId = PlayFabSettings.TitleId,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request,
            result =>
            {
                PlayerPrefs.SetString(AuthDataKey, JsonUtility.ToJson(authData));
                onComplete();
            },
            error =>
            {
                onError(error.ErrorMessage);
            });


    }
}

