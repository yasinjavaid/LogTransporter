using UnityEngine;
using System.Collections;
//using KK.Managers;

public class IAPSuccessReceiver : MonoBehaviour
{
	public GameObject removeAdsBtn;
	public void OnSuccess (string name, string id, float quantity)
	{
		Debug.Log ("IAP SUCCRESS RCVD : id >> " + id);		 
		OnPurchaseSuccess (id);
	}

    public void OnPurchaseSuccess(string id)
    {
        Debug.Log("IAP SUCCRESS RCVD : id >> " + id);
       // PlayerPrefs.SetInt(GameConstants.REMOVE_AD_PREFS, 1);
//		GameState.AdsPurchased();
		PlayerPrefs.SetInt("RemoveAds",1);
//        MoPubAds.destroyBanner();
		removeAdsBtn.SetActive (false);
       // MainMenuManager.instance.removeAdsButton.gameObject.SetActive(false);
        PlayerPrefs.Save();
    }

	void OnEnable ()
	{
//		IAPPlugin.OnPurchaseEvent += OnPurchaseSuccess;
	}

	void OnDisable ()
	{
//		IAPPlugin.OnPurchaseEvent -= OnPurchaseSuccess;
	}

}
