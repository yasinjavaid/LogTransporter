using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KK.CutScene
{
	[System.Serializable]
	public class StateText
	{
		public float TimeToShow;
		public float TimeBeforeShow;
		public string sText;
		bool complete;
	}

	/// <summary>
	/// CutScene State Time,Cam,Events
	/// </summary>
	[System.Serializable]
	public class CutSceneState
	{
		[Header("State Attributes")]
		public float StateTime;
		public float DoSomeThingAfter;
		public GameObject vCam;


		[Header("Text To Show")]
		public StateText[] texts;

		[Header("State Events")]
		public UnityEvent DoSomeThing;
		public UnityEvent OnStart;
		public UnityEvent OnEnd;

		public void StartState()
		{
			if (vCam!= null)
				vCam.SetActive (true);

			if (OnStart != null) {
					OnStart.Invoke ();
				}
			
		}

		public void EndState()
		{
			if (vCam!= null)
			vCam.SetActive(false);
			
			if (OnEnd != null)
			{
				OnEnd.Invoke();
			}
		}
	}

	/// <summary>
	/// Traverse Between Cutscene States
	/// </summary>
	public class CutSceneManager : MonoBehaviour
	{
		public bool PlayOnStart = true;
		public bool PlayOnlyOnce = false;
		public GameObject PlayerControlls, CutSceneUI, CutSceneCamera;
		public Text CutSceneText;
		bool doSkipText = false;

		[Header("CutScene States")]
		public List<CutSceneState> SceneStates;

		[Header("CutScene Over")]
		public UnityEvent CutSceneOverEvent;
	
		bool completed = false;
		int StateIndex = 0;
		AudioSource TypeSound;
		CutSceneState currentState;


		IEnumerator ShowStateText()
		{
			tap = false;
			doSkipText = false;
			Debug.Log("Text Cleared At Start ");
			CutSceneText.text = "";
			foreach (StateText s in currentState.texts)
			{
				tap = false;
				tap2 = false;
				if (TypeSound)
					TypeSound.Play();
				yield return new WaitForSeconds(s.TimeBeforeShow);
				canEndState = false;
				for (int i = 0; i < s.sText.Length; i++) {
					CutSceneText.text = CutSceneText.text + s.sText [i];
					if (!tap2) {
						yield return new WaitForSeconds (.03f);
					}
				
				}
				yield return new WaitUntil (()=> tap);
				if (TypeSound)
					TypeSound.Stop();
				StartCoroutine (WaitOrSkip(s.TimeToShow));
				yield return new WaitUntil( ()=> doSkipText);
				doSkipText = false;
//				StopCoroutine ("WaitOrSkip");
				Debug.Log("Text Cleared AT End");
				CutSceneText.text = "";
			}

			Debug.Log ("Out Of FOREACH");
			if (tap) {
				StopCoroutine ("WaitOrSkip");
				StopCoroutine ("WaitOrSkipState");
			}

			if (canEndState)
				doEndState = true;
			yield break;
		}
		bool doEndState = false;
		bool canEndState = false;
		public bool tap = false ;
		public bool tap2 = false;

		public void SkipText(){
			doSkipText = true;
			canEndState = true;
			
				tap = true;
			
			tap2 = true;
		}
		IEnumerator WaitOrSkip(float wait){
			yield return new WaitForSeconds (wait);
			doSkipText = true;
		}
		IEnumerator WaitOrSkipState(float wait){
			yield return new WaitForSeconds (wait);
			doEndState = true;
		}

		// Cut Scene Start & Finish
		public void FinishCutScene()
		{	
			if (PlayerControlls != null)
				PlayerControlls.SetActive(true);
			if (CutSceneUI != null)
				CutSceneUI.SetActive(false);
			if (CutSceneCamera != null)
				CutSceneCamera.SetActive(false);
			CutSceneOverEvent.Invoke();
		}

		public void StartCutScene()
		{
			if (PlayerControlls != null)
				PlayerControlls.SetActive(false);
			if (CutSceneUI != null)
				CutSceneUI.SetActive(true);
			if (CutSceneCamera != null)
				CutSceneCamera.SetActive(true);
			StartSceneState(SceneStates[StateIndex]);
		}
	
		// Use this for initialization
		void Start()
		{
			if (GetComponent<AudioSource>())
				TypeSound = GetComponent<AudioSource>();
			if (PlayOnStart)
			{
				if (PlayOnlyOnce)
				{
					if (PlayerPrefs.GetInt("Cutscene", 0) == 0)
					{
						StartCutScene();
						PlayerPrefs.SetInt("Cutscene", 1);
					}
					else
					{
						if (CutSceneOverEvent != null)
							CutSceneOverEvent.Invoke();
						gameObject.SetActive(false);
					}
				}
				else
				{
					StartCutScene();
				}
			}

		}

		void StateCompletd()
		{
			StateIndex++;
			if (StateIndex < SceneStates.Count)
			{
				StartSceneState(SceneStates[StateIndex]);
			}
			else
			{
				if (!completed)
				{
					FinishCutScene();
					completed = true;
				}
			}
		}

		IEnumerator WaitToDoSomeThing()
		{
			if (currentState == null)
				yield break;
			
			yield return new WaitForSeconds(currentState.DoSomeThingAfter);
			if (currentState.DoSomeThing != null)
			{
				currentState.DoSomeThing.Invoke();
			}
		}

		IEnumerator WaitForStateComplete()
		{
			StartCoroutine (WaitOrSkipState(currentState.StateTime));
			yield return new WaitUntil(()=>doEndState);
			doEndState = false;
			EndSceneState();
			StateCompletd();
		}

		// Manage Scene State
		void StartSceneState(CutSceneState s)
		{
			s.StartState();
			currentState = s;

			if (currentState.texts.Length > 0)
			{	
				StopCoroutine(ShowStateText());
				StartCoroutine(ShowStateText());
			}
			StartCoroutine(WaitToDoSomeThing());
			StartCoroutine(WaitForStateComplete());
		}

		void EndSceneState()
		{
			if (currentState == null)
				return;
			StopCoroutine(WaitToDoSomeThing());
			StopCoroutine(WaitForStateComplete());
			currentState.EndState();
		}

	}
}
