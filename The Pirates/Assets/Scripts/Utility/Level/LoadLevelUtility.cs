using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelUtility : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables
    [SerializeField] private LevelReached levelReached;
    #endregion

    #region Public Methods
    public void LoadLevel()
    {
        SceneManager.LoadScene("level" + levelReached.Get());
    }

    #endregion

    #region Private Methods
    void Start()
    {

    }//Starttttt






    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
