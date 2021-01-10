using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SplashScreenManager : MonoBehaviour
{

	//public string sceneName;
    public string splashName;
    public Image splashImage;

    void Start()
    {
		
        //Invoke("OnSplash",3.0f);
       // StartCoroutine(Splash(1.0F));
        Handheld.PlayFullScreenMovie(splashName, Color.black, FullScreenMovieControlMode.Hidden);
        SceneManager.LoadSceneAsync(GameConstants.MAIN_MENU_SCENE);
        //splashImage.gameObject.SetActive((true));
    }
    IEnumerator Splash(float wait)
    {
        yield return new WaitForSeconds(wait);
        splashImage.gameObject.SetActive((true));
    }

}
