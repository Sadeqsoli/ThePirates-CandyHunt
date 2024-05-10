using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRepo : MonoBehaviour
{
    #region Public Variables
    public string RepoUser { get { return repoUser; } }
    #endregion

    #region Private Variables
    private const string emailRepo = "emailRepo";
    private const string repoUser = "userRepo";
    private string username;
    private string email;
    #endregion

    #region Public Methods
    

    public void PushUsername(string newUser)
    {
        username = newUser;
        Save(repoUser, username);
    }
    public void PushEmail(string newEmail)
    {
        email = newEmail;
        Save(emailRepo, email);
    }
   

    public string GetUser()
    {
        return Retrive(repoUser);
    }
    public string GetEmail()
    {
        return Retrive(emailRepo);
    }
  
    #endregion




    #region Private Methods
    void Start()
    {
        username = Retrive(repoUser);
        email = Retrive(emailRepo);
    }//Starttttt





    private string Retrive(string key)
    {
        DBManager.username = username;
        DBManager.email = email;
        return PlayerPrefs.GetString(key);
    }
    private void Save(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
        DBManager.username = username;
        DBManager.email = email;
    }





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
  