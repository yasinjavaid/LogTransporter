using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeEconomy : MonoBehaviour {
	public GameObject StartPoint;
	public GameObject EndPoint;
	public Text TimeText;
	public Text FinalTimeTextComplete;
	public Text FinalTimeTextFailed;
	public Text FinalScore;
	public GameObject[] stars;
	public Text DamageText;
	public Text CashRewardText;



	float time;
	bool calculatetime =  false;
	int damage = 0;
	int BaseTime = 130;
	int _timeFinalScore;
	int _FinalScore;
	int _damageFinalScore;
	int _timeCash;
	int _damageCash;
	int _TotalCash;
	int minutes;
	int seconds;
	float damagepercentage;
	int FinalCash;
	GamePlay GP;
	// Use this for initialization
	void Start () {
		GP = GameObject.FindObjectOfType<GamePlay> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (calculatetime) {
			time += Time.deltaTime;

		}
		minutes = ((int)time / 60);
		seconds = ((int)time % 60);
		TimeText.text = minutes.ToString () + ":" + seconds.ToString() ;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("StartLap")) {
			calculatetime = true;
			EndPoint.SetActive (true);
			StartPoint.SetActive (false);
		}
		if (col.CompareTag ("EndLap")) {
			calculatetime = false;
			EndPoint.SetActive (false);
			Debug.Log ("Time: " + ((int)time/60) + " : " + ((int)time % 60) +" OR Time = " + time);
			CalculateDamageBonus ();
			CalculateTimeDiffrenceBonus ();
			TotalStats ();
			GP.LevelComplete ();
		}

	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "tyre" || col.gameObject.tag == "Fence") {
			damage++;
			if (damage > 30) {
				GP.GameOver ();
				TotalStats ();

			}
		}
	}
	void CalculateTimeDiffrenceBonus()
	{
		if (time <= BaseTime) {
			_timeFinalScore = 150+(((int)(BaseTime - time)) * 3);

		} else if (time > BaseTime && ((int)(time - BaseTime)) <= 20) {
			_timeFinalScore = 140-(((int)(time - BaseTime)) * 2);
		
		} else if (((int)(time - BaseTime)) > 20 && ((int)(time - BaseTime)) <= 50) {
			_timeFinalScore = 80-((int)(time - BaseTime));
		} else if (((int)(time - BaseTime)) > 50) {
			_timeFinalScore = 0;
		}
	}
	void CalculateDamageBonus()
	{
		if (damage == 0) {
			_damageFinalScore = 300;
		} else if (damage > 0 && damage <= 15) {
			_damageFinalScore = 300-(damage * 10);
		} else if (damage > 15 && damage <= 30) {
			_damageFinalScore = 150-(damage * 5);
		}
	}
	public void TotalStats()
	{
		
		_FinalScore = _timeFinalScore + _damageFinalScore;
		FinalCash = _FinalScore + 50;
		damagepercentage = (((float)damage) / 30f) * 100f;
		Debug.Log (damage);
		Debug.Log (damagepercentage);
		FinalScore.text = _FinalScore.ToString ();
		FinalTimeTextComplete.text = minutes.ToString () + ":" + seconds.ToString() ;
		CashRewardText.text = FinalCash.ToString ();
		FinalTimeTextFailed.text = minutes.ToString () + ":" + seconds.ToString() ;
		DamageText.text = ((int)damagepercentage).ToString () + " %";
		if (_FinalScore >= 425) {
			stars [0].SetActive (true);
			stars [2].SetActive (true);
			stars [1].SetActive (true);

		} else if (_FinalScore < 425 && _FinalScore >= 250) {
			stars [0].SetActive (true);
			stars [1].SetActive (true);
		}
		else if (_FinalScore < 250 && _FinalScore >= 100) {
			stars [0].SetActive (true);

		}
		PlayerPrefs.SetInt ("Cash",PlayerPrefs.GetInt("Cash") + FinalCash);
		Debug.Log ("Final Score = " + _FinalScore + " : Damage Score = " + _damageFinalScore + " : Time = " + _timeFinalScore );
//		OziPlugin.SubmitScore (_FinalScore);

	}
}
