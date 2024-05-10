using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRepo : MonoBehaviour
{
    #region Public Variables
    public string RepoCharacter { get { return repoCharacter; } }
    #endregion

    #region Private Variables
    private const string repoCharacter = "charRepo";
    private int charNumb;

    #endregion

    #region Public Methods
    public void Push(int count)
    {
        if (count > 0)
        {
            charNumb = count;
            SaveRepo();
        }
    }
    public int Get()
    {
        return Retrive();
    }
    public void Save()
    {
        SaveRepo();
    }
    #endregion

    #region Private Methods

    void Start()
    {
        charNumb = Retrive();
    }//Starttttt


    private int Retrive()
    {
        DBManager.character = charNumb;
        return PlayerPrefs.GetInt(repoCharacter);
    }
    private void SaveRepo()
    {
        PlayerPrefs.SetInt(repoCharacter, charNumb);
        DBManager.character = charNumb;
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
