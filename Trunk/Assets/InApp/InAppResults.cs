using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Purchasing;
//using GoogleMobileAds.Api;


public class InAppResults : MonoBehaviour
{
	public static InAppResults Instance;

	public Action<int> InAppFired;

	void Awake ()
	{
		Instance = this;
	}

	public void onSuccess (PurchaseEventArgs args)
	{
		Debug.Log ("On Success Call");

        if (args.purchasedProduct.definition.id != null) {
			Debug.Log (args.purchasedProduct.definition.id + "???????????????????????");
		}
		switch (args.purchasedProduct.definition.id) {
		case "com.lttdg.removeads": //        case "android.test.purchased":          PlayerPrefs.SetInt ("RemoveAds",1);             if(ConsoliAds.Instance){                ConsoliAds.Instance.hideAllAds ();              ConsoliAds.Instance.HideBanner ();          }
                GameObject.Find("removeads").SetActive(false);
                MainMenu._instance.removeAdsStoreBtn.SetActive(false);
                if (Application.loadedLevel == 1)
                {
                    if ((PlayerPrefs.GetInt("RemoveAds") == 1) && (PlayerPrefs.GetInt("LevelComplete") == 9) && (PlayerPrefs.GetInt("TruckPurchased") == 1) && (PlayerPrefs.GetInt("DoubleTime") == 1))
                    {
                        MainMenu._instance.megaBundleStoreBtn.SetActive(false);
                        MainMenu._instance.storeBtn.SetActive(false);
                        PlayerPrefs.SetInt("MegaBundle", 1);
                    }
                }
                PlayerPrefs.Save ();

                    break;          case "com.lttdg.unlocklevels":          PlayerPrefs.SetInt ("LevelComplete", 9);            PlayerPrefs.Save ();
                if (Application.loadedLevel == 2)
                {
                    Levelselection._instance.unlockLevel = PlayerPrefs.GetInt("LevelComplete");
                    for (int i = 0; i <= Levelselection._instance.unlockLevel; i++)
                        Levelselection._instance.levelLocks[i].SetActive(false);
                }
                else
                {
                    MainMenu._instance.unlockTasksStoreBtn.SetActive(false);
                }
                if (Application.loadedLevel == 1)
                {
                    if ((PlayerPrefs.GetInt("RemoveAds") == 1) && (PlayerPrefs.GetInt("LevelComplete") == 9) && (PlayerPrefs.GetInt("TruckPurchased") == 1) && (PlayerPrefs.GetInt("DoubleTime") == 1))
                    {
                        MainMenu._instance.megaBundleStoreBtn.SetActive(false);
                        MainMenu._instance.storeBtn.SetActive(false);
                        PlayerPrefs.SetInt("MegaBundle", 1);
                    }
                }
                break;          case "com.lttdg.unlocktrucks":          PlayerPrefs.SetInt ("Truck1", 1);           PlayerPrefs.SetInt ("Truck2", 1);           PlayerPrefs.SetInt ("TruckPurchased", 1);
                if (Application.loadedLevel == 3)
                {
                    CharacterSelection._instance.lockImage.SetActive(false);
                }
                else
                {
                    MainMenu._instance.unlockTrucksStoreBtn.SetActive(false);
                }
                if (Application.loadedLevel == 1)
                {
                    if ((PlayerPrefs.GetInt("RemoveAds") == 1) && (PlayerPrefs.GetInt("LevelComplete") == 9) && (PlayerPrefs.GetInt("TruckPurchased") == 1) && (PlayerPrefs.GetInt("DoubleTime") == 1))
                    {
                        MainMenu._instance.megaBundleStoreBtn.SetActive(false);
                        MainMenu._instance.storeBtn.SetActive(false);
                        PlayerPrefs.SetInt("MegaBundle", 1);
                    }
                }
                PlayerPrefs.Save ();            break;          case "com.lttdg.doubletime":            PlayerPrefs.SetInt ("DoubleTime", 1);           PlayerPrefs.Save ();
                if (Application.loadedLevel == 1)
                {
                    MainMenu._instance.doubleTimeStoreBtn.SetActive(false);
                    if ((PlayerPrefs.GetInt("RemoveAds") == 1) && (PlayerPrefs.GetInt("LevelComplete") == 9) && (PlayerPrefs.GetInt("TruckPurchased") == 1) && (PlayerPrefs.GetInt("DoubleTime") == 1))
                    {
                        MainMenu._instance.megaBundleStoreBtn.SetActive(false);
                        MainMenu._instance.storeBtn.SetActive(false);
                        PlayerPrefs.SetInt("MegaBundle", 1);
                    }
                }

                break;          case "com.lttdg.unlockallgame":             //remove ads            PlayerPrefs.SetInt ("RemoveAds",1);             if(ConsoliAds.Instance){                ConsoliAds.Instance.hideAllAds ();              ConsoliAds.Instance.HideBanner ();          }           //unlock level          PlayerPrefs.SetInt ("LevelComplete", 9);            //unlock trucks             PlayerPrefs.SetInt ("Truck1", 1);           PlayerPrefs.SetInt ("Truck2", 1);
                PlayerPrefs.SetInt("TruckPurchased", 1);

                //double time
                PlayerPrefs.SetInt ("DoubleTime", 1);           //megabundle            PlayerPrefs.SetInt ("MegaBundle", 1);           PlayerPrefs.Save ();



                if (Application.loadedLevel == 1)
                {
                    GameObject.Find("removeads").SetActive(false);
                    MainMenu._instance.storeBtn.SetActive(false);

                    MainMenu._instance.removeAdsStoreBtn.SetActive(false);
                    MainMenu._instance.unlockTasksStoreBtn.SetActive(false);
                    MainMenu._instance.unlockTrucksStoreBtn.SetActive(false);
                    MainMenu._instance.doubleTimeStoreBtn.SetActive(false);
                    MainMenu._instance.megaBundleStoreBtn.SetActive(false);

                   

                    
                }

                    break; 



        default:
                //
			break;

		}
	}
}
