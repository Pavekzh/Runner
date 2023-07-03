using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisements:MonoBehaviour,IUnityAdsInitializationListener,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] private bool testMode = false;

#if UNITY_ANDROID
    public const string GameId = "5331084";
    public const string RewardedUnit = "Rewarded_Android";
    public const string InterstitialUnit = "Interstitial_Android";
    public const string BannerUnit = "Banner_Android";
#elif UNITY_IOS
    public const string GameId = "5331085";
    public const string RewardedUnit = "Rewarded_iOS";
    public const string InterstitialUnit = "Interstitial_iOS";
    public const string BannerUnit = "Banner_iOS";
#endif

    public static Advertisements Instance { get; private set; }

    Action onLoadedRewarded;
    Action<string> onFailedLoadRewarded;

    Action onRewardedCompleted;
    Action<string> onRewardedError;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Second instance of Advertisements: " + gameObject.name);
        else
            Instance = this;
    }

    private void Start()
    {
        Advertisement.Initialize(GameId, testMode, this);
    }
    
    public void LoadRewarded(Action onLoaded,Action<string> onFail)
    {        
        onLoadedRewarded = onLoaded;
        onFailedLoadRewarded = onFail;

        Advertisement.Load(RewardedUnit, this);

    }

    public void ShowRewarded(Action onComplete,Action<string> onError)
    {
        onRewardedCompleted = onComplete;
        onRewardedError = onError;

        Advertisement.Show(RewardedUnit, this);
    }


    public void OnUnityAdsAdLoaded(string placementId)
    {
        onLoadedRewarded();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        onFailedLoadRewarded(message);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        onRewardedError(message);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        onRewardedCompleted();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("AdStarted");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("AdClick");
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Advertisements initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError(message);
    }
}
