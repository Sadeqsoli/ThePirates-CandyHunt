using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBulletManager : MonoBehaviour
{
    #region Public Variables
    public int dangerBulletCount;
    public Sprite blueSprite;
    public Sprite redSprite;
    public Image mainHUD;
    public Text txtBullet;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    public void SetBullet(int bullet)
    {
        if (bullet < 0)
        {
            bullet = 0;
        }
        txtBullet.text = bullet.ToString();
        if(bullet >= dangerBulletCount)
        {
            mainHUD.sprite = blueSprite;
        }
        else
        {
            mainHUD.sprite = redSprite; 
        }
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Private Methods
    void Start()
    {
        //txtBullet = GameObject.FindGameObjectWithTag("txtbullet").GetComponent<Text>();
    }//Starttttt


    void Update()
    {
       
    }//Updateeeee

    #endregion
}//EndClasssss
