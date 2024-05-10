using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{
    #region Public Variables
    public Text txtCoins;
    public Text txtkeys;
    public Text txtLevel;
    public Text txtScore;
    #endregion

    #region Private Variables
    [SerializeField] private CoinRepository coinRepo;
    [SerializeField] private KelidRepo kelidRepo;
    [SerializeField] private ScoreRepository scoreRepo;
    [SerializeField] private LevelReached levelReached;
    #endregion

    #region Public Methods


    #endregion

    #region Private Methods
    void Start()
    {
        txtCoins.text = coinRepo.Get().ToString("#,#");
        txtLevel.text = levelReached.Get().ToString();
        txtkeys.text = kelidRepo.Get().ToString("#,#");
        txtScore.text = scoreRepo.Get().ToString("#,#");
    }//Starttttt
   



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
