using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScene : BaseMenu
{

    public SpriteRenderer sp;

    void Start()
    {
        ParticleManager.Instance.LevelCompleted.SetActive(true);

        //Camera.main.ZoomIn(sp.transform.position, 2f);
        //transform.localScale = new Vector2(transform.localScale.x, 10);

        //transform.YScaleSetter(10);

        //GetComponent<TweenPosition>().ResetAndPlay();
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        OnBackBtnPress();                   // If no override than Base Behaviour is Called
    //    }

    //    //Zoom Functionality Test
    //    //if (Input.GetMouseButtonDown(0))
    //    //{
    //    //    Camera.main.ZoomIn(Camera.main.ScreenToWorldPoint(Input.mousePosition), 2f);
    //    //}
    //    //if (Input.GetMouseButtonDown(1))
    //    //{
    //    //    Camera.main.ZoomOut();
    //    //}
    //}

    public void GoAhead()
    {
        MenuManager.Instance.PushMenu(GameManager.GameState.GamePlayScene);
        ParticleManager.Instance.LevelCompleted.SetActive(false);
    }

    public void Delay()
    {
        //sp.MakeCustomPixel(300, 180);
        //Camera.main.ZoomOut();
    }

    public override void OnBackBtnPress()
    {
        MenuManager.Instance.PopMenu();
        ParticleManager.Instance.LevelCompleted.SetActive(false);
    }

}
