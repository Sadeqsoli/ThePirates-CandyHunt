using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Bullet : MonoBehaviour
{
    #region Public Variables
    public GameObject explosion;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {

    }//Starttttt



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
    }
   


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
