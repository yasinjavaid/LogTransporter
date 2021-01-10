using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inAppTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonClicked(string id)
    {
        Debug.Log("before inApp");
        IAPPlugin.instance.BuyProductID(id);
        Debug.Log("After inApp");
    }
}
