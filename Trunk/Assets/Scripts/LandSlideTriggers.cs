using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSlideTriggers : MonoBehaviour
{
	public GameObject[] rocks;
	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "Player") {
			for (int i = 0; i < rocks.Length; i++) {
				rocks [i].gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			}
	}
	}
}

