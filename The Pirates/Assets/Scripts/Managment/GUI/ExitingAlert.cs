using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitingAlert : MonoBehaviour
{
    #region Public Variables
    public GameObject buttons;
    public GameObject exitingPanel;
    public Button btnExitApplication, yesButton, noButton;

    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    public void ShowExitingPanel()
    {
        if (!exitingPanel.activeSelf)
        {
            buttons.SetActive(false);
            exitingPanel.SetActive(true);
        }
        Button btnYes = yesButton.GetComponent<Button>();
        btnYes.onClick.AddListener(HitYesButton);

        Button btnNo = noButton.GetComponent<Button>();
        btnNo.onClick.AddListener(HitNoButton);
    }

    public void HitYesButton()
    {
        Application.Quit(0);
    }

    public void HitNoButton()
    {
        buttons.SetActive(true);
        exitingPanel.SetActive(false);
    }

    
    #endregion

    #region Private Methods
    void Start()
    {

    }//Starttttt





    void Update()
    {
        Button btnExit = btnExitApplication.GetComponent<Button>();
        btnExit.onClick.AddListener(ShowExitingPanel);
    }//Updateeeee

    #endregion
}//EndClasssss
