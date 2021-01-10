using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHandler : MonoBehaviour {
	public GameObject [] Crate1Position;
	public GameObject Crate1;
	public GameObject Crate;
	public GameObject Crate2;
	int countCrate = -1;
	int count;
	int count2;
	GamePlay GP;
	void Start()
	{
		GP = GameObject.FindObjectOfType<GamePlay> ();
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Crate")) {
			count2 = 1;
				count++;
			if (count == 1) {
				countCrate = 0;
			} else {
				countCrate++;
			}
		
		}if (col.CompareTag ("Crate1")) {
			count2 = 2;
				count++;
			if (count == 1) {
				countCrate = 0;
			} else {
				countCrate++;
			}

		}if (col.CompareTag ("Crate2")) {
			count2 = 3;
				count++;
			if (count == 1) {
				countCrate = 0;
			} else {
				countCrate++;
			}

		}
	}

	void Update()
	{
		
		if(count2 ==1)
			Crate.transform.position = Vector3.Lerp (Crate.transform.position,Crate1Position[countCrate].transform.position,2);
		if(count2 ==2)
			Crate1.transform.position = Vector3.Lerp (Crate1.transform.position,Crate1Position[countCrate].transform.position,2);
		if(count2 ==3)
			Crate2.transform.position = Vector3.Lerp (Crate2.transform.position,Crate1Position[countCrate].transform.position,2);
		if (Crate1Position.Length == countCrate+1) {
			if (GameConstantLocal.Level == 7) {
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level7CorotinePart3 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;

			} else if(GameConstantLocal.Level == 11){
				GP.Fade.SetActive (true);
				StartCoroutine (GP.Level11CorotinePart1 ());
				gameObject.transform.GetChild (0).gameObject.SetActive (false);
				gameObject.transform.GetChild (1).gameObject.SetActive (false);
				gameObject.transform.GetChild (2).gameObject.SetActive (false);
				gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
			}else {
				//GP.LevelComplete ();
				GP.LevelCrateEndCutscene();
				gameObject.SetActive (false);
			}
		}
	}
}
