using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public GameObject ObjToSpawn;
	public Transform SpawnPoint;
	// Use this for initialization
	void Start () {
		ObjToSpawn.transform.position = SpawnPoint.position;
		ObjToSpawn.transform.rotation = SpawnPoint.rotation;
	
	}

}
