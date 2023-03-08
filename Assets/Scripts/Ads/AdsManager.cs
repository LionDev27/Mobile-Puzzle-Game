using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] bool _testMode = true;

#if Unity_IOS
    private string _gameId = "5196496";
    private string _interstitialAd = "Interstitial_iOS";
#else
    private string _gameId = "5196497";
    private string _interstitialAd = "Interstitial_Android";
#endif

    [Tooltip("En segundos, cuánto tiempo tiene que pasar para que salte un anuncio")]
    [SerializeField] private float _timeToShowAd;
    private float _showAdDelta;

    void Awake()
    {
        InitializeAds();
    }

    private void Update()
    {
        if(_showAdDelta < _timeToShowAd)
        {
            _showAdDelta += Time.deltaTime;
        }
        else
        {
            _showAdDelta = 0;
            ShowVideoAd();
        }
    }

    public void InitializeAds()
    {
        Advertisement.Initialize(_gameId, _testMode, this);
        LoadVideoAd();
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    private void LoadVideoAd()
    {
        if (Advertisement.isInitialized)
        {
            Debug.Log("Loading Ad: " + _interstitialAd);
            Advertisement.Load(_interstitialAd, this);
        }
    }

    [ContextMenu("Show Ad")]
    public void ShowVideoAd()
    {
        Debug.Log("Showing Ad: " + _interstitialAd);
        Advertisement.Show(_interstitialAd, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Loaded Ad: " + _interstitialAd);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Failed to load Ad: " + _interstitialAd);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Failed to show Ad: " + _interstitialAd);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }
    public void OnUnityAdsShowClick(string placementId)
    {
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
    }
}
