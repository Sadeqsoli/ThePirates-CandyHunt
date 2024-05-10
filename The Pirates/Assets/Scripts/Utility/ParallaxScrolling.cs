using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    #region Public Variables
    public Vector2 speed; 
    #endregion

    #region Private Variables
    private Renderer myRender;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void Awake()
    {
        myRender = GetComponent<Renderer>();
    }//Awakeeeeee







    void Update()
    {
        myRender.material.mainTextureOffset = Time.time * speed;
    }//Updateeeee

    #endregion
}//EndClasssss
