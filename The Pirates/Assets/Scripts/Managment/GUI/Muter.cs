using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muter : MonoBehaviour
{
    #region Public Variables
    public GameObject mute, unmute;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    public void SetMuteInGame(bool isMute)
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        if (isMute)
        {
            mute.SetActive(true);
            unmute.SetActive(false);
            
        }
        else
        {
            mute.SetActive(false);
            unmute.SetActive(true);
        }
    }
    #endregion

    #region Private Methods

    void Start()
    {

    }//Starttttt




    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss



