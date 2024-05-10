using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;

public class GameController : MonoBehaviour
{
    #region Public Variables
    public int Score { get { return score; }}
    public int bullet;

    [Header("Scripts")]
    public HUDTopLeftManager hudTopLeftManager;
    public HUDBulletManager hudBulletManager;
    public JoyStick joyStick;
    public WinGamOverManager winGameOverManager;

    #region Character Manager-------------------------------------
    [Header("Image Characters")]
    public Image winLoseChar;
    public Image pauseChar;
    public Image missionChar;
    public Image bonusChar1;
    public Image bonusChar2;
    public Image anotherChanceChar;
    public Image areYouSureChar;
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
    #endregion


    [Header("Game Objects")]
    public GameObject pauseButton;
    public GameObject spawners;
    public GameObject bonus;
    public GameObject arrowPnl;
    public GameObject noConnectionPnl;
    public GameObject bgConnection;
    public GameObject process;
    public GameObject mPlayer;
    public GameObject anotherChancePnl;
    public GameObject areYouSurePnl;
    public Text txtKeyPop;
    public Text txtHaveKey;
    public Text txtHaveKey1;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;
    #endregion

    #region Private Variables
    [SerializeField] private CoinRepository coinRepo;
    [SerializeField] private ScoreRepository scoreRepo;
    [SerializeField] private ShipRepository shipRepo;
    [SerializeField] private KelidRepo kelidRepo;
    [SerializeField] private CharacterRepo charRepo;
    [SerializeField] private ObjectsRepo objectsRepo;
    [SerializeField] private GameLog gameLog;
    [SerializeField] private LevelReached levelReached;
    [SerializeField] private SaveData saveData;
    [SerializeField] private RetriveData retriveData;

    private Scene thisScene;

    private int v;
    private int keyPopNumb;
    private int score = 0;
    private int level;
    private int coins = 0 ;
    private int kelid = 0 ;
    private int candy = 0 ;
    private int magicCandy = 0 ;
    private int junkcandy = 0;
    private int destroyed = 0;
    private int enemyShip = 0;
    private int childShip = 0;
    private int bulletOutOfBounds = 0;
    private int EbulletOutOfBounds = 0;

    private ShipStruct shipstruct;
    private ShipController shipController;
    private EnemyShipController enemy;
    private EnemyShipCrosser enemy1;
    private MegaEnemyShipController enemy2;
    private RainCoinController rainCoin;
    #endregion

    #region Public Methods
    public void AnotherChanceToWin()
    {
        Time.timeScale = 0;
        txtKeyPop.text = keyPopNumb.ToString();
        anotherChancePnl.SetActive(true);
    }

    public void ContinueKeyPop()
    {
        if (!kelidRepo.Pop(keyPopNumb))
        {
            txtHaveKey.text = "You've Got " + kelidRepo.Get().ToString() + " Key left " +
                                "and not enough to continue. Maybe another time";
        }
        else
        {
            txtHaveKey1.text = "You've Got " + kelidRepo.Get().ToString() + " Key left ";
            areYouSurePnl.SetActive(true);
        }
    }
    public void ContinueKeyPopValidation()
    {
        kelidRepo.Pop(keyPopNumb);
        anotherChancePnl.SetActive(false);
        Time.timeScale = 1;
    }
    public void HitNoKeyPopValidation()
    {
        areYouSurePnl.SetActive(false);
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        anotherChancePnl.SetActive(false);
        GameOver();
    }
    public void ContinueVideo()
    {

    }

    public void Win()
    {

        if (winGameOverManager.gameObject.activeInHierarchy == false)
        {

            PushRepo();
            KillEverything();
            AnalyticsEvent.LevelUp(thisScene.buildIndex);
            winGameOverManager.gameObject.SetActive(true);

            winGameOverManager.Init(true, score, candy, destroyed, coins);
            saveData.CallSaveData();
            retriveData.CallRetrive();
        }
    }
    public void GameOver()
    {

        PushRepo();
        KillEverything();
        AnalyticsEvent.LevelFail(thisScene.buildIndex);
        winGameOverManager.gameObject.SetActive(true);

        winGameOverManager.Init(false,score, candy, destroyed , coins);
        saveData.CallSaveData();
        retriveData.CallRetrive();
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }



    //public int GetPowerPercent()
    //{
    //    return enemy.GetPowerPercent();
    //}
    public int GetHealthPercent()
    {
        return shipController.GetHealthPercent();
    }
    public void AddScore(int s)
    {
        if(s > 0)
        {
            score += s;
            hudTopLeftManager.SetTextScore(score); 
        }
    }
    public bool HasBullet()
    {
        if(bullet > 0)
        {
            return true;
        }

            audioSource.PlayOneShot(audioClip);
            return false;
    }
    public void PopBullet()
    {
        bullet -= 1;
        hudBulletManager.SetBullet(bullet);
    }
    public void AddCoins()
    {
        coins += 1;
        gameLog.AddCoins();
    }
    public void AddPowerups()
    {
        magicCandy++;
        gameLog.AddPowerups();
    }
    public void AddCandy()
    {
        candy += 1;
        DBManager.col_candy++;
        gameLog.AddCandy();
        
    }


    public void GameObjectDeactivator(GameObject ob)
    {
        if (ob.CompareTag("littleClusterBall"))
        {
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("e_littleClusterBall"))
        {
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("simpleBal") || ob.CompareTag("clusterBall") || ob.CompareTag("seaMine") ||
            ob.CompareTag("chaseBall") || ob.CompareTag("crazyBall") || ob.CompareTag("fireBall"))
        {
            bulletOutOfBounds += 1;
            gameLog.AddBulletOutOfBounds();
            ob.gameObject.SetActive(false);
        }
        if (ob.CompareTag("e_simpleBall") || ob.CompareTag("e_clusterBall") || ob.CompareTag("e_seaMine") ||
            ob.CompareTag("e_chaseBall") || ob.CompareTag("e_crazyBall") || ob.CompareTag("e_fireBall"))
        {
            EbulletOutOfBounds += 1;
            gameLog.AddEBulletOutOfBounds();
            ob.gameObject.SetActive(false);
        }
        //Destroy(ob.gameObject);
        
    }
    public void AddCrosseedItems(GameObject ob)
    {
        if (ob.CompareTag("coin"))
        {
            gameLog.AddCrossedCoins();
            DBManager.crossed_coins++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("raincoin"))
        {
            gameLog.AddCrossedCoins();
            DBManager.crossed_coins++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("candy"))
        {
            gameLog.AddCrossedCandy();
            DBManager.crossed_candy++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("powerups"))
        {
            gameLog.AddCrossedPowerups();
            DBManager.crossed_powerups++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("junkcandy"))
        {
            gameLog.AddJunkCandyCrossed();
            DBManager.crossed_junkcandy++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("Enemy"))
        {
            gameLog.AddMotherEnemyShipCrossed();
            DBManager.crossed_enemyships++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("megaEnemy"))
        {
            gameLog.AddMotherEnemyShipCrossed();
            DBManager.crossed_enemyships++;
            Destroy(ob.gameObject);
        }
        if (ob.CompareTag("child_ship"))
        {
            gameLog.AddUnitEnemyShipCrossed();
            DBManager.crossed_childships++;
            Destroy(ob.gameObject);
        }
        ob.gameObject.SetActive(false);
    }
    public void AddDestroyedItems(string tag)
    {
        if (tag == "junkcandy")
        {
            gameLog.AddDestroyed();
            gameLog.AddJunkCandyDestroyed();
            junkcandy++;
        }
        if (tag == "Enemy")
        {
            gameLog.AddDestroyed();
            gameLog.AddMotherEnemyShipDistroyed();
            enemyShip++;
        }
        if (tag == "megaEnemy")
        {
            gameLog.AddDestroyed();
            gameLog.AddMotherEnemyShipDistroyed();
            enemyShip++;
        }
        if (tag == "child_ship")
        {
            gameLog.AddDestroyed();
            gameLog.AddUnitEnemyShipDistroyed();
            childShip++;
        }
        destroyed++;

    }


    public void WinBonusGoOff()
    {
        bonus.SetActive(false);
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
        AttachingShip();
        BulletNKeyPopNumber();
        StartVariables();
        OffObjects();
        Analytics();
    }//Starttttt

    private void OnApplicationQuit()
    {
        PushRepo();
        saveData.CallSaveData();
        AnalyticsEvent.LevelQuit(thisScene.buildIndex);
    }
    private void CharRecognition()
    {
        if (charRepo.Get() == 100)
        {
            winLoseChar.sprite = charBody1;
            pauseChar.sprite = charBody1;
            missionChar.sprite = charBody1;
            bonusChar1.sprite = charBody1;
            bonusChar2.sprite = charBody1;
            connectionChar.sprite = charBody1;
            anotherChanceChar.sprite = charBody1;
            areYouSureChar.sprite = charBody1;
        }
        else if (charRepo.Get() == 200)
        {
            winLoseChar.sprite = charBody2;
            pauseChar.sprite = charBody2;
            missionChar.sprite = charBody2;
            bonusChar1.sprite = charBody2;
            bonusChar2.sprite = charBody2;
            connectionChar.sprite = charBody2;
            anotherChanceChar.sprite = charBody2;
            areYouSureChar.sprite = charBody2;
        }
        else if (charRepo.Get() == 300)
        {
            winLoseChar.sprite = charBody3;
            pauseChar.sprite = charBody3;
            missionChar.sprite = charBody3;
            bonusChar1.sprite = charBody3;
            bonusChar2.sprite = charBody3;
            connectionChar.sprite = charBody3;
            anotherChanceChar.sprite = charBody3;
            areYouSureChar.sprite = charBody3;
        }
        else if (charRepo.Get() == 400)
        {
            winLoseChar.sprite = charBody4;
            pauseChar.sprite = charBody4;
            missionChar.sprite = charBody4;
            bonusChar1.sprite = charBody4;
            bonusChar2.sprite = charBody4;
            connectionChar.sprite = charBody4;
            anotherChanceChar.sprite = charBody4;
            areYouSureChar.sprite = charBody4;
        }
        else if (charRepo.Get() == 500)
        {
            winLoseChar.sprite = charBody5;
            pauseChar.sprite = charBody5;
            missionChar.sprite = charBody5;
            bonusChar1.sprite = charBody5;
            bonusChar2.sprite = charBody5;
            connectionChar.sprite = charBody5;
            anotherChanceChar.sprite = charBody5;
            areYouSureChar.sprite = charBody5;
        }
        else if (charRepo.Get() == 600)
        {
            winLoseChar.sprite = charBody6;
            pauseChar.sprite = charBody6;
            missionChar.sprite = charBody6;
            bonusChar1.sprite = charBody6;
            bonusChar2.sprite = charBody6;
            connectionChar.sprite = charBody6;
            anotherChanceChar.sprite = charBody6;
            areYouSureChar.sprite = charBody6;
        }
        else if (charRepo.Get() == 700)
        {
            winLoseChar.sprite = charBody7;
            pauseChar.sprite = charBody7;
            missionChar.sprite = charBody7;
            bonusChar1.sprite = charBody7;
            bonusChar2.sprite = charBody7;
            connectionChar.sprite = charBody7;
            anotherChanceChar.sprite = charBody7;
            areYouSureChar.sprite = charBody7;
        }
        else if (charRepo.Get() == 800)
        {
            winLoseChar.sprite = charBody8;
            pauseChar.sprite = charBody8;
            missionChar.sprite = charBody8;
            bonusChar1.sprite = charBody8;
            bonusChar2.sprite = charBody8;
            connectionChar.sprite = charBody8;
            anotherChanceChar.sprite = charBody8;
            areYouSureChar.sprite = charBody8;
        }
        else if (charRepo.Get() == 900)
        {
            winLoseChar.sprite = charBody9;
            pauseChar.sprite = charBody9;
            missionChar.sprite = charBody9;
            bonusChar1.sprite = charBody9;
            bonusChar2.sprite = charBody9;
            connectionChar.sprite = charBody9;
            anotherChanceChar.sprite = charBody9;
            areYouSureChar.sprite = charBody9;
        }
        else if (charRepo.Get() == 1000)
        {
            winLoseChar.sprite = charBody10;
            pauseChar.sprite = charBody10;
            missionChar.sprite = charBody10;
            bonusChar1.sprite = charBody10;
            bonusChar2.sprite = charBody10;
            connectionChar.sprite = charBody10;
            anotherChanceChar.sprite = charBody10;
            areYouSureChar.sprite = charBody10;
        }
        else if (charRepo.Get() == 1100)
        {
            winLoseChar.sprite = charBody11;
            pauseChar.sprite = charBody11;
            missionChar.sprite = charBody11;
            bonusChar1.sprite = charBody11;
            bonusChar2.sprite = charBody11;
            connectionChar.sprite = charBody11;
            anotherChanceChar.sprite = charBody11;
            areYouSureChar.sprite = charBody11;
        }
        else if (charRepo.Get() == 1200)
        {
            winLoseChar.sprite = charBody12;
            pauseChar.sprite = charBody12;
            missionChar.sprite = charBody12;
            bonusChar1.sprite = charBody12;
            bonusChar2.sprite = charBody12;
            connectionChar.sprite = charBody12;
            anotherChanceChar.sprite = charBody12;
            areYouSureChar.sprite = charBody12;
        }
    }

    private void Analytics()
    {
        AnalyticsEvent.GameStart();
        thisScene = SceneManager.GetActiveScene();
    }
    private void AttachingShip()
    {
        shipstruct = shipRepo.GetCurrentShip();
        GameObject shipObject = (GameObject)Instantiate(shipstruct.Ship, new Vector3(0, -4, 0), Quaternion.identity);
        shipController = shipObject.GetComponent<ShipController>();
        shipController.init(shipstruct.speed, shipstruct.fireRate, shipstruct.health);
        joyStick.Attach(shipController);
    }
    private void StartVariables()
    {

        score = 0;
        coins = 0;
        kelid = 0;
        destroyed = 0;
        enemyShip = 0;
        childShip = 0;
        candy = 0;
        magicCandy = 0;
        junkcandy = 0;
        hudTopLeftManager.SetTextScore(score);
        hudBulletManager.SetBullet(bullet);
    }
    private void BulletNKeyPopNumber()
    {
        if (levelReached.Get() >= 1 && levelReached.Get() < 13)
        {
            keyPopNumb = 1;
            bullet = 100;
        }
        else if (levelReached.Get() > 12 && levelReached.Get() < 25)
        {
            keyPopNumb = 2;
            bullet = 100;
        }
        else if (levelReached.Get() > 24 && levelReached.Get() < 37)
        {
            keyPopNumb = 4;
            bullet = 125;
        }
        else if (levelReached.Get() > 36 && levelReached.Get() < 49)
        {
            keyPopNumb = 5;
            bullet = 150;
        }
        else if (levelReached.Get() > 48 && levelReached.Get() < 61)
        {
            keyPopNumb = 7;
            bullet = 200;
        }
        else if (levelReached.Get() > 60 && levelReached.Get() < 73)
        {
            keyPopNumb = 8;
            bullet = 200;
        }
        else if (levelReached.Get() > 72 && levelReached.Get() < 97)
        {
            keyPopNumb = 10;
            bullet = 250;
        }
        else if (levelReached.Get() > 96 && levelReached.Get() < 121)
        {
            keyPopNumb = 12;
            bullet = 250;
        }
        else if (levelReached.Get() > 120 && levelReached.Get() < 145)
        {
            keyPopNumb = 15;
            bullet = 300;
        }
        else if (levelReached.Get() > 144 && levelReached.Get() < 169)
        {
            keyPopNumb = 20;
            bullet = 300;
        }
        else if (levelReached.Get() > 168 && levelReached.Get() < 193)
        {
            keyPopNumb = 25;
            bullet = 300;
        }
        else if (levelReached.Get() > 192 && levelReached.Get() < 217)
        {
            keyPopNumb = 30;
            bullet = 300;
        }
        else if (levelReached.Get() > 216 && levelReached.Get() < 241)
        {
            keyPopNumb = 40;
            bullet = 350;
        }
        else if (levelReached.Get() > 240 && levelReached.Get() < 253)
        {
            keyPopNumb = 50;
            bullet = 350;
        }
        else if (levelReached.Get() > 252 && levelReached.Get() < 265)
        {
            keyPopNumb = 60;
            bullet = 400;
        }
        else if (levelReached.Get() > 264 && levelReached.Get() < 277)
        {
            keyPopNumb = 80;
            bullet = 450;
        }
        else if (levelReached.Get() > 276 && levelReached.Get() < 289)
        {
            keyPopNumb = 100;
            bullet = 500;
        }
    }
    private void OffObjects()
    {
        winGameOverManager.gameObject.SetActive(false);
        anotherChancePnl.SetActive(false);
        bonus.SetActive(false);
        areYouSurePnl.SetActive(false);
    }


    private void KillEverything()
    {
        spawners.SetActive(false);
        shipController.gameObject.SetActive(false);
        joyStick.Dettach();
        hudBulletManager.Deactive();
        hudTopLeftManager.Deactive();
        pauseButton.SetActive(false);
        mPlayer.SetActive(false);
        enemy = GameObject.FindObjectOfType<EnemyShipController>();
        enemy1 = GameObject.FindObjectOfType<EnemyShipCrosser>();
        enemy2 = GameObject.FindObjectOfType<MegaEnemyShipController>();
        rainCoin = GameObject.FindObjectOfType<RainCoinController>();
        Destroy(enemy);
        Destroy(enemy1);
        Destroy(enemy2);
        Destroy(rainCoin);
    }
    private void PushRepo()
    {
        scoreRepo.PushScores(score);
        scoreRepo.Push(score);
        coinRepo.Push(coins);
        kelidRepo.Push(kelid);
        objectsRepo.PushDestroyed(destroyed);
        objectsRepo.PushEnemy(enemyShip);
        objectsRepo.PushChild(childShip);
        objectsRepo.PushCandy(candy);
        objectsRepo.PushMagic(magicCandy);
        objectsRepo.PushJunk(junkcandy);
    }


    private void Startup()
    {
        if (PlayerPrefs2.GetBool("AlreadyShownGame"))
        {
            Time.timeScale = 1;
            arrowPnl.SetActive(false);
            // not the first run, so skip the movie
        }
        else
        {
            // first run, set the indicator so we don't show the movie again later
            PlayerPrefs2.SetBool("AlreadyShownGame", true);
            // show the movie
            Time.timeScale = 0;
            StartCoroutine(ArrowGoOff());
        }
    }
    IEnumerator ArrowGoOff()
    {
        arrowPnl.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1;
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
                Time.timeScale = 0;
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
                retriveData.CallRetrive();
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


    



    void Update()
    {

        
    }//Updateeeee

    #endregion
}//EndClasssss
