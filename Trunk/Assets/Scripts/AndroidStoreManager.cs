using UnityEngine;
using System.Collections;

public class AndroidStoreManager
{

	public static AndroidStoreManager instance;
	// Use this for initialization
	public static AndroidStoreManager GetInstance()
	{
		if (instance == null)
		{
			instance = new AndroidStoreManager();
		}
		return instance;
	}

	public void LoadMainMenuAds()
	{
		if (PlayerPrefs.GetInt ("RemoveAds") != 1)
		{
			Debug.Log ("Banner init and show");
//			MoPubAds.initBanner(MoPubAds._bannerAdUnitId, MoPubAdPosition.TopLeft);
//			MoPubAds.loadAd(MoPubAds._interstitialOnStartId);
//			MoPubAds.showBanner(MoPubAds._bannerAdUnitId);
		}
	}
	public void LoadGamePlayAds()
	{
		if (PlayerPrefs.GetInt ("RemoveAds") != 1)
		{
//			MoPubAds.loadAd(MoPubAds._interstitialOnGpEndId);
//			MoPubAds.hideBanner(MoPubAds._bannerAdUnitId);
		}
	}

	public void ShowMainMenuAd()
	{
		if (PlayerPrefs.GetInt ("RemoveAds") != 1)
		{
			Debug.Log ("Selection init and show");

//			MoPubAds.showAd(MoPubAds._interstitialOnStartId);
		}
	}

	public void ShowGamePlayAd()
	{
		if (PlayerPrefs.GetInt ("RemoveAds") != 1)
		{
			Debug.Log ("GP init and show");

//			MoPubAds.showAd(MoPubAds._interstitialOnGpEndId);
		}
	}

	public void ShowBanner()
	{
		if (PlayerPrefs.GetInt ("RemoveAds") != 1)
		{
//			MoPubAds.showBanner(MoPubAds._bannerAdUnitId);
		}
	}

	public void HideBanner()
	{
		if (PlayerPrefs.GetInt ("RemoveAds") != 1)
		{
//			MoPubAds.hideBanner(MoPubAds._bannerAdUnitId);
		}
	}

	public void RewardedVideo()
	{
		//	MoPubAds.showRewardVideo(MoPubAds._rewardedOnGpEndId);

	}
	//    public void InAppPurchased()
	//    {
	//        PlayerPrefs.SetInt(GameConstants.REMOVE_AD_PREFS, 1);
	//        MoPubAds.destroyBanner();
	//    }

	//    public bool IsInAppPurchased()
	//    {
	//        if (PlayerPrefs.GetInt(GameConstants.REMOVE_AD_PREFS) == 1)
	//        {
	//            return true;
	//        }
	//        return false;
	//    }

	//    public void OpenMoreAppsLink()
	//    {
	//        Application.OpenURL(GameConstants.MORE_APPS_URL);
	//    }
	//
	//    public void OpenRateUsLink()
	//    {
	//        Application.OpenURL(GameConstants.RATE_US_LINK);
	//    }
}