using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelection : MonoBehaviour {
	public GameObject[] vehicles;
	public GameObject prev;
	public GameObject next;
	int i = 0;
	void Update()
	{
		if (i == 0) {
			prev.SetActive (false);
		} else {
			prev.SetActive (true);
		}if (i == 4) {
			next.SetActive (false);
		} else {
			next.SetActive (true);
		}
	}
	public void Next()
	{
		vehicles [i].SetActive (false);
		i++;
		vehicles [i].SetActive (true);

	}
	public void Prev()
	{
		vehicles [i].SetActive (false);
		i--;
		vehicles [i].SetActive (true);
	}
	public void Select()
	{
		GameConstantLocal.VehicleSelected = i;
		SceneManager.LoadScene ("GamePlay");
	}
	public void Back()
	{
		SceneManager.LoadScene ("ModeSelection");
	}
}
