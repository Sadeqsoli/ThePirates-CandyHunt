using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ShipShopController : MonoBehaviour
{
    #region Public Variables
    [Header("GUI")]
    public InputField scoreField;
    public Text shipsNumber;
    public Text txtCoins;
    public Text txtCoins1;
    public Text txtscores;
    public Text txtscores1;
    public Text txtKeys;
    public Text txtKeys1;
    public Text txtModel;
    public Text txtHealth;
    public Text txtSpeed;
    public Text txtGunType;
    public Text txtFireRate;
    public Text txtGunNumb;
    public Text txtAmoPower;
    public Text txtPrice;
    public Text txtStagenumber;
    public Image shipsNumberVis;
    public Image shipSprite;
    public Image shipSprite1;
    public Image ballSprite;

    [Header("Game Objectes")]
    public GameObject coinsNumb;
    public GameObject coinsNumb1;
    public GameObject scoresNumb1;
    public GameObject scoresNumb;
    public GameObject btnSelect;
    public GameObject btnBuyShip;
    public GameObject btnAddCoins;
    public GameObject fireballs;
    public GameObject coinShopPnl;
    public GameObject selectShipValidationPnl;
    public GameObject buyShipValidationPnl;
    public GameObject selectedShipImg;
    public GameObject buyShipImg;
    public GameObject arrowPnl;
    public GameObject infoPnl;
    public GameObject noConnectionPnl;
    public GameObject bgConnection;
    public GameObject process;
    public GameObject mPlayer;
    public GameObject lockPanel;
    public GameObject keyShopPnl;
    public GameObject warningPnl;
    public GameObject warningPnl1;
    public GameObject warningPnl2;
    public GameObject successPnl;

    [Header("Image Characters")]
    public Image bgChar;
    public Image arrowChar;
    public Image infoChar;
    public Image connectionChar;
    public Image selectedShipChar;
    public Image buyShipChar;
    public Image coinShopChar;
    public Image keyShopChar;

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

    #region Private Variables
    [Header("Repositories")]
    [SerializeField] private ShipRepository shipRepo;
    [SerializeField] private CoinRepository coinRepo;
    [SerializeField] private KelidRepo kelidRepo;
    [SerializeField] private ScoreRepository scoreRepo;
    [SerializeField] private CharacterRepo charRepo;
    [SerializeField] private LevelReached levelReached;
    [SerializeField] private ObjectsRepo objectsRepo;

    [Header("Scripts")]
    [SerializeField] private SaveData saveData;
    [SerializeField] private RetriveData retriveData;
    [SerializeField] private LockShipController lockShipController;

    private ShipStruct currentShip;
    private float fillamnt;
    private int i;


    #endregion

    #region Public Methods
    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextShip()
    {
        i += 1;
        if(i >= shipRepo.ShipsCount)
        {
            i = 0;
            shipsNumberVis.fillAmount = fillamnt;
        }
        else
        {
            shipsNumberVis.fillAmount += fillamnt;
        }
        if (i >= 55)
        {
                fireballs.SetActive(true); 
        }
        else
        {
                fireballs.SetActive(false);
        }
        shipsNumber.text = (i + 1).ToString();
        currentShip = shipRepo.GetShipsByIndex(i);
        UpdateInformation(currentShip);
    }
    public void PrevShip()
    {
        i -= 1;
        if (i < 0 )
        {
            i = shipRepo.ShipsCount - 1;
            shipsNumberVis.fillAmount = 1f;
        }
        else
        {
            shipsNumberVis.fillAmount -= fillamnt;
        }
        if (i >= 55)
        {
            fireballs.SetActive(true);
        }
        else
        {
            fireballs.SetActive(false);
        }
        shipsNumber.text = (i + 1).ToString();
        currentShip = shipRepo.GetShipsByIndex(i);
        UpdateInformation(currentShip);
    }
    public void CancelPanel()
    {
        selectShipValidationPnl.SetActive(false);
        buyShipValidationPnl.SetActive(false);
        if (i >= 55)
        {
            fireballs.SetActive(true);
        }
        else
        {
            fireballs.SetActive(false);
        }
    }

    public void SelectShip()
    {
        selectShipValidationPnl.SetActive(true);
        fireballs.SetActive(false);
    }
    public void SelectShipValidation()
    {
        shipRepo.PushCurrentShip((int)currentShip.key);
        UpdateInformation(currentShip);
        selectShipValidationPnl.SetActive(false);
        saveData.CallShopData();
        retriveData.CallRetrive();
    }


    public void BuyShip()
    {
        buyShipValidationPnl.SetActive(true);
        fireballs.SetActive(false);
    }
    public void BuyShipValidation()
    {
        coinRepo.Pop(currentShip.price);
        shipRepo.ActiveNewShip((int)currentShip.key);
        UpdateCoins();
        UpdateButtons(false, currentShip.price, coinRepo.Get());
        buyShipValidationPnl.SetActive(false);
    }


    #region CoinShop-------------------------------------------------------------------------------------
    public void Coins100()
    {
        
        coinRepo.Push(100);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins500()
    {
        
        coinRepo.Push(500);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins1000()
    {
        
        coinRepo.Push(1000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins5K()
    {
        
        coinRepo.Push(5000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins10K()
    {
        
        coinRepo.Push(10000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins50K()
    {
        
        coinRepo.Push(50000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins100K()
    {
        
        coinRepo.Push(100000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins500K()
    {
        
        coinRepo.Push(500000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins1M()
    {
        
        coinRepo.Push(1000000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins5M()
    {
        
        coinRepo.Push(5000000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins10M()
    {
        
        coinRepo.Push(10000000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    public void Coins100M()
    {
        
        coinRepo.Push(100000000);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }
    #endregion

    public void MainMenu()
    {
        //saveData.CallShopData();
        SceneManager.LoadScene("MainMenu");
    }
    public void BackToShop()
    {
        coinShopPnl.SetActive(false);
        keyShopPnl.SetActive(false);
        if (i >= 55)
        {
            fireballs.SetActive(true);
        }
        else
        {
            fireballs.SetActive(false);
        }
    }
    public void AddKeys()
    {
        keyShopPnl.SetActive(true);
        fireballs.SetActive(false);
    }
    public void AddCoins()
    {
        coinShopPnl.SetActive(true);
        fireballs.SetActive(false);
    }



    public void ShowDetailedCoins()
    {
        coinsNumb.SetActive(false);
        coinsNumb1.SetActive(true);
    }
    public void HideDetailedCoins()
    {
        coinsNumb1.SetActive(false);
        coinsNumb.SetActive(true);
        UpdateCoins();
    }


    public void ShowDetailedScores()
    {
        scoresNumb.SetActive(false);
        scoresNumb1.SetActive(true);
    }
    public void HideDetailedScores()
    {
        scoresNumb1.SetActive(false);
        scoresNumb.SetActive(true);
        UpdateKeyShop();
    }
    public void ExChangeScoresForKeys()
    {
        ChangeScoresForKeys();
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
        SetCurrentShip();
        UpdateCoins();
        OffObjects();
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
            selectedShipChar.sprite = charBody1;
            buyShipChar.sprite = charBody1;
            coinShopChar.sprite = charBody1;
            keyShopChar.sprite = charBody1;
        }
        else if (charRepo.Get() == 200)
        {
            bgChar.sprite = charBody2;
            arrowChar.sprite = charBody2;
            infoChar.sprite = charBody2;
            connectionChar.sprite = charBody2;
            selectedShipChar.sprite = charBody2;
            buyShipChar.sprite = charBody2;
            coinShopChar.sprite = charBody2;
            keyShopChar.sprite = charBody2;
        }
        else if (charRepo.Get() == 300)
        {
            bgChar.sprite = charBody3;
            arrowChar.sprite = charBody3;
            infoChar.sprite = charBody3;
            connectionChar.sprite = charBody3;
            selectedShipChar.sprite = charBody3;
            buyShipChar.sprite = charBody3;
            coinShopChar.sprite = charBody3;
            keyShopChar.sprite = charBody3;
        }
        else if (charRepo.Get() == 400)
        {
            bgChar.sprite = charBody4;
            arrowChar.sprite = charBody4;
            infoChar.sprite = charBody4;
            connectionChar.sprite = charBody4;
            selectedShipChar.sprite = charBody4;
            buyShipChar.sprite = charBody4;
            coinShopChar.sprite = charBody4;
            keyShopChar.sprite = charBody4;
        }
        else if (charRepo.Get() == 500)
        {
            bgChar.sprite = charBody5;
            arrowChar.sprite = charBody5;
            infoChar.sprite = charBody5;
            connectionChar.sprite = charBody5;
            selectedShipChar.sprite = charBody5;
            buyShipChar.sprite = charBody5;
            coinShopChar.sprite = charBody5;
            keyShopChar.sprite = charBody5;
        }
        else if (charRepo.Get() == 600)
        {
            bgChar.sprite = charBody6;
            arrowChar.sprite = charBody6;
            infoChar.sprite = charBody6;
            connectionChar.sprite = charBody6;
            selectedShipChar.sprite = charBody6;
            buyShipChar.sprite = charBody6;
            coinShopChar.sprite = charBody6;
            keyShopChar.sprite = charBody6;
        }
        else if (charRepo.Get() == 700)
        {
            bgChar.sprite = charBody7;
            arrowChar.sprite = charBody7;
            infoChar.sprite = charBody7;
            connectionChar.sprite = charBody7;
            selectedShipChar.sprite = charBody7;
            buyShipChar.sprite = charBody7;
            coinShopChar.sprite = charBody7;
            keyShopChar.sprite = charBody7;
        }
        else if (charRepo.Get() == 800)
        {
            bgChar.sprite = charBody8;
            arrowChar.sprite = charBody8;
            infoChar.sprite = charBody8;
            connectionChar.sprite = charBody8;
            selectedShipChar.sprite = charBody8;
            buyShipChar.sprite = charBody8;
            coinShopChar.sprite = charBody8;
            keyShopChar.sprite = charBody8;
        }
        else if (charRepo.Get() == 900)
        {
            bgChar.sprite = charBody9;
            arrowChar.sprite = charBody9;
            infoChar.sprite = charBody9;
            connectionChar.sprite = charBody9;
            selectedShipChar.sprite = charBody9;
            buyShipChar.sprite = charBody9;
            coinShopChar.sprite = charBody9;
            keyShopChar.sprite = charBody9;
        }
        else if (charRepo.Get() == 1000)
        {
            bgChar.sprite = charBody10;
            arrowChar.sprite = charBody10;
            infoChar.sprite = charBody10;
            connectionChar.sprite = charBody10;
            selectedShipChar.sprite = charBody10;
            buyShipChar.sprite = charBody10;
            coinShopChar.sprite = charBody10;
            keyShopChar.sprite = charBody10;
        }
        else if (charRepo.Get() == 1100)
        {
            bgChar.sprite = charBody11;
            arrowChar.sprite = charBody11;
            infoChar.sprite = charBody11;
            connectionChar.sprite = charBody11;
            selectedShipChar.sprite = charBody11;
            buyShipChar.sprite = charBody11;
            coinShopChar.sprite = charBody11;
            keyShopChar.sprite = charBody11;
        }
        else if (charRepo.Get() == 1200)
        {
            bgChar.sprite = charBody12;
            arrowChar.sprite = charBody12;
            infoChar.sprite = charBody12;
            connectionChar.sprite = charBody12;
            selectedShipChar.sprite = charBody12;
            buyShipChar.sprite = charBody12;
            coinShopChar.sprite = charBody12;
            keyShopChar.sprite = charBody12;
        }
    }


    private void OffObjects()
    {
        coinShopPnl.SetActive(false);
        keyShopPnl.SetActive(false);
        infoPnl.SetActive(false);
        if (i >= 55)
        {
            fireballs.SetActive(true);
        }
        else
        {
            fireballs.SetActive(false);
        }
    }
    private void SetCurrentShip()
    {
        i = shipRepo.GetCurrentShipNumb();
        shipsNumber.text = (i + 1).ToString();
        currentShip = shipRepo.GetShipsByIndex(i);
        fillamnt = Mathf.Clamp01(1f / shipRepo.ShipsCount);
        shipsNumberVis.fillAmount = fillamnt * (i + 1);
    }

    private void Startup()
    {

        if (PlayerPrefs2.GetBool("AlreadyShownShop"))
        {
            arrowPnl.SetActive(false);
            // not the first run, so skip the movie
        }
        else
        {
            // first run, set the indicator so we don't show the movie again later
            PlayerPrefs2.SetBool("AlreadyShownShop", true);

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
                retriveData.CallRetrive();
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

    private void ChangeScoresForKeys()
    {
        int changeScores = int.Parse(scoreField.text);

        if (changeScores < 1000 || changeScores <= 0)
        {
            StartCoroutine(Warning());
        }
        else if (changeScores / 1000 == 0)
        {
            //StartCoroutine(Warning1());
        }
        else if (!scoreRepo.Pop(changeScores))
        {
            StartCoroutine(Warning2());
        }
        else
        {
            scoreRepo.Pop(changeScores);
            kelidRepo.Push((int)(changeScores / 1000));
            UpdateKeyShop();
            StartCoroutine(Success());
        }
    }
    private IEnumerator Warning()
    {
        warningPnl.SetActive(true);
        yield return new WaitForSeconds(5f);
        warningPnl.SetActive(false);
    }
    private IEnumerator Warning2()
    {
        warningPnl2.SetActive(true);
        yield return new WaitForSeconds(5f);
        warningPnl2.SetActive(false);
    }
    private IEnumerator Success()
    {
        BackToShop();
        successPnl.SetActive(true);
        yield return new WaitForSeconds(5f);
        successPnl.SetActive(false);
    }
    private void UpdateKeyShop()
    {
        int score = scoreRepo.Get();
        string convertedScores = ConvertUtility.ConvertNumber(score);
        txtscores.text = string.Format("{0:#,#}", convertedScores);
        txtscores1.text = scoreRepo.Get().ToString("#,#");
        txtKeys.text = kelidRepo.Get().ToString();
        txtKeys1.text = kelidRepo.Get().ToString();
        DBManager.score = scoreRepo.Get();
        DBManager.kelid = kelidRepo.Get();
        saveData.CallShopData();
        retriveData.CallRetrive();
    }


    private void UpdateCoins()
    {
        int coin = coinRepo.Get();
        string convertedcoins = ConvertUtility.ConvertNumber(coin);
        txtCoins.text = string.Format("{0:#,#}", convertedcoins);
        txtCoins1.text = coinRepo.Get().ToString("#,#");
        currentShip = shipRepo.GetShipsByIndex(i);
        UpdateInformation(currentShip);
        UpdateKeyShop();
    }
    private void UpdateInformation(ShipStruct ship)
    {
        txtModel.text = ship.model;
        txtHealth.text = ship.health.ToString();
        txtSpeed.text = ship.speed.ToString();
        SetGunType(ship.bulletType);
        txtFireRate.text = ship.fireRate.ToString();
        txtGunNumb.text = ship.guns.ToString();
        txtAmoPower.text = ship.bulletPower.ToString(); 
        SetPrice(ship.price);
        shipSprite.sprite = ship.sprite;
        shipSprite1.sprite = ship.sprite1;
        ballSprite.sprite = ship.canonBall;
        UpdateButtons(ship.isLocked,ship.price, coinRepo.Get());
        SatgeLock();
        if (shipRepo.GetCurrentShipNumb() == (int)currentShip.key)
        {
            btnAddCoins.gameObject.SetActive(false);
            btnBuyShip.gameObject.SetActive(false);
            btnSelect.gameObject.SetActive(false);
            lockShipController.SetStatus(ship.isLocked = false);
            buyShipImg.SetActive(false);
            selectedShipImg.SetActive(true);
        }
        else
        {
            selectedShipImg.SetActive(false);
            lockShipController.SetStatus(ship.isLocked);
        }
    }
    private void UpdateButtons(bool isLocked,int price, int coins)
    {
        btnAddCoins.gameObject.SetActive(false);
        btnBuyShip.gameObject.SetActive(false);
        btnSelect.gameObject.SetActive(false);

        if (isLocked == true && coins >= price)
        {
        btnBuyShip.gameObject.SetActive(true);
        }
        else if (isLocked == true && coins < price)
        {
        btnAddCoins.gameObject.SetActive(true);
        }
        else if (isLocked == false)
        {
        btnSelect.gameObject.SetActive(true);
        }
    }


    private void SetPrice(int price)
    {
        if (price == 0)
        {
            txtPrice.text = "Free";
        }
        else
        {
            txtPrice.text = price.ToString("#,#");

        }
    }
    private void SetGunType(BulletType type)
    {
        switch (type)
        {
            case BulletType.CanonBall:
                txtGunType.text = "Canon Ball";
                break;

            case BulletType.ClusterBall:
                txtGunType.text = "Cluster Ball";
                break;

            case BulletType.SeaMine:
                txtGunType.text = "Sea Mine";
                break;

            case BulletType.ChaseBall:
                txtGunType.text = "Chase Ball";
                break;

            case BulletType.CrazyBall:
                txtGunType.text = "Crazy Ball";
                break;
            case BulletType.FireBall:
                txtGunType.text = "Fire Ball";
                break;
        }
    }

    private void SatgeLock()
    {
        if (levelReached.Get() < 25 && i > 4)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "2";
        }
        else if (levelReached.Get() > 24 && levelReached.Get() < 49 && i > 9)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "3";
        }
        else if (levelReached.Get() > 48 && levelReached.Get() < 73 && i > 14)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "4";
        }
        else if (levelReached.Get() > 72 && levelReached.Get() < 97 && i > 19)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "5";
        }
        else if (levelReached.Get() > 96 && levelReached.Get() < 121 && i > 24)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "6";
        }
        else if (levelReached.Get() > 120 && levelReached.Get() < 145 && i > 29)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "7";
        }
        else if (levelReached.Get() > 144 && levelReached.Get() < 169 && i > 34)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "8";
        }
        else if (levelReached.Get() > 168 && levelReached.Get() < 193 && i > 39)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "9";
        }
        else if (levelReached.Get() > 192 && levelReached.Get() < 217 && i > 44)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "10";
        }
        else if (levelReached.Get() > 216 && levelReached.Get() < 241 && i > 49)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "11";
        }
        else if (levelReached.Get() > 240 && levelReached.Get() < 265 && i > 54)
        {
            lockPanel.SetActive(true);
            fireballs.SetActive(false);
            txtStagenumber.text = "12";
        }
        else if (levelReached.Get() > 264)
        {
            lockPanel.SetActive(false);
        }
        else
        {
            lockPanel.SetActive(false);
        }
    }






    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
