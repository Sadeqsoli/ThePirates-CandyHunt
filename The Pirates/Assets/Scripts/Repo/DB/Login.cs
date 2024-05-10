using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    #region Public Variables
    public InputField nameField;
    public GameObject panelLogin;
    public GameObject pnlwelcome;
    public GameObject panelGender;
    public Text playerName;
    public Text playerName1;
    public Text playerName2;
    public Text validation;
    public Button btnSubmit;
    #endregion

    #region Private Variables
    [Header("Repositories")]
    [SerializeField] private CharacterRepo charRepo;
    [SerializeField] private UserRepo userRepo;
    [SerializeField] private LevelReached levelReached;
    [SerializeField] private ShipRepository shipRepo;

    #endregion

    #region Public Methods
    public void GenderSelection()
    {
        panelLogin.SetActive(false);
        panelGender.SetActive(true);
    }

    public void CallRegister()
    {
        StartCoroutine(Register());

    }

    public void VerifyUsername()
    {
        if (nameField.text.Length >= 3)
        {
            btnSubmit.interactable = true;
        }
        if (!(nameField.text.Length >= 3))
        {
            btnSubmit.interactable = false;
            //validation.text = "Username must be at least 3 character.";
        }

    }
    //public void VerifyEmail()
    //{
    //    if (ValidateEmail.validateEmail(emailField.text) && emailField.text.Length >= 5)
    //    {
    //        btnSubmit.interactable = true;
    //        validation.text = "";
    //    }
    //    else if (!(ValidateEmail.validateEmail(emailField.text)))
    //    {
    //        btnSubmit.interactable = false;
    //        validation.text = "Email Format is not Correct.";
    //    }
    //    if (!(emailField.text.Length >= 5))
    //    {
    //        btnSubmit.interactable = false;
    //        //validation.text = "Email must be at least 5 character.";
    //    }
    //}
    #endregion




    #region Private Methods
    void Awake()
    {

    }//Awakeeeee

    IEnumerator Register()
    {
        //WWWForm form = new WWWForm();

        //form.AddField("username", nameField.text);
        //form.AddField("character", charRepo.Get());


        //WWW www = new WWW("http://sadeqsoli.ir/registeration.php", form);
        yield return null;

        //if (www.text == "0")
        //{
        Debug.Log("User Registered successfully.");
        SetRepo();
        SetUsername();
        pnlwelcome.SetActive(true);
        panelLogin.SetActive(false);
        //}
        //else
        //{
        //    Debug.Log("Registeration failed." + www.error);
        //    validation.text = "Registeration failed. " + www.error;
        //}
    }

    private void SetUsername()
    {
        playerName.text = userRepo.GetUser();
        playerName1.text = userRepo.GetUser();
        playerName2.text = userRepo.GetUser();
    }

    private void SetRepo()
    {
        userRepo.PushUsername(nameField.text);
        levelReached.Push(0);
        shipRepo.PushCurrentShip(0);
    }

    //private void GetInformation()
    //{
    //    if(DBManager.score != 0 || DBManager.kelid != 0 || DBManager.col_coins != 0 & DBManager.crossed_candy != 0)
    //    {
    //        scoreRepo.PushScores(DBManager.score);
    //        coinRepo.Push(DBManager.col_coins);
    //        kelidRepo.Push(DBManager.kelid);
    //        genderRepo.Push(DBManager.gender);
    //        userRepo.PushUsername(DBManager.username);
    //        userRepo.PushEmail(DBManager.email);
    //        levelReached.Push(DBManager.levels);
    //    }
    //}






    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
