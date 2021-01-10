using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsTarget : MonoBehaviour
{
	public Transform target;
	public static LookTowardsTarget instance;

	void OnEnable(){
		if(instance==null)
			instance = this;	
	}
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		transform.LookAt(target);
    }
}
