using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinGamOverManager : MonoBehaviour
{
    #region Public Variables
    [Header("GUI")]
    public Text txtWinMsg;
    public Text txtWinMsg1;
    public Text txtScore;
    public Text txtrocks;
    public Text txtenemyship;
    public Text txtCoins;

    [Header("Game Objects")]
    public GameObject btnReplay;
    public GameObject btnNextLevel;
    public GameObject confettiWin;
    public GameObject boneLoose;
    public AudioClip winClip;
    public AudioClip gameoverClip;
    public AudioClip btnReplayClip;
    public AudioClip btnMainMenuClip;
    public AudioClip btnNextLevelClip;
    #endregion

    #region Private Variables
    [SerializeField] private AudioSource audioSource;
    private string winMessage = "Victory!"; 
    private string gameOverMessage = "Game Over"; 
    #endregion

    #region Public Methods
    public void Init(bool isWin, int score, int rocks, int enemyship, int coins)
    {
        SetWinMsg(isWin);
        SetButtons(isWin);
        txtScore.text = score.ToString();
        txtrocks.text = rocks.ToString();
        txtenemyship.text = enemyship.ToString();
        txtCoins.text = coins.ToString(); 
    }

    public void ReplayGame()
    {
        audioSource.PlayOneShot(btnReplayClip);
        Invoke("ReplayGameAfterSound", btnReplayClip.length);
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(btnMainMenuClip);
        Invoke("MainMenuAfterSound", btnMainMenuClip.length);
    }
    #endregion

    #region Private Methods
    void Start()
    {


    }//Starttttt


    private void SetButtons(bool isWin)
    {
        if (isWin)
        {
            confettiWin.SetActive(true);
            btnReplay.SetActive(false);
            btnNextLevel.SetActive(true);
        }
        else
        {
            boneLoose.SetActive(true);
            btnReplay.SetActive(true);
            btnNextLevel.SetActive(false);


        }
    }
    private void SetWinMsg(bool isWin)
    {
        if (isWin == true)
        {
            txtWinMsg.text = winMessage;
            txtWinMsg1.text = winMessage;
            audioSource.PlayOneShot(winClip);
        }
        else
        {
            txtWinMsg.text = gameOverMessage;
            txtWinMsg1.text = gameOverMessage;
            audioSource.PlayOneShot(gameoverClip);
        }
    }

    private void ReplayGameAfterSound()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void MainMenuAfterSound()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

   
    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
