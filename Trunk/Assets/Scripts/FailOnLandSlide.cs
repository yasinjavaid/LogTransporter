using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailOnLandSlide : MonoBehaviour
{
	public GamePlay GP;
	bool once = true;
	void Start()
	{
		
	}
	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag == "Player") {
			if (once) {
				GP.GameOver ();
				once = false;

			}
		}
	}
}
