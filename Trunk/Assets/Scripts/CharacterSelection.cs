using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;


public class CharacterSelection : MonoBehaviour
{
	public GameObject MainCamera; 
	public GameObject [] Vehicles,unlockCharBtn;
	public Animator anim;
	public GameObject NextButton;
	public GameObject PrevButton;
	public int i;
	int Truck1 = 4400;
	int Truck2 = 6600;
	int Truck3 = 9100;
	int Jeep = 12700;
	public GameObject BuyButton,lockImage;
	public GameObject NotEnoughCash;
	bool nextMethod = true;
	bool prevMethod = true;
	public Image TopSpeed;
	public Text TopSpeedValue;
	public Text EngineValue;
	public Text ControlsValue;
	public GameObject LoadingScreen;
	public GameObject specailGift;
	public GameObject cashPopUp;
	public Image Engine;
	public Image Controls;
	public Image suspension;
	public Text BuyText;
	public Text CashText;
	public GameObject [] vehiclesImage,levelImage;
    public static CharacterSelection _instance;


    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1;
		if(PlayerPrefs.GetInt ("TruckPurchased")!=1 ||PlayerPrefs.GetInt ("Truck1")!=1&&PlayerPrefs.GetInt ("Truck2")!=1){
			foreach(GameObject unlockcharacterComp in unlockCharBtn){
				unlockcharacterComp.SetActive (true);
			}
		}

		if(PlayerPrefs.GetInt ("SpecialGift")!=1){
			specailGift.SetActive (true);
		}
		UpdateCash ();
    }

	void UpdateCash(){
		CashText.text = "" + PlayerPrefs.GetInt ("Cash");
	}

	public void SpecialGiftOff(){
		specailGift.SetActive (false);
		PlayerPrefs.SetInt ("SpecialGift", 1);

	}

	void Update(){
		
		if (i == 2) {
			NextButton.SetActive (false);
		} else if (i < 2) {
			NextButton.SetActive (true);
		}
		if (i == 0) {
			PrevButton.SetActive (false);

		}else if(i > 0)
		{
			PrevButton.SetActive (true);
		}

		if(PlayerPrefs.GetInt ("TruckPurchased")==1||PlayerPrefs.GetInt ("Truck1")==1&&PlayerPrefs.GetInt ("Truck2")==1){
			foreach(GameObject unlockcharacterComp in unlockCharBtn){
				unlockcharacterComp.SetActive (false);
			}
		}
	}
	public void Buy()
	{
		if (i == 1) {
			if (PlayerPrefs.GetInt ("Cash") >= Truck1) {
				PlayerPrefs.SetInt ("Truck1", 1);
				PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - Truck1);
				UpdateCash ();
				BuyButton.SetActive (false);
				lockImage.SetActive (false);
			} else {
				NotEnoughCash.SetActive (true);
			}
		}
		else if (i == 2) {
			if (PlayerPrefs.GetInt ("Cash") >= Truck2) {
				PlayerPrefs.SetInt ("Truck2", 1);
				PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - Truck2);
				UpdateCash ();
				BuyButton.SetActive (false);
				lockImage.SetActive (false);
			}
			else {
				NotEnoughCash.SetActive (true);
			}
		}

		//commented for extra 2
		//		else if (i == 3) {
		//			if (PlayerPrefs.GetInt ("Cash") >= Truck3) {
		//				PlayerPrefs.SetInt ("Truck3", 1);
		//				PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - Truck3);
		//				BuyButton.SetActive (true);
		//			}
		//			else {
		//				NotEnoughCash.SetActive (true);
		//			}
		//		}
		//		else if (i == 4) {
		//			if (PlayerPrefs.GetInt ("Cash") >= Jeep) {
		//				PlayerPrefs.SetInt ("Jeep", 1);
		//				PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - Jeep);
		//				BuyButton.SetActive (true);
		//			}
		//			else {
		//				NotEnoughCash.SetActive (true);
		//			}
		//		}

		//commented for extra 2
	}
	public void Next()
	{
		if (nextMethod) {
//			anim = Vehicles [i].transform.GetComponent<Animator> ();
			anim.SetTrigger ("Next");
			if (i < 2) {
				i++;
			}
			Vehicles [i].SetActive (true);
			Debug.Log ("the value of i is "+ i);
			nextMethod = false;
			prevMethod = false;
			StartCoroutine (NextCorotine ());
			if (i == 0) {
				TopSpeed.fillAmount = 0.5f;
				Engine.fillAmount = 0.65f;
				Controls.fillAmount = 0.75f;
				suspension.fillAmount = 0.65f;
				TopSpeedValue.text = "90";
				EngineValue.text = "65";
				ControlsValue.text = "75";


			}else if (i == 1) {
				TopSpeed.fillAmount = 0.6f;
				Engine.fillAmount = 0.75f;
				Controls.fillAmount = 0.8f;
				suspension.fillAmount = 0.95f;
				TopSpeedValue.text = "100";
				EngineValue.text = "80";
				ControlsValue.text = "80";
				BuyText.text = Truck1.ToString ();
				if (PlayerPrefs.GetInt ("Truck1") == 0) {
					BuyButton.SetActive (true);
					lockImage.SetActive (true);
				}
				if (PlayerPrefs.GetInt ("Cash") >= Truck1 &&PlayerPrefs.GetInt ("Truck1") == 0 ) {
					if (PlayerPrefs.GetInt ("Truck1PopOnce")!=1) {
						cashPopUp.SetActive (true);
						PlayerPrefs.SetInt ("Truck1PopOnce",1);
					}
				}
			}
			else if (i == 2) {
				TopSpeed.fillAmount = 0.7f;
				Engine.fillAmount = 0.85f;
				Controls.fillAmount = 0.9f;
				suspension.fillAmount = 0.5f;
				TopSpeedValue.text = "110";
				EngineValue.text = "85";
				ControlsValue.text = "90";
				BuyText.text = Truck2.ToString ();
				if (PlayerPrefs.GetInt ("Truck2") == 0) {
					BuyButton.SetActive (true);
					lockImage.SetActive (true);
				}
				if (PlayerPrefs.GetInt ("Cash") >= Truck2 &&PlayerPrefs.GetInt ("Truck2") == 0) {
					if (PlayerPrefs.GetInt ("Truck2PopOnce")!=1) {
						cashPopUp.SetActive (true);
						PlayerPrefs.SetInt ("Truck2PopOnce",1);
					}
				}

			}
			//commented for extra 2
			//			else if (i == 3) {
			//				TopSpeed.fillAmount = 0.8f;
			//				Engine.fillAmount = 0.9f;
			//				Controls.fillAmount = 0.8f;
			//				TopSpeedValue.text = "120";
			//				EngineValue.text = "90";
			//				ControlsValue.text = "95";
			//				BuyText.text = Truck3.ToString ();
			//				if (PlayerPrefs.GetInt ("Truck3") == 0) {
			//					BuyButton.SetActive (true);
			//				}
			//			}

			//			else if (i == 4) {
			//				TopSpeed.fillAmount = 1.0f;
			//				Engine.fillAmount = 1f;
			//				Controls.fillAmount = 0.7f;
			//				TopSpeedValue.text = "140";
			//				EngineValue.text = "95";
			//				ControlsValue.text = "70";
			//				BuyText.text = Jeep.ToString ();
			//				if (PlayerPrefs.GetInt ("Jeep") == 0) {
			//					BuyButton.SetActive (true);
			//				}
			//			}
			//commented for extra 2
		}
	}

	public IEnumerator NextCorotine()
	{
		//if (GameConstantLocal.Mode == "Challenege") {
		yield return new WaitForSeconds (0f);
		nextMethod = true;
		prevMethod = true;
		Vehicles [i - 1].SetActive (false);
	}
	public void Previous()
	{
		if (prevMethod) {
//			anim = Vehicles [i].transform.GetComponent<Animator> ();
			anim.SetTrigger ("Next");
			if (i > 0) {
				i--;
			}
			Vehicles [i].SetActive (true);
			prevMethod = false;
			nextMethod = false;
			StartCoroutine (prevCorotine ());
			if (i == 0) {
				TopSpeed.fillAmount = 0.5f;
				Engine.fillAmount = 0.65f;
				Controls.fillAmount = 0.75f;
				suspension.fillAmount = 0.65f;
				TopSpeedValue.text = "90";
				EngineValue.text = "65";
				ControlsValue.text = "75";
				BuyButton.SetActive (false);
				lockImage.SetActive (false);
			}
			else if (i == 1) {
				TopSpeed.fillAmount = 0.6f;
				Engine.fillAmount = 0.75f;
				Controls.fillAmount = 0.8f;
				suspension.fillAmount = 0.95f;
				TopSpeedValue.text = "100";
				EngineValue.text = "80";
				ControlsValue.text = "80";
				BuyText.text = Truck1.ToString ();
				if (PlayerPrefs.GetInt ("Truck1") == 0) {
					BuyButton.SetActive (true);
					lockImage.SetActive (true);
				} else {
					BuyButton.SetActive (false);
					lockImage.SetActive (false);
				}

			}
			else if (i == 2) {
				TopSpeed.fillAmount = 0.7f;
				Engine.fillAmount = 0.85f;
				Controls.fillAmount = 0.9f;
				suspension.fillAmount = 0.5f;
				TopSpeedValue.text = "110";
				EngineValue.text = "85";
				ControlsValue.text = "90";
				BuyText.text = Truck2.ToString ();
				if (PlayerPrefs.GetInt ("Truck2") == 0) {
					BuyButton.SetActive (true);
					lockImage.SetActive (true);
				} else {
					BuyButton.SetActive (false);
					lockImage.SetActive (false);
				}

			}
			//commented for extra 2
			//			else if (i == 3) {
			//				TopSpeed.fillAmount = 0.8f;
			//				Engine.fillAmount = 0.9f;
			//				Controls.fillAmount = 0.8f;
			//				TopSpeedValue.text = "120";
			//				EngineValue.text = "90";
			//				ControlsValue.text = "95";
			//				BuyText.text = Truck3.ToString ();
			//				if (PlayerPrefs.GetInt ("Truck3") == 0) {
			//					BuyButton.SetActive (true);
			//				} else {
			//					BuyButton.SetActive (false);
			//				}
			//
			//			}
			//			else if (i == 4) {
			//				TopSpeed.fillAmount = 1.0f;
			//				Engine.fillAmount = 1f;
			//				Controls.fillAmount = 0.7f;
			//				TopSpeedValue.text = "140";
			//				EngineValue.text = "95";
			//				ControlsValue.text = "70";
			//				BuyText.text = Jeep.ToString ();
			//				if (PlayerPrefs.GetInt ("Jeep") == 0) {
			//					BuyButton.SetActive (true);
			//				} else {
			//					BuyButton.SetActive (false);
			//				}
			//			}
			//commented for extra 2
		}
	}
	public IEnumerator prevCorotine()
	{
		//if (GameConstantLocal.Mode == "Challenege") {
		yield return new WaitForSeconds (0f);
		prevMethod = true;
		nextMethod = true;
		Vehicles [i + 1].SetActive (false);
	}

	public void Select()
	{
		//		ConsoliAds.Instance.ShowInterstitial (5);


		GameConstantLocal.VehicleSelected = i;
		LoadingScreen.SetActive (true);
		vehiclesImage[GameConstantLocal.VehicleSelected].SetActive(true);
		levelImage [GameConstantLocal.Level].SetActive (true);
		GameAnalytics.NewDesignEvent ("UI_Navigation:VehicleSelectionScreen:"+GameConstantLocal.VehicleSelected+":VehicleSelected");
		Application.LoadLevel ("GamePlay");
		if (PlayerPrefs.GetInt("RemoveAds")!=1) {
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.ShowInterstitial(1);	
			}
		}


	}


	public void Back()
	{
//		anim = MainCamera.transform.GetComponent<Animator> ();
//		anim.SetTrigger ("RevertToMainMenu");
		Application.LoadLevel("levelselection");

	}

	public void UnlockChars(string unlockChars){
        IAPPlugin.instance.BuyProductID(unlockChars);
	}



  
}
