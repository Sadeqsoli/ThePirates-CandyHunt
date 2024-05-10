using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShipEnums
{
    DragonOfTheSeas1,
    DragonOfTheSeas2,
    DragonOfTheSeas3,
    DragonOfTheSeas4,
    DragonOfTheSeas5,
    SwordsOfTheTruth1,
    SwordsOfTheTruth2,
    SwordsOfTheTruth3,
    SwordsOfTheTruth4,
    SwordsOfTheTruth5,
    QueenOfTheSeas1,
    QueenOfTheSeas2,
    QueenOfTheSeas3,
    QueenOfTheSeas4,
    QueenOfTheSeas5,
    TheBlackSwan1,
    TheBlackSwan2,
    TheBlackSwan3,
    TheBlackSwan4,
    TheBlackSwan5,
    TheBlackDragon1,
    TheBlackDragon2,
    TheBlackDragon3,
    TheBlackDragon4,
    TheBlackDragon5,
    TheKingOfTheSeas1,
    TheKingOfTheSeas2,
    TheKingOfTheSeas3,
    TheKingOfTheSeas4,
    TheKingOfTheSeas5,
    TheYoungLion1,
    TheYoungLion2,
    TheYoungLion3,
    TheYoungLion4,
    TheYoungLion5,
    TheGoldenGriffin1,
    TheGoldenGriffin2,
    TheGoldenGriffin3,
    TheGoldenGriffin4,
    TheGoldenGriffin5,
    TheGiftOfDeath1,
    TheGiftOfDeath2,
    TheGiftOfDeath3,
    TheGiftOfDeath4,
    TheGiftOfDeath5,
    TheRageOfGods1,
    TheRageOfGods2,
    TheRageOfGods3,
    TheRageOfGods4,
    TheRageOfGods5,
    MasterOfTheSeas1,
    MasterOfTheSeas2,
    MasterOfTheSeas3,
    MasterOfTheSeas4,
    MasterOfTheSeas5,
    TheRedPirates1,
    TheRedPirates2,
    TheRedPirates3,
    TheRedPirates4,
    TheRedPirates5,
}
public enum BulletType
{
    CanonBall,
    ClusterBall,
    SeaMine,
    ChaseBall,
    CrazyBall,
    FireBall
}
[System.Serializable]
public struct ShipStruct
{
    [Header("--------------------------Ship Info--------------------------")]
    public ShipEnums key;
    public GameObject Ship;
    [Range(1, 20)]
    public int speed;
    [Range(1, 1500)]
    public int health;
    [Range(1,20)]
    public int guns;
    [Range(1, 100)]
    public int bulletPower;
    [Range(0.0f, 5f)]
    public float fireRate;
    public string model;
    public BulletType bulletType;
    public int price;
    public bool isLocked;
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite canonBall;
    
}

public class ShipRepository : MonoBehaviour
{
    #region Public Variables
    private SaveData saveData;
    public ShipStruct[] ships;
    public int ShipsCount { get { return ships.Length; } }
    #endregion
    
    #region Private Variables
    private const string currentShipRepo = "currentShipRepo";
    private const string ShipsRepo = "shipsRepo";
    private int currentShip;
    #endregion

    #region Public Methods

    public ShipStruct GetShipsByIndex(int i)
    {
        ships[i].isLocked = !IsShipActive(i);

        return ships[i];
    }

    public ShipStruct GetCurrentShip()
    {
        int Index = GetCurrentShipNumb();
        ships[Index].isLocked = IsShipActive(Index);
        return ships[Index];
    }
  
    public int GetCurrentShipNumb()
    {
        return Retrive();
    }
    public void PushCurrentShip(int count)
    {
        if (count >= 0)
        {
            currentShip = count;
            SaveCurrentShip();
        }
    }

    public void ActiveNewShip(int i)
    {
        string s = RetriveShips();
        s += i.ToString();
        SaveShips(s);
    }

    #endregion





    #region Private Methods
    void Start()
    {
        currentShip = Retrive();
    }//Starttttt




    private void SaveShips(string s)
    {
        PlayerPrefs.SetString(ShipsRepo, s);
    }
    private string RetriveShips()
    {
        return PlayerPrefs.GetString(ShipsRepo);
    }
    private bool IsShipActive(int i)
    {
        string s = PlayerPrefs.GetString(ShipsRepo);
        if (s.Contains(i.ToString()))
        {
            
            return true;

        }
        else
        {
            
            return false;
        }
    }

    private int Retrive()
    {
        DBManager.current_ship = currentShip;
        return PlayerPrefs.GetInt(currentShipRepo);
    }

    private void SaveCurrentShip()
    {
        PlayerPrefs.SetInt(currentShipRepo, currentShip);
        DBManager.current_ship = currentShip;
    }


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
