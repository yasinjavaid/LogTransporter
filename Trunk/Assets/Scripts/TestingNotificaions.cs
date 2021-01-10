using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleAndroidNotifications;
using Assets.SimpleAndroidNotifications.Enums;
public class TestingNotificaions : MonoBehaviour
{
	public void testing(){
		NotificationManager.SendWithAppIcon (System.TimeSpan.FromDays(1),"Your Daily Reward is ready","Claim your reward",Color.green,NotificationIcon.Coin);
		NotificationManager.SendWithAppIcon (System.TimeSpan.FromMinutes(1),"Your Daily Reward is ready","Claim your reward",Color.green,NotificationIcon.Coin);

	}
}
