using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockShipController : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject myShip;
    [SerializeField] private GameObject selectedShip;
    private bool isLock;
    #endregion

    #region Public Methods
    public void SetStatus(bool s)
    {
        if(s == true)
        {
            Enable();
        }else
        {
            Disable();
        }
    }

    public void Enable()
    {
        isLock = true;
        anim.SetBool("isLock", isLock);
        myShip.SetActive(false);
    }
    public void Disable()
    {
        isLock = false;
        anim.SetBool("isLock", isLock);
        myShip.SetActive(true);
        //selectedShip.SetActive(false);
    }
    #endregion

    #region Private Methods

    void Start()
    {
        myShip.SetActive(false);
    }//Starttttt





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
