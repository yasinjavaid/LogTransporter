using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float totalTime;
	public Text timer;
//	public Text AlertTimer;
	public static GameTimer instance; 
	public static bool extraTimeRewarded;
	public GamePlay gamePlay;
	public bool timeCheckOnce=true;
	void Awake(){
		
		if (instance == null) {
			instance = this;
		} 
		else {
			Destroy (this.gameObject);
		}
	}
	public void Start()
	{
		if (PlayerPrefs.GetInt ("DoubleTime", 0) == 0) {
			totalTime = 210.0f;
		} 
		else {
			totalTime = 420.0f;

		}
//		totalTime = GameConstants.LevelTime;



	}

//	IEnumerator TimerCoroutine()
//	{
//		UpdateLevelTimer (totalTime);
//		while (totalTime > 0) {
//			UpdateLevelTimer (totalTime);
//			yield return new WaitForSeconds (1);
//			totalTime -= 1;
//
//		}
//		if (totalTime <= 0) {
//			Time.timeScale = 0;
//			UiManager.instance.LevelFailed.gameObject.SetActive(true);
//			if (AdsPlugin.Instance) {
//				AdsPlugin.Instance.showInterstitialAd(MediationSettings.interOnGpEndAdUnitId);
//			}
//		}
//	}
	private void Update()
	{
		totalTime -= Time.deltaTime;
		if (totalTime >= 0) {
			UpdateLevelTimer (totalTime);

		}

			if (totalTime < 0) {
			if (timeCheckOnce) {
				gamePlay.GameOver ();
				totalTime = 0;
				timeCheckOnce = false;
			}
				
			}

		
	}

	public void UpdateLevelTimer(float totalSeconds)
	{
		int minutes = Mathf.FloorToInt(totalSeconds / 60f);
		int seconds = Mathf.RoundToInt(totalSeconds % 60f);

		string formatedSeconds = seconds.ToString();

		if (seconds == 60)
		{
			seconds = 0;
			minutes += 1;
		}

		timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}

	public void ExtraTimeRewarded(){
		Time.timeScale = 1;


//		

		if (PlayerPrefs.GetInt ("DoubleTime", 0) == 0) {
			totalTime = 210.0f;
		} 
		else {
			totalTime = 420.0f;

		}
		UpdateLevelTimer (totalTime);



	}

	public void ObjectiveOK(){
		
		if (PlayerPrefs.GetInt ("DoubleTime", 0) == 0) {
			totalTime = 150.0f;
		} 
		else {
			totalTime = 300.0f;

		}


	}
}
