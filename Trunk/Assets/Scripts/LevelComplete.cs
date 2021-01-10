using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
	public GamePlay gamePlay;
    // Start is called before the first frame update
	void OnEnable(){

	}
    void Start()
    {
		if(LookTowardsTarget.instance)
		LookTowardsTarget.instance.target = this.gameObject.transform;

    }

	public void OnTriggerEnter(Collider other){
		if(other.gameObject.tag =="Player"||other.gameObject.tag =="WoodenLog"){
			gamePlay.LevelComplete ();
		}
	}
}
