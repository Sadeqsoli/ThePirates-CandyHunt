using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Level0 : MonoBehaviour
{
    #region Public Variables
    public GameObject pnlMissionLevel1;
    public GameObject bonus;
    public Text timerText;
    public Text timerText1;
    #endregion

    #region Private Variables
    private float currentTime = 15.99f;
    private const int levelUnlocked = 1;

    private bool OnlyOnec = false;
    private bool isFinished = false;

    [Header("Scripts")]
    [SerializeField] private GameController gameController;
    [SerializeField] private GameLog gameLog;
    [SerializeField] private SaveData saveData;
    [SerializeField] private KelidRepo kelidRepo;
    [SerializeField] private ScoreRepository scoreRepo;
    [SerializeField] private CoinRepository coinRepo;
    [SerializeField] private LevelReached levelReached;


    [Header("GUI")]
    [SerializeField] private Image victoryCup;
    [SerializeField] private Image victoryCup1;
   
    #endregion

    #region Public Methods
    public void TakeMissoin()
    {
        Time.timeScale = 1;
        pnlMissionLevel1.SetActive(false);
    }


    #endregion

    #region Private Methods
    void Awake()
    {
        pnlMissionLevel1.SetActive(true);
        victoryCup.gameObject.SetActive(false);
        bonus.SetActive(false);
        isFinished = false;
    }//Awakeeeee



    private void Timer()
    {
        if (!isFinished)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("f0");
            timerText1.text = currentTime.ToString("f0");
        }
        if (currentTime <= 3)
        {
            timerText1.color = Color.green;

        }
        if (currentTime <= 0)
        {
            isFinished = true;
            victoryCup.gameObject.SetActive(true);
            victoryCup1.gameObject.SetActive(false);
            currentTime = 0;
        }

    }
   

    private void RewardLevel()
    {
        bonus.SetActive(true);
        kelidRepo.Push(1);
        scoreRepo.PushScores(100);
        coinRepo.Push(50);
    }
    private void OpenNextLevel()
    {
        if (levelReached.Get() < levelUnlocked)
        {
            RewardLevel();
            levelReached.Push(levelUnlocked);
            saveData.CallSaveData();
        }
    }
    private void WinPanelPopup()
    {
        OpenNextLevel();
        gameController.Win();
        AnalyticsEvent.LevelComplete("level0");
    }
    

    void Update()
    {
        Timer();
        if (gameLog.motherEnemyShipDistroyed >= 1 && isFinished == true && !OnlyOnec)
        {
            WinPanelPopup();
            OnlyOnec = true;
        }

    }//Updateeeee

    #endregion


}//EndClasssss
