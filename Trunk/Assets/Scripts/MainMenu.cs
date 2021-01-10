using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;
using Assets.SimpleAndroidNotifications.Enums;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour {
#if UNITY_EDITOR
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
    public GameObject QuitBox;

	public GameObject RemoveAdsButton;

	public GameObject VehicleSelection;
	public GameObject mainMenu;
//	public GameObject ModeSelection;



//	public GameObject[] Bosses;
//	public GameObject[] BossImage;
//	public GameObject[] SelectImage;
//	public Text[] Title;
//	public Text[] Description;
//	public Text[] Money;
	public GameObject JobBoard;

	public GameObject NextBossButton;
	public GameObject PrevBossButton;
	public static bool FirstTime = true;
//	public OziPlugin oziPlugin;
	public Text MainMenuCashText;
	public Text JobBoardCashText;
	public Text VehicleCashText;
	public GameObject [] Locks;
	public GameObject SellectButton;



	public int i;

	int count = 0;
	int selectcount;



	public static MainMenu _instance;
	public GameObject unlockTrucksInappBtn;
	public GameObject unlockTasksInappBtn;

	public GameObject storeBtn;
	public GameObject storePanel;
	public GameObject removeAdsStoreBtn,unlockTrucksStoreBtn,unlockTasksStoreBtn,megaBundleStoreBtn,doubleTimeStoreBtn;
	public GameObject playTruckOneTimeBtn;
	public GameObject playTaskOneTimeBtn;
	public static bool playTruckOneTimeCheck;
	public static bool playTaskOneTimeCheck;
	public GameObject playTaskOneTimePanel;
	public GameObject noAdAvailblePanel;
//	public GameObject unlockAllGamePanel,unlockAllVehiclesPanel;
	public GameObject LoginRewardPanel;
	public GameObject ExitOffer;
	void Awake()
	{

		_instance = this;

	}
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            RemoveAdsButton.SetActive(false);
            removeAdsStoreBtn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("MegaBundle") == 1)
        {
            storeBtn.SetActive(false);
            megaBundleStoreBtn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("DoubleTime") == 1)
        {
            doubleTimeStoreBtn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("LevelComplete") == 9)
        {
            unlockTasksStoreBtn.SetActive(false);
        }
        if (PlayerPrefs.GetInt("TruckPurchased") == 1)
        {
            unlockTrucksStoreBtn.SetActive(false);
        }

    }
    void Start()
	{
        //PlayerPrefs.DeleteAll();
		playTaskOneTimeCheck = false;
	
		Debug.Log (PlayerPrefs.GetInt ("LevelComplete"));
		Time.timeScale = 1;
//		AndroidStoreManager.GetInstance ().LoadMainMenuAds ();



		if (PlayerPrefs.GetInt("RemoveAds")!=1) {
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.ShowBanner(0);	
			}
		}

		if (PlayerPrefs.GetInt("LoginReward")!=1) {
			LoginRewardPanel.SetActive (true);
			NotificationManager.SendWithAppIcon (System.TimeSpan.FromDays(1),"Your Daily Reward is ready","Claim your reward",Color.green,NotificationIcon.Coin);
			PlayerPrefs.SetInt ("LoginReward",1);
		}
		if (CPPlugin.instance) {
			CPPlugin.instance.ShowAdButton();
		}

		if(ConsoliAds.Instance){
			ConsoliAds.Instance.LoadRewarded (5);
		}


	

	
//		Job1 ();
//		Analytics.LogScreen ("Main Menu Screen");
//		TopSpeed.fillAmount = 0.5f;
//		Engine.fillAmount = 0.65f;
//		Controls.fillAmount = 0.75f;
//		TopSpeedValue.text = "90";
//		EngineValue.text = "65";
//		ControlsValue.text = "75";

//		MainMenuCashText.text = PlayerPrefs.GetInt ("Cash").ToString ();
//		JobBoardCashText.text = PlayerPrefs.GetInt ("Cash").ToString ();
//		VehicleCashText.text = PlayerPrefs.GetInt ("Cash").ToString ();
//		for (int j = 0; j < Locks.Length; j++) {
//			if (j < PlayerPrefs.GetInt ("LevelComplete")) {
//				Locks [j].SetActive (false);
//			}
//		}
//		if (PlayerPrefs.GetInt ("unlocktrucks") == 1) {
//			BuyButton.SetActive (false);
//			unlockTrucksInappBtn.SetActive (false);
//		}
        

//        if (PlayerPrefs.GetInt ("megabundle") == 1) {
//			unlockTasksInappBtn.SetActive (false);
//			unlockTrucksInappBtn.SetActive (false);
//			RemoveAdsButton.SetActive (false);
//			removeAdsStoreBtn.SetActive (false);
//			unlockTasksStoreBtn.SetActive (false);
//			unlockTrucksStoreBtn.SetActive (false);
//			megaBundleStoreBtn.SetActive (false);
//			storeBtn.SetActive (false);
//
//
//
//		}
//        else
//        { unlockAllGamePanel.SetActive(true);
//         
//         }



        if (PlayerPrefs.GetInt ("LevelComplete") == 12) {

			unlockTasksInappBtn.SetActive (false);
			SellectButton.SetActive (true);
		}
			

}


	public void LoginReward(){
		PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") +1000);
		LoginRewardPanel.SetActive (false);
	}
	void Update()
	{
		if (Input.GetKeyUp ("escape")) {
			if (PlayerPrefs.GetInt("RemoveAds")!=1) {
				if(ConsoliAds.Instance){
					ConsoliAds.Instance.ShowInterstitial(0);	
				}
			}

		//	Analytics.LogScreen ("Exit Screen");
			ExitOffer.SetActive(true);
			QuitBox.SetActive (true);

//				AndroidStoreManager.GetInstance().ShowMainMenuAd();

		}
//		Analytics.LogEvent("Screen Navigation","Exit Panel Navigation ,"+" Exit Button Pressed",0);


//		if (count == 0) {
//			PrevBossButton.SetActive (false);
//
//		} else if (count > 0) {
//			PrevBossButton.SetActive (true);
//		}
//		if (count == 3) {
//			NextBossButton.SetActive (false);
//
//		} else if (count < 3) {
//			NextBossButton.SetActive (true);
//		}
//
//		if (FirstTime) {
//			FirstTime = false;
////			oziPlugin.GoogleSignIn ();
//		}

	}
	public void Play()
	{
		
//		AndroidStoreManager.GetInstance().ShowMainMenuAd();
		if (PlayerPrefs.GetInt("RemoveAds")!=1) {
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.ShowInterstitial(1);	
			}
		}


//		mainMenu.SetActive (false);
		Application.LoadLevel ("levelselection");
//		ModeSelection.SetActive (true);
	}
	public void RateUs()
	{

	}
	public void MoreApps()
	{
		Application.OpenURL ("https://play.google.com/store/apps/developer?id=Panda+Gamerz+Studios");
	}

	public void PrivacyPolicy()
	{
		Application.OpenURL ("http://www.pandagamerzstudios.com/privacy/privacypolicy.htm");
	}

	public void ExitYes()
	{
	//	Analytics.LogEvent ("Screen Navigation ", "Game Exit Navigation ,  Yes Button Pressed" , 0);
		Application.Quit ();
	}

	public void ShowOfferRewarded(){
		if(ConsoliAds.Instance.IsRewardedVideoAvailable(5)){
			ConsoliAds.Instance.ShowRewardedVideo (5);
			OfferVideoResult ();
		}
	}

	public void OfferVideoResult(){
		ExitOffer.SetActive (false);
		if (PlayerPrefs.GetInt ("LevelComplete") == 0 || GameConstantLocal.Level == (PlayerPrefs.GetInt ("LevelComplete"))) 
			PlayerPrefs.SetInt ("LevelComplete", PlayerPrefs.GetInt ("LevelComplete") + 1);
	}
	public void ExitNo()
	{
	//	Analytics.LogEvent ("Screen Navigation ", "Game Exit Navigation ,  No Button Pressed" , 0);
		QuitBox.SetActive (false);
	}
	public void removeAds()
	{

        IAPPlugin.instance.BuyProductID("com.ocpt.removeads");	
	}
	public void restore()
	{
		IAPPlugin.instance.RestorePurchases ();

	}
	public void okButton()
	{
//		NotEnoughCash.SetActive (false);
	}

//	public void ChallengeMode()
//	{
//		anim = MainCamera.transform.GetComponent<Animator> ();
//		GameConstantLocal.Mode = "Challenge";
//		anim.SetTrigger ("VehicleSelectionMode");
//		VehicleSelection.SetActive (true);
//		ModeSelection.SetActive (false);
//        AdsPlugin.Instance.showInterstitialAd(MediationSettings.interOnSelectionAdUnitId);
//    }


//    public void CompaignMode()
//	{
//		GameConstantLocal.Mode = "Compaign";
//		ModeSelection.SetActive (false);
//		JobBoard.SetActive(true);
//        AdsPlugin.Instance.showInterstitialAd(MediationSettings.interOnSelectionAdUnitId);
//    }


//	public void BackMode()
//	{
//		mainMenu.SetActive (true);
//		ModeSelection.SetActive (false);
//	}

	/// <summary>
	/// Bosses the next.
	/// </summary>
	 public void BackJob()
	{
		Debug.Log ("clicked on back job");
		JobBoard.SetActive (false);
		Debug.Log ("jobboard.setactive-false");
//		ModeSelection.SetActive (true);
		Debug.Log ("modeselection.setactive-false");
	}
	public void SelectJob()
	{
//		ConsoliAds.Instance.ShowInterstitial (5);


//		LoadingScreen.SetActive (true);
		SceneManager.LoadSceneAsync("GamePlay");
	}
//	public void BossNext()
//	{
//		Bosses [count].SetActive (false);
//		BossImage [count].SetActive (false);
//		count++;
//		Bosses [count].SetActive (true);
//		BossImage [count].SetActive (true);
//	}


//	public void BossPrev()
//	{
//		Bosses [count].SetActive (false);
//		BossImage [count].SetActive (false);
//		count--;
//		Bosses [count].SetActive (true);
//		BossImage [count].SetActive (true);
//	}

//	public void Job1()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//			
//			if (selectcount == 0) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 2;
//		SellectButton.SetActive (true);
//	}


//	public void Job2()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 1) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//
//		}
//		GameConstantLocal.Level = 3;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 1) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}


//	public void Job3()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 2) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 4;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 2) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}

//	public void Job4()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 3) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 5;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 3) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}

//	public void Job5()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 4) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 6;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 4) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}


//	public void Job6()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 5) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 7;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 5) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}
//	public void Job7()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 6) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 8;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 6) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}
//	public void Job8()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 7) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 9;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 7) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}

//	public void Job9()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 8) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 10;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 8) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}
//	public void Job10()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 9) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 11;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 9) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}public void Job11()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 10) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 12;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 10) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}public void Job12()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 11) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 13;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 11) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}public void Job13()
//	{
//		for (selectcount = 0; selectcount < SelectImage.Length; selectcount++) {
//
//			if (selectcount == 12) {
//				SelectImage [selectcount].SetActive (true);
//				Title [selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Description[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//				Money[selectcount].color = new Color (255.0f/255.0f, 247.0f/255.0f, 203.0f/255.0f);
//			} else {
//				SelectImage [selectcount].SetActive (false);
//				Title [selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Description[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//				Money[selectcount].color = new Color (83.0f/255.0f, 83.0f/255.0f, 83.0f/255.0f);
//			}
//		}
//		GameConstantLocal.Level = 14;
//		if (PlayerPrefs.GetInt ("LevelComplete") < 12) {
//			SellectButton.SetActive (false);
//			playTaskOneTimePanel.SetActive (true);
//		}else{
//			SellectButton.SetActive (true);
//		}
//	}













	public void playTruckOneTime()
	{
//		GameConstantLocal.VehicleSelected = i;
//		LoadingScreen.SetActive (true);
//		SceneManager.LoadSceneAsync ("GamePlay");

//		if (RewardedVideoManger.instance.IsLoaded()) {
//
//			RewardedVideoManger.instance.Show (playTruckOneTimeBtn);
//
//
//		} else {
//			//no video available
//
//			noAdAvailblePanel.SetActive (true);
////			NotEnoughCash.SetActive (false);
//		}



	}


	public void playTaskOneTime()
	{

////		playTaskOneTimeCheck = true;
////		SellectButton.SetActive (true);
////		playTaskOneTimePanel.SetActive (false);
////		LoadingScreen.SetActive (true);
////		SceneManager.LoadSceneAsync("GamePlay");
//		if (RewardedVideoManger.instance.IsLoaded()) {
//			RewardedVideoManger.instance.Show (playTaskOneTimeBtn);
//		} else {
//			//no video available
//			noAdAvailblePanel.SetActive(true);
//			playTaskOneTimePanel.SetActive (false);
//
//		}



	}

    


    public void showCp()
    {
        CPPlugin.instance.ShowAdButton();
        }
    public void hideCp()
    { CPPlugin.instance.HideAdButton();
     }

}
