using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelRepo : MonoBehaviour
{
    #region Public Variables
    [Header("Game Objectes")]
    public GameObject noConnectionPnl;
    public GameObject bgConnection;
    public GameObject process;
    public GameObject arrowPnl;
    public GameObject infoPnl;
    public GameObject mPlayer;
    public LevelLoader levelLoader;

    [Header("GUI")]
    public Text stageNumber;
    public Text levelNumber;
    public Image stageNumberVis;
    public Image levelNumberVis;

    [Header("Image Characters")]
    public Image bgChar;
    public Image arrowChar;
    public Image infoChar;
    public Image connectionChar;

    [Header("Body Sprite")]
    public Sprite charBody1;
    public Sprite charBody2;
    public Sprite charBody3;
    public Sprite charBody4;
    public Sprite charBody5;
    public Sprite charBody6;
    public Sprite charBody7;
    public Sprite charBody8;
    public Sprite charBody9;
    public Sprite charBody10;
    public Sprite charBody11;
    public Sprite charBody12;

    [SerializeField] private CharacterRepo charRepo;
    [SerializeField] private LevelReached levelReached;

    [Header("Stages & Levels")]
    public GameObject[] stage;
    public Button[] levelButtons;

    
    #endregion

    #region Private Variables
    private int i = 0;
    private float fillamnt;
    private float fillamntL;
    #endregion

    #region Public Methods
    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextPage()
    {
        stage[i].SetActive(false);
        i += 1;
        if (i >= stage.Length)
        {
           i = 0;
            stageNumberVis.fillAmount = fillamnt;
        }
        else
        {
            stageNumberVis.fillAmount += fillamnt;
        }
       stageNumber.text =  (i + 1).ToString();
       stage[i].SetActive(true);
    }
    public void PrevPage()
    {
        stage[i].SetActive(false);
        i -= 1;
        if (i < 0)
        {
           i = stage.Length - 1;
           stageNumberVis.fillAmount = 1f;
        }
        else
        {
            stageNumberVis.fillAmount -= fillamnt;
        }
        stageNumber.text =  (i + 1).ToString();
        stage[i].SetActive(true);
    }
    public void Select(string levelName)
    {
        StartCoroutine(LoadAsync(levelName));
    }
    public void ShowInfo()
    {
        infoPnl.SetActive(true);
    }
    public void HideInfo()
    {
        infoPnl.SetActive(false);
    }
    public void RetryConnection()
    {
        StartCoroutine(Process());
    }
    #endregion






    #region Private Methods
    void Start()
    {
        CharRecognition();
        Connectivity();
        levelbuttons();
        SatgeGame();
        stage[i].SetActive(true);
        UpdateLevelnStage();
        Startup();
    }//Starttttt

    private void CharRecognition()
    {
        if (charRepo.Get() == 100)
        {
            bgChar.sprite = charBody1;
            arrowChar.sprite = charBody1;
            infoChar.sprite = charBody1;
            connectionChar.sprite = charBody1;
        }
        else if (charRepo.Get() == 200)
        {
            bgChar.sprite = charBody2;
            arrowChar.sprite = charBody2;
            infoChar.sprite = charBody2;
            connectionChar.sprite = charBody2;
        }
        else if (charRepo.Get() == 300)
        {
            bgChar.sprite = charBody3;
            arrowChar.sprite = charBody3;
            infoChar.sprite = charBody3;
            connectionChar.sprite = charBody3;
        }
        else if (charRepo.Get() == 400)
        {
            bgChar.sprite = charBody4;
            arrowChar.sprite = charBody4;
            infoChar.sprite = charBody4;
            connectionChar.sprite = charBody4;
        }
        else if (charRepo.Get() == 500)
        {
            bgChar.sprite = charBody5;
            arrowChar.sprite = charBody5;
            infoChar.sprite = charBody5;
            connectionChar.sprite = charBody5;
        }
        else if (charRepo.Get() == 600)
        {
            bgChar.sprite = charBody6;
            arrowChar.sprite = charBody6;
            infoChar.sprite = charBody6;
            connectionChar.sprite = charBody6;
        }
        else if (charRepo.Get() == 700)
        {
            bgChar.sprite = charBody7;
            arrowChar.sprite = charBody7;
            infoChar.sprite = charBody7;
            connectionChar.sprite = charBody7;
        }
        else if (charRepo.Get() == 800)
        {
            bgChar.sprite = charBody8;
            arrowChar.sprite = charBody8;
            infoChar.sprite = charBody8;
            connectionChar.sprite = charBody8;
        }
        else if (charRepo.Get() == 900)
        {
            bgChar.sprite = charBody9;
            arrowChar.sprite = charBody9;
            infoChar.sprite = charBody9;
            connectionChar.sprite = charBody9;
        }
        else if (charRepo.Get() == 1000)
        {
            bgChar.sprite = charBody10;
            arrowChar.sprite = charBody10;
            infoChar.sprite = charBody10;
            connectionChar.sprite = charBody10;
        }
        else if (charRepo.Get() == 1100)
        {
            bgChar.sprite = charBody11;
            arrowChar.sprite = charBody11;
            infoChar.sprite = charBody11;
            connectionChar.sprite = charBody11;
        }
        else if (charRepo.Get() == 1200)
        {
            bgChar.sprite = charBody12;
            arrowChar.sprite = charBody12;
            infoChar.sprite = charBody12;
            connectionChar.sprite = charBody12;
        }
    }

    private IEnumerator LoadAsync(string levelName)
    {
        AsyncOperation opration = SceneManager.LoadSceneAsync(levelName);
        levelLoader.loadingScreen[i].SetActive(true);
        while (opration.isDone == false)
        {
            float progress = Mathf.Clamp01(opration.progress / 0.9f);
            levelLoader.slider[i].value = progress;
            levelLoader.progressText[i].text = (progress * 100f).ToString("f0") + "%";
            yield return null;
        }
    }


    private void Startup()
    {

        if (PlayerPrefs2.GetBool("AlreadyShownLevel"))
        {
            arrowPnl.SetActive(false);
            // not the first run, so skip the movie
        }
        else
        {
            // first run, set the indicator so we don't show the movie again later
            PlayerPrefs2.SetBool("AlreadyShownLevel", true);

            // show the movie
            StartCoroutine(ArrowGoOff());
        }
    }
    IEnumerator ArrowGoOff()
    {
        arrowPnl.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        arrowPnl.SetActive(false);
    }

    private void Connectivity()
    {
        noConnectionPnl.SetActive(false);
        StartCoroutine(CheckConnectivity((isConnected) =>
        {
            if (isConnected)
            {
                Debug.Log("Connected");
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            else
            {
                noConnectionPnl.SetActive(true);
                mPlayer.SetActive(false);
                Debug.Log("Not Connected");
            }

        }));
    }
    IEnumerator CheckConnectivity(Action<bool> action)
    {

        WWW www = new WWW("http://sadeqsoli.ir");
        yield return www;
        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }
    IEnumerator Process()
    {
        bgConnection.SetActive(false);
        process.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    private void levelbuttons()
    {
         int ReachedLevel = levelReached.Get();
         for (int i = 0; i < levelButtons.Length; i++)
         {
             if (i + 1 > ReachedLevel)
             {

             levelButtons[i].interactable = false;
   
             }
         }
    }
    private void UpdateLevelnStage()
    {
        fillamnt = Mathf.Clamp01(1f / stage.Length);
        fillamntL = Mathf.Clamp01(1f / levelButtons.Length);
        levelNumberVis.fillAmount = fillamntL * levelReached.Get();
        levelNumber.text = levelReached.Get().ToString();
        
    }
    private void SatgeGame()
    {
        
        if (levelReached.Get() < 25)
        {
            i = 0;
            stageNumberVis.fillAmount = 0.083f;
            stageNumber.text =  (i + 1).ToString();
        }
        if (levelReached.Get() > 24 && levelReached.Get() < 49)
        {
            i = 1;
            stageNumberVis.fillAmount = fillamnt * 2;
            stageNumber.text =  (i + 1).ToString();
        }
        if (levelReached.Get() > 48 && levelReached.Get() < 73)
        {
            i = 2;
            stageNumberVis.fillAmount = fillamnt * 3;
            stageNumber.text =  (i + 1).ToString();
        }
        if (levelReached.Get() > 72 && levelReached.Get() < 97)
        {
            i = 3;
            stageNumberVis.fillAmount = fillamnt * 4;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 96 && levelReached.Get() < 121)
        {
            i = 4;
            stageNumberVis.fillAmount = fillamnt * 5;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 120 && levelReached.Get() < 145)
        {
            i = 5;
            stageNumberVis.fillAmount = fillamnt * 6;
            stageNumber.text =  (i + 1).ToString();
        }
        if (levelReached.Get() > 144 && levelReached.Get() < 169)
        {
            i = 6;
            stageNumberVis.fillAmount = fillamnt * 7;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 168 && levelReached.Get() < 193)
        {
            i = 7;
            stageNumberVis.fillAmount = fillamnt * 8;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 192 && levelReached.Get() < 217)
        {
            i = 8;
            stageNumberVis.fillAmount = fillamnt * 9;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 216 && levelReached.Get() < 241)
        {
            i = 9;
            stageNumberVis.fillAmount = fillamnt * 10;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 240 && levelReached.Get() < 265)
        {
            i = 10;
            stageNumberVis.fillAmount = fillamnt * 11;
            stageNumber.text = (i + 1).ToString();
        }
        if (levelReached.Get() > 264)
        {
            i = 11;
            stageNumberVis.fillAmount = 1f; ;
            stageNumber.text =  (i + 1).ToString();
        }

    }




    void Update()
    {

    }//Updateeeee
  
    #endregion
}//EndClasssss
