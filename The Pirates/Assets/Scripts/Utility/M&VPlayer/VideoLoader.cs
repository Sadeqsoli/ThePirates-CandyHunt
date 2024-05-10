using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VideoLoader : MonoBehaviour
{
    #region Public Variables
    public string vUrl = "";
    public bool mClearCach = false;


    #endregion

    #region Private Variables
    private VideoPlayer vPlayer = null;
    private AssetBundle mBundle = null;
    #endregion

    #region Public Methods
    public void StartVideo()
    {
        StartCoroutine(DownloadNPlay());
    }
    #endregion

    #region Private Methods

    void Awake()
    {
        vPlayer = GetComponent<VideoPlayer>();
        Caching.compressionEnabled = false;

        if (mClearCach)
        {
            Caching.ClearCache();
        }
    }//Awakeeee


    private IEnumerator DownloadNPlay()
    {
        yield return GetBundle();
        if (!mBundle)
        {
            Debug.Log("Failed to load!");
            yield break;
        }
        VideoClip vClip = mBundle.LoadAsset<VideoClip>("Splash01");
        vPlayer.clip = vClip;
        vPlayer.Play();
    }
    private IEnumerator GetBundle()
    {
        WWW www = WWW.LoadFromCacheOrDownload(vUrl, 0);

        while (!www.isDone)
        {
            Debug.Log(www.progress);
            yield return null;
        }
        if (www.error == null)
        {
            mBundle = www.assetBundle;
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log(www.error);
        }
    }





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
