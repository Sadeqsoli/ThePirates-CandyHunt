using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedMenuController : MonoBehaviour
{
    #region Public Variables
    public GameObject whenHitPause;
    public GameObject settingPanel;
    public Button btnPause,resume, replay, options;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    public void ShowPausePanel()
    {
        if (!whenHitPause.activeSelf)
        {
            whenHitPause.SetActive(true);
            Time.timeScale = 0;
        }
        Button btn_C = resume.GetComponent<Button>();
        btn_C.onClick.AddListener(ResumeGame);

        //Button btn_Replay = replay.GetComponent<Button>();
        //btn_Replay.onClick.AddListener(ReplayGame);

        Button btn_O = options.GetComponent<Button>();
        btn_O.onClick.AddListener(ShowSettingsPanel);
    }

    public void ResumeGame()
    {
        //audioSource.PlayOneShot(btnResumeSound);
        //Invoke("ResumeGameAfterSound", btnResumeSound.length);
        whenHitPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReplayGame()
    {
        //audioSource.PlayOneShot(btnReplaySound);
        //Invoke("ReplayGameAfterSound", btnReplaySound.length);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowSettingsPanel()
    {
        //audioSource.PlayOneShot(btnOptionSound);
        //Invoke("GoToOptionPanelAfterSound", btnOptionSound.length);
        //Time.timeScale = 0;
        whenHitPause.SetActive(false);
        settingPanel.SetActive(true);
    }
    public void HideSettingPanel()
    {
        whenHitPause.SetActive(true);
        settingPanel.SetActive(false);
    }

    #endregion

    #region Private Methods

    void Start()
    {

    }//Starttttt



     //private void ResumeGameAfterSound()
     //{


    //}
    //private void ReplayGameAfterSound()
    //{



    //}

    //private void GoToOptionPanelAfterSound()
    //{



    //}
    //private void QuitGameAfterSound()
    //{


    //}



    void Update()
    {
        Button btn_Pause = btnPause.GetComponent<Button>();
        btn_Pause.onClick.AddListener(ShowPausePanel);
    }//Updateeeee

    #endregion
}//EndClasssss
