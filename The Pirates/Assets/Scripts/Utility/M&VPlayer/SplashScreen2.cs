using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SplashScreen2 : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Do something that can throw an exception
            StartCoroutine(SplashGoOff());
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            SceneManager.LoadScene("MainMenu");
        }
    }
    IEnumerator SplashGoOff()
    {
        videoPlayer.Prepare();

        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
