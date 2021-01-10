using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehiclePanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("unlocktrucks") == 1)
        {
            //
        }
        else
        {
//            MainMenu._instance.unlockAllVehiclesPanel.SetActive(true);
        }
    }

}
