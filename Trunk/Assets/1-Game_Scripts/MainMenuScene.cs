using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MainMenuScene : BaseMenu
{
    void Start()
    {
        ParticleManager.Instance.ShowParticle(ParticleManager.Instance.Appreciation, 5, Vector2.zero, true);
    }

    public override void Update()
    {
        base.Update();
        // Do anything
    }


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
    public void OnFinishedTest(GameObject hello)
    {
        Debug.Log(hello.name);
    }

    #endregion

    #region Inherited_Behaviour

    override public void OnBackBtnPress()
    {

        // Do My Custom Back Button Implementation
        Debug.Log("Custom Back Button Implementation");



        //MenuManager.Instance.PopMenuToState(GameManager.GameState.MainMenuScene);


    }



    #endregion

}
