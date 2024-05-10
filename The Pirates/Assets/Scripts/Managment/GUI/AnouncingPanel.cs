using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnouncingPanel : MonoBehaviour
{
    #region Public Variables
    public GameObject rndObject;
    public Text txtUsername;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {
        StartCoroutine(Anouncing());
        txtUsername.text = DBManager.username;
    }//Starttttt



    private IEnumerator Anouncing()
    {
        yield return new WaitForSeconds(3f);
        rndObject.SetActive(false);
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
