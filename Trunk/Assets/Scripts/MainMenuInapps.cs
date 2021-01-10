using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInapps : MonoBehaviour
{
	public GameObject[] removeAdsButtons,unlockAllGame;
	public GameObject doubleTimeButton,unlockLevelBtn,unlockCharBtn;
    // Start is called before the first frame update
    void Start()
    {
		if(PlayerPrefs.GetInt ("MegaBundle")!=1){
			foreach(GameObject unlockAllGameComp in unlockAllGame){
				unlockAllGameComp.SetActive (true);
			}
		}

		if(PlayerPrefs.GetInt ("RemoveAds")!=1 && PlayerPrefs.GetInt ("LevelComplete")!=9 && PlayerPrefs.GetInt ("TruckPurchased")!=1 && PlayerPrefs.GetInt ("DoubleTime")!=1 ){

			foreach(GameObject unlockAllGameComp in unlockAllGame){
				unlockAllGameComp.SetActive (true);
			}
		}
    }

	void Update(){
		if(PlayerPrefs.GetInt ("RemoveAds")==1){
			foreach(GameObject removeAdsComp in removeAdsButtons){
				removeAdsComp.SetActive (false);
			}
		}
	


		if(PlayerPrefs.GetInt ("LevelComplete")==9){
			unlockLevelBtn.SetActive (false);
		}

		if(PlayerPrefs.GetInt ("TruckPurchased")==1){
			unlockCharBtn.SetActive (false);
		}
		if(PlayerPrefs.GetInt ("DoubleTime")==1){
			doubleTimeButton.SetActive (false);
		}

		if(PlayerPrefs.GetInt ("MegaBundle")==1){
			foreach(GameObject unlockAllGameComp in unlockAllGame){
				unlockAllGameComp.SetActive (false);
			}
		}

		if(PlayerPrefs.GetInt ("RemoveAds")==1 && PlayerPrefs.GetInt ("LevelComplete")==9 && PlayerPrefs.GetInt ("TruckPurchased")==1 && PlayerPrefs.GetInt ("DoubleTime")==1 ){
			//all remove ads buttons in mainmenu

			foreach(GameObject removeAdsComp in removeAdsButtons){
				removeAdsComp.SetActive (false);
			} 
			//levelbtn in mainmenu
			unlockLevelBtn.SetActive (false);
			//charbtn in mainmenu
			unlockCharBtn.SetActive (false);
			//doubletimebtn in mainmenu
			doubleTimeButton.SetActive (false);
			//doubletimebtn in unlockall game
			foreach(GameObject unlockAllGameComp in unlockAllGame){
				unlockAllGameComp.SetActive (false);
			}
		}



	}

	public void RemoveAds(string removeAds){
        IAPPlugin.instance.BuyProductID(removeAds);
	}

	public void Doubletime(string doubleTime){
        IAPPlugin.instance.BuyProductID(doubleTime);
	}

	public void UnlockLevels(string unlockLevel){
        IAPPlugin.instance.BuyProductID(unlockLevel);
	}

	public void UnlockChars(string unlockChars){
        IAPPlugin.instance.BuyProductID(unlockChars);
	}

	public void UnlockAllGame(string unlockAllGame){
        IAPPlugin.instance.BuyProductID(unlockAllGame);
	}



	public void RestorePurchase(){
		IAPPlugin.instance.RestorePurchases ();
	}
   
}
