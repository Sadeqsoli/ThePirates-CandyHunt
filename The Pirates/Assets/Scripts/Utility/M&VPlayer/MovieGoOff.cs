using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieGoOff : MonoBehaviour
{

    void Start()
    {
        try
        {
            // Do something that can throw an exception
            StartCoroutine(MovieGoOfff());
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            Destroy(gameObject);
        }
    }//Startttttt

    IEnumerator MovieGoOfff()
    {

        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }

}//EndClassssss