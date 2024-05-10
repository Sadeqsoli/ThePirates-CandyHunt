using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    #region Public Variables
    public GameObject mainCreditPnl;
    public GameObject musicPnl;
    public GameObject graphicPnl;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    public void ShowMusicPanel()
    {
        mainCreditPnl.SetActive(false);
        musicPnl.SetActive(true);
    }
    public void ShowGraphicPanel()
    {
        mainCreditPnl.SetActive(false);
        graphicPnl.SetActive(true);
    }
    public void HideMusicNGraphicPanel()
    {
        mainCreditPnl.SetActive(true);
        graphicPnl.SetActive(false);
        musicPnl.SetActive(false);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
