using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

	public GameObject []PlayerSpawnPosition;

	void Awake()
	{
		//Debug.LogError ("Selectedlevel" + GameConstants.SelectedLevel);
//		Debug.LogError("shoyld be here");
		GameConstantLocal.PlayerLevelPosition = PlayerSpawnPosition [GameConstantLocal.Level - 1].transform.position;
		//Debug.LogError ("Selectedlevel" + GameConstants.PlayerLevelPosition);
	}
	// Use this for initialization
	void Start () {
		GameConstantLocal.PlayerLevelPosition = PlayerSpawnPosition [GameConstantLocal.Level - 1].transform.position ;
	//	Debug.LogError("shoyld be here too");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
