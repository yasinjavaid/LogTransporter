using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateArrowTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Crate1")) {
			gameObject.SetActive (false);
		}
		if (col.CompareTag ("Crate2")) {
			gameObject.SetActive (false);
		}
		if (col.CompareTag ("Crate")) {
			gameObject.SetActive (false);
		}

	}
}
