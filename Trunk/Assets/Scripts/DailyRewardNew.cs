using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleAndroidNotifications;
using Assets.SimpleAndroidNotifications.Enums;

public class DailyRewardNew : MonoBehaviour
{
	DateTime DateTimeLast, DateTimeNow;
	public const string LastDateTimeStr = "LastDateTime";
	public GameObject dailyRewardPanel;
//	public const string RewardedCarIndex = "RewardedCarIndex";

	void Start ()
	{
		DateTimeNow = DateTime.Now;
		//DateTimeNow.AddDays (1f);
		if (PlayerPrefs.HasKey (LastDateTimeStr)) {
			DateTimeLast = DateTime.Parse (PlayerPrefs.GetString (LastDateTimeStr));
//			vehicleSelection.instance.loadVehicles ();
			if (DateTimeNow.Day > DateTimeLast.Day) {
				//Give Daily Reward

				Debug.Log ("************************** Daily Reward Given");

				DailyReward();
//				NotificationManager.SendWithAppIcon (System.TimeSpan.FromDays(1),"Your Daily Reward is ready","Claim your reward",Color.green,NotificationIcon.Coin);
				PlayerPrefs.SetString (LastDateTimeStr, DateTime.Now.ToString ()); // add it on when give claim
				Debug.Log ("<color=green>GiveReward</color>");
			}
		} else {
			PlayerPrefs.SetString (LastDateTimeStr, DateTime.Now.ToString ());
		}
	}



	public void DailyReward(){
		dailyRewardPanel.SetActive (true);
		PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") +100);
	}

	public void OkBtn(){
		dailyRewardPanel.SetActive (false);
		NotificationManager.SendWithAppIcon (System.TimeSpan.FromDays(1),"Your Daily Reward is ready","Claim your reward",Color.green,NotificationIcon.Coin);
	}



}