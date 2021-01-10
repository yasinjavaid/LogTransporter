using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
public class Levelselection : MonoBehaviour
{
	public GameObject []levelLocks,selectedForms,unlockLevelComp;
	public int unlockLevel;
	public GameObject playButton;
    public static Levelselection _instance;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
		
		Time.timeScale = 1;
		unlockLevel = PlayerPrefs.GetInt ("LevelComplete");

		Debug.Log ("unlock levels are "+ unlockLevel);
		playButton.SetActive (false);
		for (int i = 0 ; i <=unlockLevel; i++) 
			levelLocks [i].SetActive (false);

		if(PlayerPrefs.GetInt ("LevelComplete")!=9){
			foreach(GameObject unlockLevelsComp in unlockLevelComp){
				unlockLevelsComp.SetActive (true);
			}
		}
    }

	void Update(){
		if(PlayerPrefs.GetInt ("LevelComplete")==9){
			foreach(GameObject unlockLevelsComp in unlockLevelComp){
				unlockLevelsComp.SetActive (false);
			}
		}
	}
	public void LevelSelection(int level){
		GameConstantLocal.Level = level;
		playButton.SetActive (true);
		for(int i=0 ; i< selectedForms.Length; i++)
		selectedForms [i].SetActive (false);
		selectedForms [GameConstantLocal.Level].SetActive (true);
		GameAnalytics.NewDesignEvent ("UI_Navigation:LevelSelectionScreen:"+GameConstantLocal.Level+":LevelSelected");
	}

	public void Select(){
		if (PlayerPrefs.GetInt("RemoveAds")!=1) {
			if(ConsoliAds.Instance){
				ConsoliAds.Instance.ShowInterstitial(1);	
			}
		}
		SceneManager.LoadScene ("charactereselection");
	}

	public void Back(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void UnlockLevels(string unlockLevel){
        IAPPlugin.instance.BuyProductID(unlockLevel);
	}
  
}
