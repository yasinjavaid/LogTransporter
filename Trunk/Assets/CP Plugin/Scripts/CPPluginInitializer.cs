using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class CPPluginInitializer : MonoBehaviour
{
    public static CPPluginInitializer instance;

    private UpdateManager updateManager;

    private string bundleID;

    [HideInInspector]
    public string downloadDirectoryPath;
    [HideInInspector]
    public string fileToDownLoadPath;
    [HideInInspector]
    public string downloadedFilePath;

    [Tooltip("If Checked: Load the pics sequentially starting from index 0. If unchecked: The pics will be loaded randomly")]
    public bool loadInSequence;

    [Tooltip("Recheck download if download fails, after the time provided (in seconds)")]
    public float timeToRecheckInSecondsIfDownloadFails = 60;

    [HideInInspector]
    public bool downloadedSuccessfully = false;

    private void Awake()
    {
        bundleID = Application.identifier;

        if (bundleID == "")
        {
            Debug.Log("Please provice bundle id");
            return;
        }

        updateManager = GetComponent<UpdateManager>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitiaLizeDirectories();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        InitiaLizeDirectories();

        if (bundleID != "")
        {
            if (!File.Exists(downloadedFilePath))
            {
                StartCoroutine(DownloadAndSaveZip(0));
            }
            else
            {
                updateManager.CheckForDayUpdate();
            }
        }
    }

    void InitiaLizeDirectories()
    {
        //adImage.transform.parent.gameObject.SetActive(false);
        Directory.CreateDirectory(Application.persistentDataPath + "/CP Plugin/");
        downloadDirectoryPath = Application.persistentDataPath + "/CP Plugin/";
        fileToDownLoadPath = "f7k7n3t8.stackpathcdn.com/" + bundleID + ".zip";
        downloadedFilePath = downloadDirectoryPath + bundleID + ".zip";
    }

    IEnumerator DownloadAndSaveZip(float loadTime)
    {
        yield return new WaitForSeconds(loadTime);

        Debug.Log("************* CP Plugin: Downloading");

        string URL = fileToDownLoadPath; ;// string.Format(ServerManager.SYSTEMFILES_URL, filename, ServerManager.instance.userInfo.userId.ToString());

        UnityWebRequest m_Request = UnityWebRequest.Get(URL);

        yield return m_Request.SendWebRequest();

        if (m_Request.isNetworkError)
        {
            //ServerResponseModule.instance.InternetIssuePanel.SetActive(true);
            Debug.LogError(m_Request.error);

            StartCoroutine(DownloadAndSaveZip(timeToRecheckInSecondsIfDownloadFails));

            Debug.Log("************* CP Plugin: Retrying in" + timeToRecheckInSecondsIfDownloadFails + " seconds");
        }
        else if (m_Request.isHttpError)
        {
            //ServerResponseModule.instance.ServerNotRespondingPanel.SetActive(true);
            Debug.LogError(m_Request.error);

            StartCoroutine(DownloadAndSaveZip(timeToRecheckInSecondsIfDownloadFails));

            Debug.Log("************* CP Plugin: Retrying in " + timeToRecheckInSecondsIfDownloadFails + " seconds");
        }
        else
        {
            Debug.Log("************* CP Plugin: Download Complete");

            File.WriteAllBytes(downloadedFilePath, m_Request.downloadHandler.data);

            ZipUtil.Unzip(downloadedFilePath, downloadDirectoryPath);

            downloadedSuccessfully = true;
        }
    }

    public void DeleteAndRedownload()
    {
        if (File.Exists(downloadedFilePath))
        {
            Directory.Delete(Application.persistentDataPath + "/CP Plugin/", true);
            InitiaLizeDirectories();
        }

        StartCoroutine(DownloadAndSaveZip(0));
    }
}
