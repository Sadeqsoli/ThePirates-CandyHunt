using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AchievementsController : MonoBehaviour
{
    #region Public Variables
    [Header("GUI")]
    public Text txtScore;
    public Text txtDestroyed;
    public Text txtCoinCollect;
    public Text txtkeys;
    public Text txtChildEnemyShip;
    public Text txtHighestScore;
    public Text txtPowerUps;
    public Text txtCandyCollect;
    public Text txtEnemyShip;
    public Text txtJunkCandy;

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

    [Header("Game Objectes")]
    public GameObject arrowPnl;
    public GameObject infoPnl;
    public GameObject noConnectionPnl;
    public GameObject bgConnection;
    public GameObject process;
    public GameObject mPlayer;
    #endregion

    #region Private Variables
    [Header("Repositories")]
    [SerializeField] private ScoreRepository scoreRepo;
    [SerializeField] private CoinRepository coinRepo;
    [SerializeField] private KelidRepo kelidRepo;
    [SerializeField] private CharacterRepo charRepo;
    [SerializeField] private ObjectsRepo objectsRepo;

    [Header("Scripts")]
    [SerializeField] private GameLog gameLog;
    [SerializeField] private RetriveData retriveData;
    #endregion

    #region Public Methods
    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
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
        PlayerAchievements();
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

    IEnumerator ArrowGoOff()
    {
        arrowPnl.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        arrowPnl.SetActive(false);
    }
    private void Startup()
    {

        if (PlayerPrefs2.GetBool("AlreadyShownAchive"))
        {
            arrowPnl.SetActive(false);
            // not the first run, so skip the movie
        }
        else
        {
            // first run, set the indicator so we don't show the movie again later
            PlayerPrefs2.SetBool("AlreadyShownAchive", true);

            // show the movie
            StartCoroutine(ArrowGoOff());
        }
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



    private void PlayerAchievements()
    {
        retriveData.CallRetrive();

        txtScore.text = scoreRepo.Get().ToString("#,#");
        txtDestroyed.text = objectsRepo.GetDestroyed().ToString("#,#");
        txtCoinCollect.text = coinRepo.Get().ToString("#,#");
        txtkeys.text = kelidRepo.Get().ToString("#,#");
        txtChildEnemyShip.text = objectsRepo.GetChild().ToString("#,#");
        txtHighestScore.text = scoreRepo.GetHighScore().ToString("#,#");
        txtPowerUps.text = objectsRepo.GetMagic().ToString("#,#");
        txtCandyCollect.text = objectsRepo.GetCandy().ToString("#,#");
        txtEnemyShip.text = objectsRepo.GetEnemy().ToString("#,#");
        txtJunkCandy.text = objectsRepo.GetJunk().ToString("#,#");
    }





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
