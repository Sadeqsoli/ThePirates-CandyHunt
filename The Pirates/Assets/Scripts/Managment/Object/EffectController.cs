using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
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
        yield return new WaitForSeconds(0.9f);
        Destroy(gameObject);
    }


    void Update()
    {

    }//Updateeeee
    #endregion
}//EndClasssss
 