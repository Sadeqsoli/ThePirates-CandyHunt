using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    #region Public Variables
    [Header("Image Display")]
    public Image loginChar;
    public Image char_Pro_Out;
    public Image char_Pro_In;
    public Image char_Profile;
    public Image newEmailChar;
    public Image exitChar;
    public Image connectionChar;
    public Image problemChar;
    public Image creditChar;
    public Image checkCahr;

    [Header("Head Sprite")]
    public Sprite charHead1;
    public Sprite charHead2;
    public Sprite charHead3;
    public Sprite charHead4;
    public Sprite charHead5;
    public Sprite charHead6;
    public Sprite charHead7;
    public Sprite charHead8;
    public Sprite charHead9;
    public Sprite charHead10;
    public Sprite charHead11;
    public Sprite charHead12;

    [Header("Body Sprite")]
    public Sprite charBody1;
    public Sprite charBody2;
    public Sprite charBody3;
    public Sprite charBody4;
    public Sprite charBody5;
    public Sprite charBody6;
    public Sprite charBody7;
    public Sprite charBody8;
    public Sprite charBody9;
    public Sprite charBody10;
    public Sprite charBody11;
    public Sprite charBody12;
    #endregion

    #region Private Variables
    [SerializeField] private CharacterRepo charRepo;
    #endregion

    #region Public Methods
    public void CharSelecting()
    {
        CharSelection();
    }
    #endregion

    #region Private Methods

    void Start()
    {
        CharSelection();
    }//Starttttt



    private void CharSelection()
    {
        if (charRepo.Get() == 100)
        {
            loginChar.sprite = charBody1;
            char_Pro_Out.sprite = charHead1;
            char_Pro_In.sprite = charHead1;
            exitChar.sprite = charBody1;
            newEmailChar.sprite = charBody1;
            connectionChar.sprite = charBody1;
            char_Profile.sprite = charBody1;
            problemChar.sprite = charBody1;
            creditChar.sprite = charBody1;
            checkCahr.sprite = charBody1;
        }
        else if (charRepo.Get() == 200)
        {
            loginChar.sprite = charBody2;
            char_Pro_Out.sprite = charHead2;
            char_Pro_In.sprite = charHead2;
            exitChar.sprite = charBody2;
            newEmailChar.sprite = charBody2;
            connectionChar.sprite = charBody2;
            char_Profile.sprite = charBody2;
            problemChar.sprite = charBody2;
            creditChar.sprite = charBody2;
            checkCahr.sprite = charBody2;
        }
        else if (charRepo.Get() == 300)
        {
            loginChar.sprite = charBody3;
            char_Pro_Out.sprite = charHead3;
            char_Pro_In.sprite = charHead3;
            exitChar.sprite = charBody3;
            newEmailChar.sprite = charBody3;
            connectionChar.sprite = charBody3;
            char_Profile.sprite = charBody3;
            problemChar.sprite = charBody3;
            creditChar.sprite = charBody3;
            checkCahr.sprite = charBody3;
        }
        else if (charRepo.Get() == 400)
        {
            loginChar.sprite = charBody4;
            char_Pro_Out.sprite = charHead4;
            char_Pro_In.sprite = charHead4;
            exitChar.sprite = charBody4;
            newEmailChar.sprite = charBody4;
            connectionChar.sprite = charBody4;
            char_Profile.sprite = charBody4;
            problemChar.sprite = charBody4;
            creditChar.sprite = charBody4;
            checkCahr.sprite = charBody4;
        }
        else if (charRepo.Get() == 500)
        {
            loginChar.sprite = charBody5;
            char_Pro_Out.sprite = charHead5;
            char_Pro_In.sprite = charHead5;
            exitChar.sprite = charBody5;
            newEmailChar.sprite = charBody5;
            connectionChar.sprite = charBody5;
            char_Profile.sprite = charBody5;
            problemChar.sprite = charBody5;
            creditChar.sprite = charBody5;
            checkCahr.sprite = charBody5;
        }
        else if (charRepo.Get() == 600)
        {
            loginChar.sprite = charBody6;
            char_Pro_Out.sprite = charHead6;
            char_Pro_In.sprite = charHead6;
            exitChar.sprite = charBody6;
            newEmailChar.sprite = charBody6;
            connectionChar.sprite = charBody6;
            char_Profile.sprite = charBody6;
            problemChar.sprite = charBody6;
            creditChar.sprite = charBody6;
            checkCahr.sprite = charBody6;
        }
        else if (charRepo.Get() == 700)
        {
            loginChar.sprite = charBody7;
            char_Pro_Out.sprite = charHead7;
            char_Pro_In.sprite = charHead7;
            exitChar.sprite = charBody7;
            newEmailChar.sprite = charBody7;
            connectionChar.sprite = charBody7;
            char_Profile.sprite = charBody7;
            problemChar.sprite = charBody7;
            creditChar.sprite = charBody7;
            checkCahr.sprite = charBody7;
        }
        else if (charRepo.Get() == 800)
        {
            loginChar.sprite = charBody8;
            char_Pro_Out.sprite = charHead8;
            char_Pro_In.sprite = charHead8;
            exitChar.sprite = charBody8;
            newEmailChar.sprite = charBody8;
            connectionChar.sprite = charBody8;
            char_Profile.sprite = charBody8;
            problemChar.sprite = charBody8;
            creditChar.sprite = charBody8;
            checkCahr.sprite = charBody8;
        }
        else if (charRepo.Get() == 900)
        {
            loginChar.sprite = charBody9;
            char_Pro_Out.sprite = charHead9;
            char_Pro_In.sprite = charHead9;
            exitChar.sprite = charBody9;
            newEmailChar.sprite = charBody9;
            connectionChar.sprite = charBody9;
            char_Profile.sprite = charBody9;
            problemChar.sprite = charBody9;
            creditChar.sprite = charBody9;
            checkCahr.sprite = charBody9;
        }
        else if (charRepo.Get() == 1000)
        {
            loginChar.sprite = charBody10;
            char_Pro_Out.sprite = charHead10;
            char_Pro_In.sprite = charHead10;
            exitChar.sprite = charBody10;
            newEmailChar.sprite = charBody10;
            connectionChar.sprite = charBody10;
            char_Profile.sprite = charBody10;
            problemChar.sprite = charBody10;
            creditChar.sprite = charBody10;
            checkCahr.sprite = charBody10;
        }
        else if (charRepo.Get() == 1100)
        {
            loginChar.sprite = charBody11;
            char_Pro_Out.sprite = charHead11;
            char_Pro_In.sprite = charHead11;
            exitChar.sprite = charBody11;
            newEmailChar.sprite = charBody11;
            connectionChar.sprite = charBody11;
            char_Profile.sprite = charBody11;
            problemChar.sprite = charBody11;
            creditChar.sprite = charBody11;
            checkCahr.sprite = charBody11;
        }
        else if (charRepo.Get() == 1200)
        {
            loginChar.sprite = charBody12;
            char_Pro_Out.sprite = charHead12;
            char_Pro_In.sprite = charHead12;
            exitChar.sprite = charBody12;
            newEmailChar.sprite = charBody12;
            connectionChar.sprite = charBody12;
            char_Profile.sprite = charBody12;
            problemChar.sprite = charBody12;
            creditChar.sprite = charBody12;
            checkCahr.sprite = charBody12;
        }
    }




    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
