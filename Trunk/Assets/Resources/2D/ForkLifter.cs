using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ForkLifter : MonoBehaviour {

	public float UpLimit,DownLimit,speed;
	bool moveUp,moveDown;
	public Slider slide;
	public GameObject audioObject;
	public bool forAudio;
	// Use this for initialization
	void Start () {
		moveUp = false;
		moveDown = false;
		slide.value = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.Z)) {
//			moveUp = true;
//		}
//		if (Input.GetKeyDown (KeyCode.X)) {
//			moveDown = true;
//		}
//		if (Input.GetKeyUp (KeyCode.Z)) {
//			moveUp = false;
//		}
//		if (Input.GetKeyUp (KeyCode.X)) {
//			moveDown = false;
//		}


		if (slide.value > 0f) {
			forAudio = true;
			Up ();
		} else if (slide.value < 0f) {
			forAudio = true;
			Down ();
		} else {
			forAudio = false;
		}

		if (forAudio) {
			audioObject.SetActive (true);
		} else {
			audioObject.SetActive (false);
		}
	}

	void Up(){
		if (transform.localPosition.y < UpLimit) {
			transform.Translate (0,speed*Time.deltaTime,0);
		}
	}
	void Down(){
		if (transform.localPosition.y > DownLimit) {
			transform.Translate (0,-speed*Time.deltaTime,0);
		}
	}
	public void ResetSlide(){
		slide.value=0.0f;
	}
}
