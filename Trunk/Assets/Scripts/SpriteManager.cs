using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour {

	public Image p1, p2;
	public Sprite s1,s2;
	// Use this for initialization
	void Start () {
		p1.sprite = s1;
		p2.sprite = s2;
	}
	

}
