﻿using System.Collections;using System.Collections.Generic;using UnityEngine;public class CutScenePlayer : MonoBehaviour{	string StoryCutScenePref = "CSPref12";	public GameObject StoryCutScene;	public GameObject ObjectiveCutScene;	// Use this for initialization	void Start()	{		if (StoryCutScene != null)		{			StoryCutScene.SetActive(true);//			if (PlayerPrefs.HasKey(StoryCutScenePref))//			{//				ObjectiveCutScene.SetActive(true);//			}//			else//			{//				StoryCutScene.SetActive(true);//				PlayerPrefs.SetInt(StoryCutScenePref, 1);//				PlayerPrefs.Save();//			}		}		else		{			ObjectiveCutScene.SetActive(true);		}	}}