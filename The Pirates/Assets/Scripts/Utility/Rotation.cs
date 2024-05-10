using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    #region Public Variables
    public Vector3 speed;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
    {

    }//Starttttt





    void Update()
    {
        transform.Rotate(speed * Time.deltaTime); 
    }//Updateeeee

    #endregion
}//EndClasssss