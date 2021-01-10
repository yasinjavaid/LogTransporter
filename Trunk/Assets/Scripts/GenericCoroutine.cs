using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GenericCoroutine : MonoBehaviour {

	// Use this for initialization


	IEnumerator Wait(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		gameObject.SetActive (false);
	}

	void OnEnable()
	{
		StartCoroutine(Wait(4.0F));
	}

    public void turnOffRayCastImg()
    {
        GetComponent<Image>().raycastTarget = false;
    }
}
