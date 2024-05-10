using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartupMovieManager : MonoBehaviour
{
    #region Public Variables
    public GameObject video;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
    {
        video.SetActive(false);
        if (PlayerPrefs2.GetBool("MovieAlreadyShown"))
        {
            // not the first run, so skip the movie
             
        }
        else
        {
            // first run, set the indicator so we don't show the movie again later
            PlayerPrefs2.SetBool("MovieAlreadyShown", true);
            // show the movie
            //Handheld.PlayFullScreenMovie("Welcome.mp4");
            video.SetActive(true);
        }
    }//Starttttt








    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
