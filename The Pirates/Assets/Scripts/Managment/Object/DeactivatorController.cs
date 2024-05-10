using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatorController : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables
    private GameController gameController;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }//Starttttt



    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GameObjectDeactivator(collision.gameObject);
        gameController.AddCrosseedItems(collision.gameObject);
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
