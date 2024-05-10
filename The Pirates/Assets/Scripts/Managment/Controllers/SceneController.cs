using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;




public class SceneController : MonoBehaviour
{
    #region Public Variables
    public LevelReached levelReached;
    public GameObject errorPnl;
    public Text txtError;
    //public AssetReference[] scenes;
    //public AssetReference[] levels;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void StartGame()
    {
        SceneManager.LoadScene("Level" + levelReached.Get());
    }

    public void GoToShipShop()
    {
        SceneManager.LoadScene("ShipShop");
    }
    public void GoToAchivements()
    {
        SceneManager.LoadScene("Achivements");
    }
    public void GoToLevels()
    {
        SceneManager.LoadScene("LevelManager");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    //public void GoToCredits()
    //{
    //    var async = Addressables.LoadSceneAsync(scenes[3]);
    //    async.Completed += LoadComplete => {

    //        Debug.Log("LOADED! ");
    //    };
    //    StartCoroutine(LoadProgress(async));
    //}

    

    #endregion

    #region Private Methods

    void Start()
    {
    }//Starttttt




    //private IEnumerator LoadProgress(AsyncOperationHandle<SceneInstance> async)
    //{
    //    while (!async.IsDone)
    //    {
    //        Debug.Log(async.PercentComplete);
    //        yield return null;
    //    }

    //}



    //private void LoadComplete(AsyncOperationHandle<SceneInstance> inOperation)
    //{
    //    if (inOperation.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        errorPnl.SetActive(true);
    //        Debug.Log("Downloaded " + inOperation.Result.Scene.name);
    //        txtError.text = "Downloaded " + inOperation.Result.Scene.name;
    //    }
    //    else
    //    {
    //        errorPnl.SetActive(true);
    //        Debug.Log("Error: " + inOperation.OperationException.Message);
    //        txtError.text = "Error: " + inOperation.OperationException.Message;
    //    }
    //}



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
