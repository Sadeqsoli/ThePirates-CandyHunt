using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRepository : MonoBehaviour
{
    #region Public Variables
    public string RepositeName { get { return repositeName; } }
    #endregion

    #region Private Variables
    private const string lastScoreRepository = "lastScoreRepository";
    private const string highScoreRepository = "highScoreRepository";
    private const string repositeName = "scoreRepo";
    private int scores;
    #endregion

    #region Public Methods
    public bool Pop(int count)
    {
        if (Has(count))
        {
            scores = scores - count;
            Save(repositeName, scores);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PushScores(int count)
    {
        if (count > 0)
        {
            scores = scores + count;
            Save(repositeName, scores);
        }
    }
    public void Push(int s)
    {
        Save(lastScoreRepository, s);
        int h = GetHighScore();
        if(s > h)
        {
            Save(highScoreRepository, s);
        }
    }

    public int Get()
    {
        return Retrive(repositeName);
    }
    public int GetLastScore()
    {
        return Retrive(lastScoreRepository);
    }
    public int GetHighScore()
    {
        return Retrive(highScoreRepository);
    }
    #endregion




    #region Private Methods
    void Start()
    {
        scores = Retrive(repositeName);

    }//Starttttt




    private bool Has(int Count)
    {
        if (scores >= Count)
        {
            return true;
        }
        return false;
    }
    private int Retrive(string key)
    {
        DBManager.score = scores;
        return PlayerPrefs.GetInt(key);
    }
    private void Save(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
        DBManager.score = scores;
    }





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
  