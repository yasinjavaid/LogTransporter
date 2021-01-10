using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetrolRefill : MonoBehaviour {
//	public Image Fuel;
	[SerializeField]
	private int fillRate;
	public GamePlay gamePlay;
	Coroutine petrolFillingCoroutine;
	public GameObject levelCompleteCheckPoint,fuelCheckPoint;
	void OnEnable(){
		
	}
	void Start(){
		if (GameConstantLocal.Level == 0)
			gamePlay.FuelImage.fillAmount = 0;

		levelCompleteCheckPoint.SetActive (false);
		if(LookTowardsTarget.instance){
			LookTowardsTarget.instance.target = fuelCheckPoint.transform;
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
			petrolFillingCoroutine=StartCoroutine(FillingFuel());
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player")) {
			StopAllCoroutines ();
		}
	}
	//contionously checking the value of the fuel bar
	public IEnumerator FillingFuel(){
		yield return new WaitForSeconds(1f);
		gamePlay.FuelImage.fillAmount += fillRate * Time.deltaTime;
		if(gamePlay.FuelImage.fillAmount==1){
			if (petrolFillingCoroutine != null)
				StopCoroutine (petrolFillingCoroutine);
			fuelCheckPoint.SetActive (false);
			gamePlay.fuel = true;
			levelCompleteCheckPoint.SetActive (true);

			yield return null;
	}
		petrolFillingCoroutine=StartCoroutine (FillingFuel());


}
}
