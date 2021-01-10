using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVP;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class GamePlay : MonoBehaviour {
	//GameObjects
	public GameObject Vehicle;
	public GameObject VehicleCamera;
	public GameObject InteriorCamera;
	public Image FuelImage;
	public GameObject Fade;
	public GameObject GameOverScreen;
	public GameObject LevelCompleteScreen;
	public GameObject ChallengeGameOverScreen;
	public GameObject ChallengeLevelCompleteScreen;
	public GameObject PauseScreen;
	public GameObject[] LevelManager;
	//public GameObject MiniMap;
	public GameObject Cutscenes;
	public GameObject Slider;
	public GameObject cameraButton;
	public GameObject GameplaySound;
	public GameObject LevelFailedSound;
	public GameObject LevelCompleteSound;
	public GameObject RateUs;
    public GameObject RewardedVideo;
	public GameObject[] VehicleChallenges;
	public GameObject[] VehiclePositions;
	public GameObject ConvoUi;
	public GameObject OptionsMenu;
	public GameObject Tyres;
	public GameObject []Level11Crates;
	public GameObject []Level12Crates;
	public GameObject []ManualGear;
	public GameObject AutoGear;
	public GameObject TimeBar;
	public GameObject FuelBar;
	public GameObject []Stars;
//	public Text CashText;
	public Text JobTitle;

	//Variables
	int cameraSwitch =0;
	VehicleCameraController VC;
	public bool oneTimeCheck = true;
	bool levelFailed;
	public RCC_MobileButtons RCC_button;
	bool levelComplete;
	public bool fuel=true;
	public Toggle Auto;
	public Toggle Manual;
	public Toggle Steering;
	public Toggle Gyro;
	public Toggle Buttons;

	public GameObject [] megaBundleBtns;

	bool pauseAdCheck;
	ChallengeEconomy Economy;
	public GameObject[] logs;
	public static GamePlay _instance;
	public GameObject refillFuelPanel;
	public GameObject unlockTrucklevelCompPanel;
	bool checkRefillOnce=true;
	public Text completeCashText,failCashText;
	void Awake()
	{
		_instance = this;
	}
	// Use this for initialization
	void Start () {
		//testing levels
//		GameConstantLocal.Level=1;
		//testing levels
		pauseAdCheck = true;
	//Tutorial
		Time.timeScale =1;
        PlayerPrefs.SetInt("RewardedVideo", 0);
//		AndroidStoreManager.GetInstance ().LoadGamePlayAds ();
		RCC_button = GameObject.FindObjectOfType<RCC_MobileButtons> ();
		if (RCC_Settings.Instance.useAutomaticGear == true) {
			AutoGear.SetActive (true);
			ManualGear [0].SetActive (false);
			ManualGear [1].SetActive (false);
			ManualGear [2].SetActive (false);
		}else if(RCC_Settings.Instance.useAutomaticGear == false)
		{
			AutoGear.SetActive (false);
			ManualGear [0].SetActive (true);
			ManualGear [1].SetActive (true);
			ManualGear [2].SetActive (true);
		}

		for(int i =0 ; i < LevelManager.Length ; i++){
			if (i == GameConstantLocal.Level) {
				LevelManager [i].SetActive (true);
				Debug.Log ("Got it");
			} 
			Debug.Log ("gameConstant ki value "+GameConstantLocal.Level);
		}

		ConvoUi.SetActive (false);
		FuelBar.SetActive (true);
		TimeBar.SetActive (true);
		//logs are off in level 1 and 2 because they are not needed
		if(GameConstantLocal.Level==0||GameConstantLocal.Level==1){
			foreach(GameObject logsBundle in logs){
				logsBundle.SetActive (false);
			}
		}

		//trurning the fuel on 
		if(GameConstantLocal.Level>0)
			fuel = true;
		//commenting this shit for level selection
//		-----------------------------starting commenting from here---------------------------------
//		if (GameConstantLocal.Mode == "Compaign") {
//			GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:CampaignMode:LevelNumberStarted:"+ GameConstantLocal.Level);
//
//			Tyres.SetActive (false);
//			FuelBar.SetActive (true);
//			TimeBar.SetActive (false);
//			if (GameConstantLocal.Level == 1) {
////			fuel = false;
//
//				LevelManager.transform.GetChild (0).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (0).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (0).transform;
////			MiniMap.SetActive (true);
//			} 
		if (GameConstantLocal.Level  == 1) {
//			fuel = false;
				Slider.SetActive (true);
//				cameraButton.SetActive (true);
//				JobTitle.text = "Load Cargos";
//				CashText.text = "1000";
//				LevelManager[1].gameObject.SetActive (true);
				VehicleChallenges[0].gameObject.SetActive (false);
				VehicleChallenges[1].gameObject.SetActive (false);
				VehicleChallenges[2].gameObject.SetActive (false);
				VehicleChallenges[3].gameObject.SetActive (true);
				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = VehicleChallenges[3].transform;
//				Vehicle.transform.GetChild (1).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (1).transform;
				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 3;
				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 60;
//			MiniMap.SetActive (true);
			/// 
			}

		if (GameConstantLocal.Level == 1) {
			return;
		} else {
			EnableVehicles ();
		}
			


//		else if (GameConstantLocal.Level == 3) {
////			fuel = true;
//				JobTitle.text = "Deliver Cargos";
//				CashText.text = "1200";
//				Cutscenes.transform.GetChild (2).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (2).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (2).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (2).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 4) {
////			fuel = true;
//				JobTitle.text = "Load Heavy Cargos";
//				CashText.text = "1500";
//				Cutscenes.transform.GetChild (4).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (3).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (3).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (3).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 5) {
////			fuel = true;
//				JobTitle.text = "Back To WareHouse";
//				CashText.text = "1800";
//				Cutscenes.transform.GetChild (6).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (4).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (3).gameObject.SetActive (true);
//
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (3).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 6) {
//				//fuel = true;
//				JobTitle.text = "Deliver Fuel Barrels";
//				CashText.text = "2000";
//				Cutscenes.transform.GetChild (8).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (5).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (4).gameObject.SetActive (true);
//
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (4).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 7) {
//				//fuel = true;
//				JobTitle.text = "Pick 2 Cargos";
//				CashText.text = "2200";
//				Cutscenes.transform.GetChild (10).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (6).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (5).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (5).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 8) {
//				//fuel = true;
//				JobTitle.text = "Find Missing Cargo";
//				CashText.text = "2500";
//				Cutscenes.transform.GetChild (13).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (7).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (5).transform.GetChild (0).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (5).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (5).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 9) {
//				//	fuel = true;
//				JobTitle.text = "Deliver Missing Cargo";
//				CashText.text = "3000";
//				Cutscenes.transform.GetChild (17).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (8).gameObject.SetActive (true);
//				//LevelManager.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (5).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (5).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			} else if (GameConstantLocal.Level == 10) {
//				//	fuel = true;
//				JobTitle.text = "Pick and Drop Boss Son";
//				CashText.text = "3500";
//				Cutscenes.transform.GetChild (19).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (9).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (6).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (6).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 7;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 3;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
////			MiniMap.SetActive (true);
//			}
//			else if (GameConstantLocal.Level == 11) {
//				//	fuel = true;
//				JobTitle.text = "Pick 2 Large Cargos";
//				Slider.SetActive(true);
//				CashText.text = "3800";
//				Cutscenes.transform.GetChild (21).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (10).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (1).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (1).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 60;
//				//			MiniMap.SetActive (true);
//			}else if (GameConstantLocal.Level == 12) {
//				//	fuel = true;
//				JobTitle.text = "Deliver Cargos";
//				CashText.text = "4200";
//				Cutscenes.transform.GetChild (23).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (11).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (7).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
//				//			MiniMap.SetActive (true);
//			}else if (GameConstantLocal.Level == 13) {
//				//	fuel = true;
//				JobTitle.text = "Complete Job In Time";
//				CashText.text = "4500";
//				Cutscenes.transform.GetChild (25).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (12).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (7).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
//				//			MiniMap.SetActive (true);
//			}else if (GameConstantLocal.Level == 14) {
//				//	fuel = true;
//				JobTitle.text = "Mysterious Cargo";
//				CashText.text = "5000";
//				Cutscenes.transform.GetChild (27).gameObject.SetActive (true);
//				LevelManager.transform.GetChild (13).gameObject.SetActive (true);
//				Vehicle.transform.GetChild (7).gameObject.SetActive (true);
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//				VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//				VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
//				//			MiniMap.SetActive (true);
//			}
//		} 

//		else if (GameConstantLocal.Mode == "Challenge") {
			



//		}
//		Analytics.LogScreen ("Gameplay Level "+GameConstantLocal.Level+" Screen");







	}

	public void EnableVehicles(){
		if (GameConstantLocal.VehicleSelected == 0) {
			VehicleChallenges[0].gameObject.SetActive (true);

			VehicleChallenges[0].transform.position = VehiclePositions[GameConstantLocal.Level].transform.position;
			VehicleChallenges[0].transform.rotation = VehiclePositions[GameConstantLocal.Level].transform.rotation;

			VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = VehicleChallenges[0].transform;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 7;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 3;
			VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		} else if (GameConstantLocal.VehicleSelected == 1) {
			VehicleChallenges[1].gameObject.SetActive (true);

			VehicleChallenges[1].transform.position = VehiclePositions[GameConstantLocal.Level].transform.position;
			VehicleChallenges[1].transform.rotation = VehiclePositions[GameConstantLocal.Level].transform.rotation;

			VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = VehicleChallenges[1].transform;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
			VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		}else if (GameConstantLocal.VehicleSelected == 2) {
			VehicleChallenges[2].gameObject.SetActive (true);
			VehicleChallenges[2].transform.position = VehiclePositions[GameConstantLocal.Level].transform.position;
			VehicleChallenges[2].transform.rotation = VehiclePositions[GameConstantLocal.Level].transform.rotation;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = VehicleChallenges[2].transform;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
			VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		}

//		else if (GameConstantLocal.VehicleSelected == 3) {
//			VehicleChallenges[3].gameObject.SetActive (true);
//			VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = VehicleChallenges[3].transform;
//			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
//			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
//			VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
//		}
//	else if (GameConstantLocal.VehicleSelected == 4) {
//			VehicleChallenges[4].gameObject.SetActive (true);
//			VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = VehicleChallenges[4].transform;
//			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 7;
//			VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 3;
//			VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
//		}
	}


	// Update is called once per frame
	void Update () {
		if (fuel) {
			FuelImage.fillAmount -= 0.005f * Time.deltaTime;

			if (FuelImage.fillAmount == 0) {
//				if (oneTimeCheck) {
//                    if(VideoReward.VideoAvailable && PlayerPrefs.GetInt("RewardedVideo") == 0)
//                    {
//                        RewardedVideo.SetActive(true);
//						RCC_button.handbrakeInput = 1f;
//                    }else{
//					    GameOver ();
//
//				    }
//                    oneTimeCheck = false;
//				}
				if (oneTimeCheck) {
					GameOver ();
					oneTimeCheck = false;
					Debug.Log ("fuel is zero");
				}

			}

			if (FuelImage.fillAmount < 0.17) {
				if(checkRefillOnce){
					Time.timeScale = 0;
					refillFuelPanel.SetActive (true);
					checkRefillOnce = false;
					Debug.Log ("refill is 0.17");
				}

			}

		}

		if (PlayerPrefs.GetInt ("MegaBundle") == 1) {
			foreach(GameObject megaBundleComp in megaBundleBtns){
				megaBundleComp.SetActive (false);
			}


		}
	}

    public void OnEnable()
    {
        
    }

    public void CheckFuel()
	{
		if(GameConstantLocal.Level == 1){
			fuel = false;

		}else if(GameConstantLocal.Level == 2){
			fuel = false;

		}else if(GameConstantLocal.Level == 3){
			fuel = true;

		}else if(GameConstantLocal.Level == 4){
			fuel = true;

		}else if(GameConstantLocal.Level == 5){
			fuel = true;

		}else if(GameConstantLocal.Level == 6){
			fuel = true;

		}else if(GameConstantLocal.Level == 7){
			fuel = true;

		}else if(GameConstantLocal.Level == 8){
			fuel = true;

		}else if(GameConstantLocal.Level == 9){
			fuel = true;

		}else if(GameConstantLocal.Level == 10){
			fuel = true;
		}else if(GameConstantLocal.Level == 11){
			fuel = false;
		}else if(GameConstantLocal.Level == 12){
			fuel = true;
		}else if(GameConstantLocal.Level == 13){
			fuel = true;
		}else if(GameConstantLocal.Level == 14){
			fuel = true;
		}
		//MiniMap.SetActive (true);
	}
	public void LevelEndCutscene()
	{
		Fade.SetActive (true);
		StartCoroutine (LevelCompleteCorotineCutscene ());

	}
	public IEnumerator LevelCompleteCorotineCutscene ()
	{
		yield return new WaitForSeconds (3f);
		if(GameConstantLocal.Level == 3){
			fuel = false;
//			Cutscenes.transform.GetChild (3).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 5){
			fuel = false;
//			Cutscenes.transform.GetChild (7).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 6){
			fuel = false;
//			Cutscenes.transform.GetChild (9).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 7){
			fuel = false;
//			Cutscenes.transform.GetChild (12).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 8){
			fuel = false;
//			Cutscenes.transform.GetChild (16).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 9){
			fuel = false;
//			Cutscenes.transform.GetChild (18).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 10){
			fuel = false;
//			Cutscenes.transform.GetChild (20).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 11){
			fuel = false;
//			Cutscenes.transform.GetChild (22).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 12){
			fuel = false;
//			Cutscenes.transform.GetChild (24).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 13){
			fuel = false;
//			Cutscenes.transform.GetChild (26).gameObject.SetActive (true);
		}else if(GameConstantLocal.Level == 14){
			fuel = false;
//			Cutscenes.transform.GetChild (30).gameObject.SetActive (true);
		}
	}
	public void LevelCrateEndCutscene()
	{
		Fade.SetActive (true);
		StartCoroutine (LevelCompleteCorotineCutscene2 ());
	}
	public IEnumerator LevelCompleteCorotineCutscene2 ()
	{
		yield return new WaitForSeconds (3f);
		if(GameConstantLocal.Level == 2){
			fuel = false;
			Cutscenes.transform.GetChild (1).gameObject.SetActive (true);

		}else if(GameConstantLocal.Level == 4){
			fuel = false;
			Cutscenes.transform.GetChild (5).gameObject.SetActive (true);
		}
	}
	public void LevelComplete()
	{
//		Analytics.LogScreen ("GamePlay " + GameConstantLocal.Level + " Complete Screen" );
//		Analytics.LogEvent("Level Progression","Level " + GameConstantLocal.Level + " Successful",0);

		pauseAdCheck = true;

		if (PlayerPrefs.GetInt ("LevelComplete") == 0 || GameConstantLocal.Level == (PlayerPrefs.GetInt ("LevelComplete"))) 
			PlayerPrefs.SetInt ("LevelComplete", PlayerPrefs.GetInt ("LevelComplete") + 1);

//		if (!MainMenu.playTaskOneTimeCheck) {
//
//			if (PlayerPrefs.GetInt ("LevelComplete") == (GameConstantLocal.Level - 2)) {
//				if (PlayerPrefs.GetInt ("LevelComplete") != 12) {
//					PlayerPrefs.SetInt ("LevelComplete", PlayerPrefs.GetInt ("LevelComplete") + 1);
//					Debug.Log ("sab se andar wala check");
//				}
//				Debug.Log ("game constants wala check");
//			}
//			Debug.Log ("play one time task check");
//		}

		Fade.SetActive (true);
		StartCoroutine (LevelCompleteCorotine (3f));

//		PlayerPrefs.SetInt ("RateUsCount",PlayerPrefs.GetInt("RateUsCount")+1);
//		if (PlayerPrefs.GetInt ("RateUsDone") == 0) {
//			if (PlayerPrefs.GetInt ("RateUsCount") % 2 == 0) {
//				RateUs.SetActive (true);
//			}
//
//		}


//		ConsoliAds.Instance.ShowInterstitial (3);
		if (GameConstantLocal.Level == 0) {
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1000);
		}
		else if (GameConstantLocal.Level == 1) {
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1000);
		}
		else if (GameConstantLocal.Level == 2) {
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1000);
		}else if(GameConstantLocal.Level == 3){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1200);
		}else if(GameConstantLocal.Level == 4){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1500);
		}else if(GameConstantLocal.Level == 5){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1800);
		}else if(GameConstantLocal.Level == 6){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 2000);
		}else if(GameConstantLocal.Level == 7){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 2200);
		}else if(GameConstantLocal.Level == 8){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 2500);
		}else if(GameConstantLocal.Level == 9){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 3000);
		}else if(GameConstantLocal.Level == 10){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 3500);
		}else if(GameConstantLocal.Level == 11){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 3800);
		}else if(GameConstantLocal.Level == 12){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 4200);
		}else if(GameConstantLocal.Level == 13){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 4500);
		}else if(GameConstantLocal.Level == 14){
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 5000);
		}
	

	}
	public IEnumerator LevelCompleteCorotine (float wait)
	{
		//AndroidStoreManager.GetInstance ().ShowGamePlayAd ();
		//AndroidStoreManager.GetInstance ().ShowBanner ();
		yield return new WaitForSeconds (wait);
//		Vehicle.SetActive (false);
//		LevelManager.SetActive (false);
	//	GamePlaySound.SetActive (false);
	//	LevelCompleteSound.SetActive (true);
	//	AnimationLevel5.SetActive (false);
	//	CarControls.SetActive (false);
	//	MiniMap.SetActive (false);
		Fade.SetActive (false);
		GameplaySound.SetActive(false);
		LevelCompleteSound.SetActive (true);
		PlayerPrefs.SetInt ("RateUsCount",PlayerPrefs.GetInt("RateUsCount")+1);
		if (PlayerPrefs.GetInt ("RateUsDone") == 0) {
			if (PlayerPrefs.GetInt ("RateUsCount") % 2 == 0) {
				RateUs.SetActive (true);
			}

		}
		LevelCompleteScreen.SetActive (true);

		if(PlayerPrefs.GetInt ("Truck1")!=1&& PlayerPrefs.GetInt ("Truck2")!=1){
			unlockTrucklevelCompPanel.SetActive (true);	
		}

		completeCashText.text = "" + PlayerPrefs.GetInt ("Cash");
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:LevelComplete:PanelOpened");
		GameAnalytics.NewDesignEvent ("LevelProgression:Game_Play:"+GameConstantLocal.Level+":LevelComplete");


//		if (GameConstantLocal.Mode == "Challenge") {
//			ChallengeLevelCompleteScreen.SetActive (true);
//			GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:ChallengeMode:LevelComplete:PanelOpened");
//
//		}
//		if (GameConstantLocal.Mode == "Compaign") {
//			LevelCompleteScreen.SetActive (true);
//			GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:CampaignMode:LevelComplete:PanelOpened:LevelNumber:"+ GameConstantLocal.Level);
//
//		}
//		GameConstantLocal.level7 = 0;
//		GameConstantLocal.level10 = 0;
//		VehicleCamera.SetActive (true);

		yield return new WaitForSeconds (1f);

		if (PlayerPrefs.GetInt("RemoveAds")!=1) {
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.ShowInterstitial(3);	
			}
		}

		Time.timeScale=0;
//		AdsPlugin.Instance.showRectangleAd ();
//		AndroidStoreManager.GetInstance ().ShowGamePlayAd ();
//		AndroidStoreManager.GetInstance ().ShowBanner ();
	}
	public void GameOver()
	{
//		Analytics.LogScreen ("GamePlay " + GameConstantLocal.Level + " Failed Screen" );
//		Analytics.LogEvent("Level Progression","Level " + GameConstantLocal.Level + " Failed",0);
		Fade.SetActive (true);
		levelFailed = true;

//		if(GameConstantLocal.Mode == "Challenge"){
//			Economy = VehicleChallenges.transform.GetChild (GameConstantLocal.VehicleSelected).transform.GetComponent<ChallengeEconomy> ();
//			Economy.TotalStats ();
//		}
	//	CarControls.SetActive (false);
	//	MiniMap.SetActive (false);
//		ConsoliAds.Instance.ShowInterstitial (4);
		StartCoroutine (GameOverCorotine ());
	}
	IEnumerator GameOverCorotine()
	{
		yield return new WaitForSeconds (3f);
	//	AndroidStoreManager.GetInstance ().ShowGamePlayAd ();
	//	AndroidStoreManager.GetInstance ().ShowBanner ();
//		Vehicle.SetActive (false);

//		if (GameConstantLocal.Mode == "Challenge") {
//
//			Debug.Log ("challane game over");
//			ChallengeGameOverScreen.SetActive (true);
//			GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:CampaignMode:LevelFail:PanelOpened");
//
//		}
//		if (GameConstantLocal.Mode == "Compaign") {
//			Debug.Log ("Compaign game over");
//			GameOverScreen.SetActive (true);


		GameAnalytics.NewDesignEvent ("LevelProgression:Game_Play:"+GameConstantLocal.Level+":LevelFail");

//		}
		Fade.SetActive (false);
		GameplaySound.SetActive(false);
		GameOverScreen.SetActive (true);
		failCashText.text = "" + PlayerPrefs.GetInt ("Cash");

		LevelFailedSound.SetActive (true);
		Debug.Log ("now hereeeeeeeeeeeeeeeeeeee");

		yield return new WaitForSeconds (1f);
		if (PlayerPrefs.GetInt("RemoveAds")!=1) {
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.ShowInterstitial(4);	
			}
		}

//		AdsPlugin.Instance.showRectangleAd ();

		yield return new WaitForSeconds (2f);
//	//	GamePlaySound.SetActive (false);
//	//	LevelFailedSound.SetActive (true);
		Time.timeScale = 0;

	
//		AndroidStoreManager.GetInstance ().ShowGamePlayAd ();
//		AndroidStoreManager.GetInstance ().ShowBanner ();
	}
	public IEnumerator Level4Corotine ()
	{
		yield return new WaitForSeconds (3f);
		Debug.Log ("Corotine Started");
		fuel = false;
		FuelImage.fillAmount = 1;
		Slider.SetActive (true);
		//MiniMap.SetActive (false);
//		LevelManager.transform.GetChild (3).transform.GetChild (0).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (1).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (3).gameObject.SetActive (false);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (1).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 3;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 60;
		//MiniMap.SetActive (true);
	}
	public IEnumerator Level7CorotinePart2 ()
	{
		yield return new WaitForSeconds (3f);
		Debug.Log ("Corotine Started");
		fuel = false;
		Slider.SetActive (true);
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (6).transform.GetChild (1).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (1).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (5).gameObject.SetActive (false);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (1).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 3;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 60;
		//MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (false);
	}
	public IEnumerator Level7CorotinePart3 ()
	{
		yield return new WaitForSeconds (3f);
		Debug.Log ("Corotine Started");
		fuel = true;
		Cutscenes.transform.GetChild (11).gameObject.SetActive (true);
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (6).transform.GetChild (2).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (5).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (1).gameObject.SetActive (false);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (5).transform;
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (false);
//		LevelManager.transform.GetChild (6).transform.GetChild (1).gameObject.SetActive (false);
	}
	public IEnumerator Level8CorotinePart1 ()
	{
		yield return new WaitForSeconds (3f);
		Debug.Log ("Corotine Started");
		fuel = true;
		Cutscenes.transform.GetChild (14).gameObject.SetActive (true);
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (7).transform.GetChild (1).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (5).gameObject.SetActive (true);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (5).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
	//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (7).transform.GetChild (0).gameObject.SetActive (false);

	}
	public IEnumerator Level8CorotinePart2 ()
	{
		yield return new WaitForSeconds (3f);
		Debug.Log ("Corotine Started");
		fuel = true;
		Cutscenes.transform.GetChild (15).gameObject.SetActive (true);
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (7).transform.GetChild (2).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (5).gameObject.SetActive (true);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (5).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
	//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (7).transform.GetChild (0).gameObject.SetActive (false);
//		LevelManager.transform.GetChild (7).transform.GetChild (1).gameObject.SetActive (false);
	}
	public IEnumerator Level10Corotine ()
	{
		yield return new WaitForSeconds (3f);
		Debug.Log ("Corotine Started");
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (9).transform.GetChild (1).gameObject.SetActive (true);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (6).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
	//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (9).transform.GetChild (0).gameObject.SetActive (false);

	}
	public IEnumerator Level11CorotinePart1 ()
	{
		RCC_button.handbrakeInput = 1f;
		yield return new WaitForSeconds (3f);
//		LevelManager.transform.GetChild (10).transform.GetChild (0).gameObject.SetActive (false);
		fuel = true;
		RCC_button.handbrakeInput = 0f;
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (10).transform.GetChild (1).gameObject.SetActive (true);
//		Vehicle.transform.GetChild (1).gameObject.SetActive(false);
//		Vehicle.transform.GetChild (7).gameObject.SetActive(true);
		Level11Crates [0].SetActive (true);
		Level11Crates [1].SetActive (true);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//	MiniMap.SetActive (true);

	}
	public IEnumerator Level11CorotinePart2 ()
	{
		RCC_button.handbrakeInput = 1f;
		yield return new WaitForSeconds (3f);
		fuel = true;
		RCC_button.handbrakeInput = 0f;
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (10).transform.GetChild (2).gameObject.SetActive (true);
		Level11Crates [0].SetActive (false);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (10).transform.GetChild (1).gameObject.SetActive (false);
	}public IEnumerator Level12CorotinePart1 ()
	{
		RCC_button.handbrakeInput = 1f;
		yield return new WaitForSeconds (3f);
		fuel = true;
		RCC_button.handbrakeInput = 0f;
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (11).transform.GetChild (1).gameObject.SetActive (true);
		Level12Crates[5].SetActive(false);
		Level12Crates[4].SetActive(false);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (11).transform.GetChild (0).gameObject.SetActive (false);
	}
	public IEnumerator Level12CorotinePart2 ()
	{
		RCC_button.handbrakeInput = 1f;
		yield return new WaitForSeconds (3f);
		fuel = true;
		RCC_button.handbrakeInput = 0f;
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (11).transform.GetChild (2).gameObject.SetActive (true);
		Level12Crates[3].SetActive(false);
		Level12Crates[2].SetActive(false);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (11).transform.GetChild (1).gameObject.SetActive (false);
	}
	public IEnumerator Level14CorotinePart1 ()
	{
		RCC_button.handbrakeInput = 1f;
		yield return new WaitForSeconds (3f);
		fuel = false;
		RCC_button.handbrakeInput = 0f;
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (13).transform.GetChild (1).gameObject.SetActive (true);
		Cutscenes.transform.GetChild (28).gameObject.SetActive (true);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (13).transform.GetChild (0).gameObject.SetActive (false);
	}
	public IEnumerator Level14CorotinePart2 ()
	{
		RCC_button.handbrakeInput = 1f;
		yield return new WaitForSeconds (3f);
		fuel = false;
		RCC_button.handbrakeInput = 0f;
		FuelImage.fillAmount = 1;
//		LevelManager.transform.GetChild (13).transform.GetChild (2).gameObject.SetActive (true);
		Cutscenes.transform.GetChild (29).gameObject.SetActive (true);
//		VehicleCamera.transform.GetComponent<VehicleCameraController> ().target = Vehicle.transform.GetChild (7).transform;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.distance = 10;
		VehicleCamera.transform.GetComponent<VehicleCameraController> ().smoothFollowSettings.height = 5;
		VehicleCamera.transform.GetComponent<Camera> ().fieldOfView = 93;
		//	MiniMap.SetActive (true);
//		LevelManager.transform.GetChild (13).transform.GetChild (1).gameObject.SetActive (false);
	}
	public void CameraSwitch()
	{
		VC = VehicleCamera.GetComponent<VehicleCameraController>();	
		if (cameraSwitch == 0) {
			VehicleCamera.SetActive (true);
			InteriorCamera = GameObject.FindGameObjectWithTag("Player");
			InteriorCamera.transform.GetChild (0).gameObject.SetActive (false);
			//VC.mode++;
			VehicleCamera.GetComponent<VehicleCameraController>().enabled = false;
			VehicleCamera.GetComponent<ThirdPersonOrbitCam> ().enabled = true;
			cameraSwitch = 1;
		} else if (cameraSwitch == 1) {
			VehicleCamera.SetActive (false);
//			InteriorCamera.SetActive (true);

			InteriorCamera = GameObject.FindGameObjectWithTag("Player");
			InteriorCamera.transform.GetChild (0).gameObject.SetActive (true);
			cameraSwitch = 2;
		} else if (cameraSwitch == 2) {
			VehicleCamera.SetActive (true);
			InteriorCamera = GameObject.FindGameObjectWithTag("Player");
			InteriorCamera.transform.GetChild (0).gameObject.SetActive (false);
			VehicleCamera.GetComponent<VehicleCameraController>().enabled = true;
			VehicleCamera.GetComponent<ThirdPersonOrbitCam> ().enabled = false;
			//VC.mode--;
			cameraSwitch = 0;
		}
	}
	public void FuelTrue()
	{
		fuel = true;
	}
	// UI Buttons

	public void Pause()
	{
        		if (pauseAdCheck) {
			if (PlayerPrefs.GetInt("RemoveAds")!=1) {
				if(ConsoliAds.Instance){
					ConsoliAds.Instance.ShowInterstitial(4);	
				}
			}
        	pauseAdCheck = false;
        }
        

		Time.timeScale = 0;
		PauseScreen.SetActive (true);
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:PausePanelOpened");

//		Analytics.LogEvent ("Screen Navigation","Pause Panel Navigation "+" Pause Button Pressed",0);
	}
	public void Restart()
	{
        


        CPPlugin.instance.HideAdButton();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:RestartBtnClicked");
//		Analytics.LogEvent ("GameOver Screen","Level "+GameConstantLocal.Level+" GameOver Navigation "+"Level "+GameConstantLocal.Level+" Restarted",0);
	}
	public void PauseRestart()
	{
        


        CPPlugin.instance.HideAdButton();
        //		AndroidStoreManager.GetInstance ().ShowGamePlayAd();
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:PausePanelOpened:RestartBtnClicked");
//		Analytics.LogEvent("Level Progression","Level "+GameConstantLocal.Level+" Pause Menu" +"Level "+GameConstantLocal.Level+" Restart",0);
	}
	public void Mainmenu()
	{
       
		SceneManager.LoadScene ("MainMenu");
        CPPlugin.instance.HideAdButton();
        GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:MainmenuBtnClicked");
//		Analytics.LogEvent ("GameOver Screen","Level "+GameConstantLocal.Level+" GameOver Navigation "+"Level "+GameConstantLocal.Level+" Quit",0);
	}
	public void PauseMainMenu()
	{
       
//		AndroidStoreManager.GetInstance ().ShowGamePlayAd();
		SceneManager.LoadScene ("MainMenu");
        CPPlugin.instance.HideAdButton();
        GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:PausePanelOpened:MainmenuBtnClicked");
//		Analytics.LogEvent("Level Progression","Level "+GameConstantLocal.Level+" Pause Menu" +"Level "+GameConstantLocal.Level+" Quit",0);
	}
	public void NextLevel()
	{
      
//		GameConstantLocal.Level++;
//		GameTimer.instance.timeCheckOnce = true;
		if (PlayerPrefs.GetInt ("LevelComplete") == 0 || GameConstantLocal.Level == (PlayerPrefs.GetInt ("LevelComplete"))) 
			PlayerPrefs.SetInt ("LevelComplete", PlayerPrefs.GetInt ("LevelComplete") + 1);
        CPPlugin.instance.HideAdButton();

        if (GameConstantLocal.Level == 9) {
			SceneManager.LoadScene ("MainMenu");
		} else {
			SceneManager.LoadScene ("levelselection");
		}
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:CampaignMode:LevelComplete:PanelOpened:NextBtnClicked:LevelNumber:"+ GameConstantLocal.Level);

//		Analytics.LogEvent ("GameOver Screen","Level "+GameConstantLocal.Level+" Complete Navigation "+" Next Button Pressed",0);
	
	}
	public void Resume()
	{
		
		Time.timeScale = 1;
		PauseScreen.SetActive (false);
        CPPlugin.instance.HideAdButton();
        GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:ResumeBtnClicked");
//		Analytics.LogEvent ("Screen Navigation","Pause Menu Buttons" +" Resume Button Pressed",0);

	}
	public void NoThanks()
	{
		RateUs.SetActive (false);
	}
	public void RateUsButton()
	{
		PlayerPrefs.SetInt ("RateUsDone", 1);
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.pgz.logtransport.trailer.truck.driver.games");
		RateUs.SetActive (false);
	}
	public void OptionsButton()
	{
		OptionsMenu.SetActive (true);
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:OptionsBtnClicked");
	}
	//Options Menu
	public void DoneControl()
	{
		if (Auto.isOn) {
			RCC_Settings.Instance.useAutomaticGear = true;
			AutoGear.SetActive (true);
			ManualGear[0].SetActive(false);
			ManualGear[1].SetActive(false);
			ManualGear[2].SetActive(false);
		} else if (Manual.isOn) {
			RCC_Settings.Instance.useAutomaticGear = false;
			ManualGear[0].SetActive(true);
			ManualGear[1].SetActive(true);
			ManualGear[2].SetActive(true);
			AutoGear.SetActive (false);
		}

		if (Steering.isOn) {
			RCC_Settings.Instance.useAccelerometerForSteering = false;
			RCC_Settings.Instance.useSteeringWheelForSteering = true;

		} else if (Gyro.isOn) {
			RCC_Settings.Instance.useSteeringWheelForSteering = false;
			RCC_Settings.Instance.useAccelerometerForSteering = true;

		} else if (Buttons.isOn) {
			RCC_Settings.Instance.useSteeringWheelForSteering = false;
			RCC_Settings.Instance.useAccelerometerForSteering = false;

		}
		OptionsMenu.SetActive (false);
	}


	public void megaBundleInapp(string unlockAllGame)
	{
        IAPPlugin.instance.BuyProductID(unlockAllGame);
		GameAnalytics.NewDesignEvent ("UI_Navigation:Game_Play:MegaBundleBtnClicked");
		//12-28 16:56:50.673: I/Ads(23830): Use AdRequest.Builder.addTestDevice("00327478F723E0198121C1988E9B5018") to get test ads on this device.

	}
    public void hideCp()
    { CPPlugin.instance.HideAdButton(); }
    public void showCp()
    { CPPlugin.instance.ShowAdButton(); }


	public void RefillFuelSuccess(){
		Time.timeScale = 1;
		FuelImage.fillAmount = 1;
		refillFuelPanel.SetActive (false);
		checkRefillOnce = true;
		Debug.Log ("Refill fuel");
	}

	public void SkipRefillVideo(){
		Time.timeScale = 1;
		refillFuelPanel.SetActive (false);
		Debug.Log ("Skip fuel");
	}

	public void Revive(){
		Time.timeScale = 1;
		FuelImage.fillAmount = 1;
		if (PlayerPrefs.GetInt ("DoubleTime", 0) == 0) {
			GameTimer.instance.totalTime = 150.0f;
		} 
		else {
			GameTimer.instance.totalTime = 300.0f;

		}

		GameOverScreen.SetActive (false);
		GameplaySound.SetActive(true);
		LevelFailedSound.SetActive (false);
		GameTimer.instance.timeCheckOnce = true;
		oneTimeCheck = true;
		checkRefillOnce = true;
		Debug.Log ("revive");
	}

	public void SkipLevel(){
		if (PlayerPrefs.GetInt ("LevelComplete") == 0 || GameConstantLocal.Level == (PlayerPrefs.GetInt ("LevelComplete"))) 
			PlayerPrefs.SetInt ("LevelComplete", PlayerPrefs.GetInt ("LevelComplete") + 1);

		SceneManager.LoadScene ("levelselection");

		CPPlugin.instance.HideAdButton();
	}

	public void ExtraCash(){
		PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1000);
	}

	public void UnlockTruckSceneLoad(){
		SceneManager.LoadScene ("charactereselection");
	}

}
