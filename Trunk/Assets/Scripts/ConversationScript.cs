using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace FK.DialogueScript{
	[System.Serializable]
	public class ConversationText{
		public string Text;

	}
	public class ConversationScript : MonoBehaviour {
	
		public GameObject ConversationUI;
		public GameObject BossImage;
		public GameObject PlayerImage;
		public GameObject bossTextImage;
		public GameObject PlayerTextImage;
		public Text textPanelBoss;
		public Text textPanelPlayer;
		public ConversationText[] conversationText;
		public Button NextButton;
		public Button SkipButton;

		bool player;
		bool boss;
		public UnityEvent OnCompleteEvent;
		int i; 
		void Start (){
			Button btn = NextButton.GetComponent<Button> ();
			btn.onClick.AddListener (Next);
			Button btnSkip = SkipButton.GetComponent<Button> ();
			btnSkip.onClick.AddListener (Skip);
		}
		void OnEnable()
		{
			ConversationUI.SetActive (true);
			PlayerImage.SetActive (false);
			PlayerTextImage.SetActive (false);
			i = 0;
			DisplayText ();
		}
		public void DisplayText()
		{
			if (i != conversationText.Length) {
				if (i == 0) {
					bossTextImage.SetActive (true);
					BossImage.SetActive (true);
					textPanelBoss.text = conversationText [i].Text;
				} else if (i % 2 != 0) {
					BossImage.SetActive (false);
					PlayerImage.SetActive (true);
					PlayerTextImage.SetActive (true);
					bossTextImage.SetActive (false);
					textPanelPlayer.text = conversationText [i].Text;
				} else if (i % 2 == 0) {
					PlayerImage.SetActive (false);
					BossImage.SetActive (true);
					PlayerTextImage.SetActive (false);
					bossTextImage.SetActive (true);
					textPanelBoss.text = conversationText [i].Text;
				}
			} else if(i == conversationText.Length){
				
				ConversationUI.SetActive (false);
				OnCompleteEvent.Invoke ();
				i = 0;
				gameObject.SetActive (false);
			}
		}
		public void Next()
		{
			if (gameObject.activeInHierarchy == false) {
				return;
			}
			i++;
			DisplayText ();
			Debug.Log (i);
		}
		public void Skip()
		{
			if (gameObject.activeInHierarchy == false) {
				return;
			}

			ConversationUI.SetActive (false);
			OnCompleteEvent.Invoke ();
			i = 0;
			gameObject.SetActive (false);
		}
	}
}
