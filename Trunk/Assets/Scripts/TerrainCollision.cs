using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollision : MonoBehaviour {
	GamePlay GP;
	bool once = true;
	void Start()
	{
		GP=GameObject.FindObjectOfType<GamePlay>();
	}
	void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.tag == "CrateIn" || col.gameObject.tag == "Barrel"|| col.gameObject.tag == "WoodenLog") {
			if (once) {
				GP.GameOver ();
				once = false;

			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Rolled")) {
			if (once) {
				GP.GameOver ();
				once = false;

			}
		}

	}



}
