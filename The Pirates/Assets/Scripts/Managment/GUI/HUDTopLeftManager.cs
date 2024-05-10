using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTopLeftManager : MonoBehaviour
{
    #region Public Variables
    public Text txtHealthPercent;
    public Text txtScore;
    public Sprite redSprite1;
    public Sprite redSprite2;
    public Sprite redSprite3;
    public Sprite redSprite4;
    public Image mainImage;
    public GameController gameController;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods
    public void SetTextScore(int score)
    {
        txtScore.text = score.ToString();
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Private Methods

    void Start()
    {
        
    }//Starttttt



    private void LateUpdate()
    {
        int healthPercent = gameController.GetHealthPercent();
        txtHealthPercent.text = healthPercent.ToString();
        if (healthPercent > 100)
        {
            healthPercent = 100;
        }
        if (healthPercent <= 0)
        {
            healthPercent = 0;
        }

        if (healthPercent > 75)
        {
            mainImage.sprite = redSprite1;
        }
        else if (healthPercent < 75)
        {
            mainImage.sprite = redSprite2;
        }
        else if (healthPercent < 50)
        {
            mainImage.sprite = redSprite3;
        }
        else if (healthPercent < 25)
        {
            mainImage.sprite = redSprite4;
        }
    }//LateUpdateeeee
    #endregion
}//EndClasssss
