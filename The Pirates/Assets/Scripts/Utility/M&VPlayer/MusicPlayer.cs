using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    #region Public Variables
    public AudioSource audioSource;
    public AudioClip[] bgMusics;
    #endregion

    #region Private Variables
    private bool onlyOnce = false;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {
        onlyOnce = false;
        int i = Random.Range(0, bgMusics.Length); 
        audioSource.PlayOneShot(bgMusics[i]);
    }//Starttttt







    void Update()
    {
        if(audioSource.isPlaying == false && onlyOnce == false)
        {
            int i = Random.Range(0, bgMusics.Length);
            audioSource.PlayOneShot(bgMusics[i]);
            onlyOnce = true;
        }
    }//Updateeeee
    #endregion
}//EndClasssss
