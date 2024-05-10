using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    #region Public Variables
    public GameObject joystickButton;
    public GameObject fireButton;
    #endregion

    #region Private Variables
    private ShipController ship;
    #endregion

    #region Public Methods
    public void Fire()
    {

        ship.FireBullet(); 
    }

    public void MoveLeft()
    {
        ship.MoveLeft();
    }
    public void MoveRight()
    {
        ship.MoveRight();
    }
    public void MoveUp()
    {
        ship.MoveUp();
    }
    public void MoveDown()
    {
        ship.MoveDown();
    }
    public void StopMoving()
    {
        ship.StopMoving();
    }

    public void Attach(ShipController s)
    {
        ship = s;
        GUIActivator(true);
    }

    public void Dettach()
    {
        ship = null;
        GUIActivator(false);
    }
    #endregion

    #region Private Methods
    void Start()
    {
        if (ship == null)
        {
            GUIActivator(false);
        }
    }//Starttttt




    private void GUIActivator(bool active)
    {
        joystickButton.gameObject.SetActive(active);
        fireButton.SetActive(active);
    }




    void Update()
    {

    }//Updateeeee
           
    #endregion
}//EndClasssss
