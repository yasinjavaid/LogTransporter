using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVP;

public class LevelCheckpoint : MonoBehaviour {
	GamePlay GP;

	void Start()
	{
		GP = GameObject.FindObjectOfType<GamePlay> ();
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
			if (GameConstantLocal.Level == 4) {
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level4Corotine ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;

			} 
			else if (GameConstantLocal.Level == 7 && GameConstantLocal.level7 == 0) {
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level7CorotinePart2 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level7 = 1;

			}
			else if (GameConstantLocal.Level == 8 && GameConstantLocal.level8 == 0) {
				Debug.Log ("Level 8 part 1 complete");
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level8CorotinePart1 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level8 = 1;
			}
			else if (GameConstantLocal.Level == 8 && GameConstantLocal.level8 == 1) {
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level8CorotinePart2 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level8 = 2;
			}
			else if (GameConstantLocal.Level == 10 && GameConstantLocal.level10 == 0) {
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level10Corotine ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level10 = 1;
			} else if(GameConstantLocal.Level == 11 && GameConstantLocal.level11 == 0)
			{
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level11CorotinePart2 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level11 = 1;
			}else if(GameConstantLocal.Level == 12 && GameConstantLocal.level12 == 0)
			{
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level12CorotinePart1 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level12 = 1;
			}else if(GameConstantLocal.Level == 12 && GameConstantLocal.level12 == 1)
			{
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level12CorotinePart2 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level12 = 2;
			}else if(GameConstantLocal.Level == 14 && GameConstantLocal.level14 == 0)
			{
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level14CorotinePart1 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level14 = 1;
			}else if(GameConstantLocal.Level == 14 && GameConstantLocal.level14 == 1)
			{
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level14CorotinePart2 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
				GameConstantLocal.level14 = 2;
			}else {
				if (GameConstantLocal.Level == 1) {
					GP.Fade.SetActive (true);
					GP.LevelComplete ();
				}else{
					GP.LevelEndCutscene ();
				//GP.LevelComplete ();
				}
				gameObject.SetActive (false);
			}

			
		}
	}

}
