using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateManager : MonoBehaviour
{
    public UnityEvent redownload;

    int date;
    int month;

    public void CheckForDayUpdate()
    {
        date = int.Parse(System.DateTime.Now.ToString("dd"));
        month = int.Parse(System.DateTime.Now.ToString("MM"));

        if (!PlayerPrefs.HasKey("DailyCounter"))
        {
            PlayerPrefs.SetInt("DailyCounter", 0);
            PlayerPrefs.SetInt("weeklyUpdate", date);
        }
        else
        {
            CheckMonthChange();
            CheckForUpdate();
        }

    }

    void CheckMonthChange()
    {
        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                if (PlayerPrefs.GetInt("weeklyUpdate") == 31)
                    PlayerPrefs.SetInt("weeklyUpdate", 0);
                break;
            case 2:
                if (PlayerPrefs.GetInt("weeklyUpdate") == 28 || PlayerPrefs.GetInt("weeklyUpdate") == 29)
                    PlayerPrefs.SetInt("weeklyUpdate", 0);
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                if (PlayerPrefs.GetInt("weeklyUpdate") == 30)
                    PlayerPrefs.SetInt("weeklyUpdate", 0);
                break;
        }
    }

    void CheckForUpdate()
    {
        if (date != PlayerPrefs.GetInt("weeklyUpdate"))
        {
            if (date - PlayerPrefs.GetInt("weeklyUpdate") >= 7)
            {
                RedownloadFile();
                PlayerPrefs.SetInt("weeklyUpdate", 0);
                PlayerPrefs.SetInt("weeklyUpdate", date);
            }
            //else if (date - PlayerPrefs.GetInt("weeklyUpdate") > 7)
            //{
            //    PlayerPrefs.SetInt("weeklyUpdate", date);
            //    RedownloadFile();
            //}

        }
        else
        {
            // same day condition
        }
    }

    void RedownloadFile()
    {
        redownload.Invoke();
        UpdateDailyCounter();
    }

    void UpdateDailyCounter()
    {
        int updateCounter = (PlayerPrefs.GetInt("DailyCounter") + 1) % 7;
        PlayerPrefs.SetInt("DailyCounter", updateCounter);
        PlayerPrefs.Save();
    }
}
