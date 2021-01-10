using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : BaseMenu
{


    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        OnBackBtnPress();                   // If no override than Base Behaviour is Called
    //    }
    //}


    #region Events
    public void Play()
    {
        MenuManager.Instance.PushMenu(GameManager.GameState.SelectionScene);
    }


    public void OnFinishedTest(string abc, int a, GameObject hello)
    {
        Debug.Log(abc + " and " + a);
        Debug.Log(hello.name);
    }

    #endregion

    #region Inherited_Behaviour

    //override public void OnBackBtnPress()
    //{

    //    // Do My Custom Back Button Implementation
    //    Debug.Log("Custom Back Button Implementation");

    //}

    #endregion
}
