using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RewardedVideoManger : MonoBehaviour {

	public GamePlay gamePlay;
	public GameObject videoNotAvailable;

	void Start(){
		if(ConsoliAds.Instance){
			ConsoliAds.Instance.LoadRewarded (5);
		}
	}
	public void ShowExtraFuelRewarded(){
		if (ConsoliAds.Instance.IsRewardedVideoAvailable (5)) {
			ConsoliAds.Instance.ShowRewardedVideo (5);
			gamePlay.RefillFuelSuccess ();
		} 
		else {
			videoNotAvailable.SetActive (true);	
		}
	}

	public void ShowExtraReviveRewarded(){
		if (ConsoliAds.Instance.IsRewardedVideoAvailable (5)) {
			ConsoliAds.Instance.ShowRewardedVideo (5);
			gamePlay.Revive ();
		} 
		else {
			videoNotAvailable.SetActive (true);	
		}
	}

	public void ShowExtraSkipLevelRewarded(){
		if (ConsoliAds.Instance.IsRewardedVideoAvailable (5)) {
			ConsoliAds.Instance.ShowRewardedVideo (5);
			gamePlay.SkipLevel ();
		} 
		else {
			videoNotAvailable.SetActive (true);	
		}
	}

	public void ShowCashRewarded(){
		if (ConsoliAds.Instance.IsRewardedVideoAvailable (5)) {
			ConsoliAds.Instance.ShowRewardedVideo (5);
			gamePlay.ExtraCash ();
		} 
		else {
			videoNotAvailable.SetActive (true);	
		}
	}



}