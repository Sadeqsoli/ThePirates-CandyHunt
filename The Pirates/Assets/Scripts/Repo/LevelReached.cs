using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelReached : MonoBehaviour
{
    #region Public Variables
    public string RepoLevel { get { return LEVELREACHED; } }
    #endregion

    #region Private Variables
    private const string LEVELREACHED = "levelreached";
    private int ReachedLevel;
    #endregion

    #region Public Methods
    public void Push(int count)
    {
        if (count > 0)
        {
            ReachedLevel = count;
            SaveRepo();
        }
    }

    public int Get()
    {
        return Retrive();
    }
   
    #endregion


    #region Private Methods
    void Start()
    {
        ReachedLevel = Retrive();
        DBManager.levels = Retrive();
    }//Starttttt

   

    private int Retrive()
    {
        return PlayerPrefs.GetInt(LEVELREACHED);
    }
    private void SaveRepo()
    {
        PlayerPrefs.SetInt(LEVELREACHED, ReachedLevel);
    }




    void Update()
    {

    }//Updateeeee
  
    #endregion
}//EndClasssss
