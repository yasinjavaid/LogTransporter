using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vTutorialTextTrigger : MonoBehaviour
{
    //[TextAreaAttribute(5, 3000), Multiline]    
    //public string text;
    //public Text _textUI;
    //public GameObject painel;

    private void OnTriggerEnter(Collider triggerObject)
    {
      /* if(triggerObject.gameObject.tag.Equals(GameConstants.PLAYER_TAG))
        {
            _EventManager.OnTutorialObjectiveAchieved.Invoke(); 
            this.transform.parent.gameObject.SetActive(false);
        }*/
    }

  /*  private void OnTriggerExit(Collider triggerObject)
    {
        if (triggerObject.gameObject.tag.Equals(GameConstants.PLAYER_TAG))
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }*/
}
