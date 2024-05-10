using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
    {
        StartCoroutine(DestroyThis());
    }//Starttttt

   
    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(1.9f);
        Destroy(gameObject);
    }


    void Update()
    {

    }//Updateeeee
    #endregion
}//EndClasssss
 