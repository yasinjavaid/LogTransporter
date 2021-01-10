using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InAppConsoli : MonoBehaviour
{
	public static InAppConsoli Instance;

	public Action<int> InAppFired;

	void Awake ()
	{
		Instance = this;

	}

	public void onSuccess (string prod_name, string sku, float amount)
	{
		Debug.Log ("On Success Call");

		if (sku != null) {
			Debug.Log (sku + "???????????????????????");
		}
		switch (sku) {
//		case "android.test.purchased":  //Android test inapp
//			Debug.Log ("******Removing Ads Faizan********");
//			//PlayerPrefs.SetInt (CAConstants.RemoveAdsPref, 1);
//			//ConsoliAds.Instance.hideAllAds ();
//			//ConsoliAds.Instance.HideBanner ();
////			GameObject.Find ("RemoveAds").SetActive (false);
//			//PlayerPrefs.Save ();
//			break;

		case "com.lttdg.removeads":
//		case "android.test.purchased":
			PlayerPrefs.SetInt ("RemoveAds",1);
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.hideAllAds ();
				ConsoliAds.Instance.HideBanner ();
			}
			PlayerPrefs.Save ();
			break;

		case "com.lttdg.unlocklevels":
			PlayerPrefs.SetInt ("LevelComplete", 9);
			PlayerPrefs.Save ();
			break;

		case "com.lttdg.unlocktrucks":
			PlayerPrefs.SetInt ("Truck1", 1);
			PlayerPrefs.SetInt ("Truck2", 1);
			PlayerPrefs.SetInt ("TruckPurchased", 1);
			PlayerPrefs.Save ();
			break;

		case "com.lttdg.doubletime":
			PlayerPrefs.SetInt ("DoubleTime", 1);
			PlayerPrefs.Save ();
			break;

		case "com.lttdg.unlockallgame":

			//remove ads
			PlayerPrefs.SetInt ("RemoveAds",1);
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.hideAllAds ();
				ConsoliAds.Instance.HideBanner ();
			}
			//unlock level
			PlayerPrefs.SetInt ("LevelComplete", 9);
			//unlock trucks
			PlayerPrefs.SetInt ("Truck1", 1);
			PlayerPrefs.SetInt ("Truck2", 1);
			//double time
			PlayerPrefs.SetInt ("DoubleTime", 1);

			//megabundle
			PlayerPrefs.SetInt ("MegaBundle", 1);
			PlayerPrefs.Save ();
			break;


		default:
                //
			break;

		}
	}
}
