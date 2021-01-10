using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class CPPlugin : MonoBehaviour
{
    // f7k7n3t8.stackpathcdn.com/yourpackagename.zip

    public static CPPlugin instance;

    private UpdateManager updateManager;

    [HideInInspector]
    public GameObject adButton;

    public RawImage adImage;

    private List<string> fileNames = new List<string>();

    private int random = 0;

    private bool filesLoadedAndReady = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject); 
        }

        updateManager = GetComponent<UpdateManager>();

        adButton = transform.GetChild(0).gameObject;
        adButton.SetActive(false);
    }

    private void OnEnable()
    {
        if((CPPluginInitializer.instance != null) && (CPPluginInitializer.instance.downloadedSuccessfully || File.Exists(CPPluginInitializer.instance.downloadedFilePath)))
        {
            InitializeImages();
        }
        else
        {
            Debug.LogError("CP Plugin Not Initialized");
        }
    }

    void InitializeImages()
    {
        GetFileNames();

        // Load Randomly
        if (!CPPluginInitializer.instance.loadInSequence)
        {
            random = UnityEngine.Random.Range(0, fileNames.Count);
        }
        else
        {
            random = PlayerPrefs.GetInt("adImageLoadSequence", 0);
            random++;

            if (random >= fileNames.Count)
            {
                random = 0;
            }

            //Debug.Log("random: " + random);
        }

        PlayerPrefs.SetInt("adImageLoadSequence", random);

        LoadImage();

        //adImage.transform.parent.gameObject.SetActive(true);
    }

    void GetFileNames()
    {
        Debug.Log("************* CP Plugin: Getting File Names");

        DirectoryInfo directory = new DirectoryInfo(CPPluginInitializer.instance.downloadDirectoryPath);

        FileInfo[] fileInfo = directory.GetFiles();

        for (int i = 0; i < fileInfo.Length; i++)
        {
            if (fileInfo[i] != null && (fileInfo[i].Extension == ".png" || fileInfo[i].Extension == ".jpg"))
            {
                //string tempStr = fileInfo[i].Name;
                //tempStr = tempStr.Replace(".png", "");
                //fileNames.Add(tempStr);

                fileNames.Add(fileInfo[i].Name);
                Debug.Log("****** CP Plugin: Loaded File: " + fileInfo[i].Name);
            }
        }
    }

    void LoadImage()
    {
        if (fileNames.Count <= 0)
            return;

        Debug.Log("Loading Images");

        string imagePath = CPPluginInitializer.instance.downloadDirectoryPath + "/" + fileNames[random];

        //adImage.sprite = LoadNewSprite(imagePath);
        adImage.texture = LoadTexture(imagePath);

        filesLoadedAndReady = true;

        Debug.Log("****** CP Plugin: Files Loaded And Ready: " + filesLoadedAndReady);
    }

    //public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    //{
    //    // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

    //    Texture2D SpriteTexture = LoadTexture(FilePath);
    //    Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

    //    return NewSprite;
    //}

    public Texture2D LoadTexture(string FilePath)
    {

        Texture2D Tex2D;
        byte[] FileData;

        Debug.Log("file exists: " + File.Exists(FilePath));

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    public void OpenURL()
    {
        string nameOfFileToOpen = "";
        if (fileNames[random].Contains(".png"))
        {
            nameOfFileToOpen = fileNames[random].Replace(".png", "");
        }
        else if (fileNames[random].Contains(".jpg"))
        {
            nameOfFileToOpen = fileNames[random].Replace(".jpg", "");
        }

        Application.OpenURL("https://play.google.com/store/apps/details?id=" + nameOfFileToOpen);
    }

    public void ShowAdButton()
    {
        if (filesLoadedAndReady)
        {
            adButton.SetActive(true);
        }
    }

    public void HideAdButton()
    {
        if (filesLoadedAndReady)
        {
            adButton.SetActive(false);
        }
    }
}
