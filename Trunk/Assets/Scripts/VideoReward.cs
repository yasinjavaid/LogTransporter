//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
////using KK.Managers;
//
//public class VideoReward : MonoBehaviour
//{
////	public string VideoId;
//	public static bool VideoAvailable = false;
//	public GameObject RevivePanel;
//    GamePlay GP;
//    //    public MainMenuManager mainMenuManager;
//
//    private void OnEnable()
//    {
////        MoPubManager.onRewardedVideoLoadedEvent += OnVideoLoaded_Event;
////        MoPubManager.onRewardedVideoFailedEvent += OnVideoFail_Event;
////        MoPubManager.onRewardedVideoReceivedRewardEvent += OnVideoComplete_Event;
//    }
//
//    private void OnDisable()
//    {
////		MoPubManager.onRewardedVideoLoadedEvent -= OnVideoLoaded_Event;
////		MoPubManager.onRewardedVideoFailedEvent -= OnVideoFail_Event;
////		MoPubManager.onRewardedVideoReceivedRewardEvent -= OnVideoComplete_Event;
//    }
//    public void ShowVideo_ButtonClick()
//	{
//		Debug.Log("**************** REWARDED VIDEO SHOW ***************");
//        PlayerPrefs.SetInt("RewardedVideo",1);
////		MoPubAds.showRewardVideo (MoPubAds._rewardedOnSkipLevel);
//	}
//
//    public void OnVideoLoaded_Event(string adUnit)
//    {
//		Debug.Log("**************** REWARDED VIDEO LOADED ***************");
//		//RevivePanel.SetActive (true);
//        VideoAvailable = true;
//	}
//
//	public void OnVideoFail_Event(string errorMsg)
//	{
//		Debug.Log("**************** REWARDED VIDEO FAILED ***************");
//        VideoAvailable = false;
//	}
//
//    public void OnVideoComplete_Event(MoPubManager.RewardedVideoData rewardData)
//	{
//        //implement logic here
//        Debug.Log("**************** REWARDED VIDEO COMPLETE ***************");
//        GP.FuelImage.fillAmount = 1;
//        GP.GameOverScreen.SetActive(false);
//		RevivePanel.SetActive(false);
//        VideoAvailable = false;
//        GP.oneTimeCheck = true;
//		GP.RCC_button.handbrakeInput = 0f;
//		
//	}
//
//	// Use this for initialization
//	void Start()
//	{
//        GP = gameObject.transform.GetComponent<GamePlay>();
//        VideoAvailable = false;
//		RevivePanel.SetActive(false);
////		MoPubAds.initializeRewardVideo (MoPubAds._rewardedOnSkipLevel);
////		MoPubAds.requestRewardVideo (MoPubAds._rewardedOnSkipLevel);
//
//	}
//
//	public void closeRevivePanel()
//	{
//		RevivePanel.SetActive (false);
//        PlayerPrefs.SetInt("RewardedVideo",1);
//		GP.oneTimeCheck = true;
////		MoPubAds.showAd(MoPubAds._interstitialOnGpEndId);
//		AndroidStoreManager.GetInstance ().ShowBanner ();
//
//		
//	}
//}
