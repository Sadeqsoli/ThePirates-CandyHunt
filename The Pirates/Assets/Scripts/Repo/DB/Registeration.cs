using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Registeration : MonoBehaviour
{
    #region Public Variables
    [Header("GUI")]
    public InputField nameField;
    public InputField emailField;
    
    public Button btnSubmit;
    public Text validation;
    public Text usernameLogin;
    public Text emailLogin;

    [Header("Game Objects")]
    public GameObject panelSignup;
    public GameObject panelLogin;
    public GameObject panelGender;
    #endregion

    #region Private Variables
    [SerializeField] private CharacterRepo charRepo;
    [SerializeField] private UserRepo userRepo;
    [SerializeField] private LevelReached levelReached;
    [SerializeField] private ShipRepository shipRepo;
    #endregion

    #region Public Methods
    public void Login()
    {
        panelSignup.SetActive(false);
        panelLogin.SetActive(true);
    }
    public void GenderSelection()
    {
        panelSignup.SetActive(false);
        panelGender.SetActive(true);
    }
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void VerifyUsername()
    {
        if (nameField.text.Length >= 3 )
        {
            if (ValidateEmail.validateEmail(emailField.text) && emailField.text.Length >= 5)
            {
                btnSubmit.interactable = true;
            }
        }
         else if (!(nameField.text.Length >= 3))
        {
            btnSubmit.interactable = false;
            //validation.text = "Username must be at least 3 character.";
        }
    }
    public void VerifyEmail()
    {
        if (ValidateEmail.validateEmail(emailField.text) && emailField.text.Length >= 5)
        {
            if (nameField.text.Length >= 3)
            {
                btnSubmit.interactable = true;
                validation.text = "";
            }
        }
        else if (!(ValidateEmail.validateEmail(emailField.text)))
        {
            btnSubmit.interactable = false;
            validation.text = "Email Format is not Correct.";
        }
        if (!(emailField.text.Length >= 5))
        {
            btnSubmit.interactable = false;
            //validation.text = "Email must be at least 5 character.";
        }
    }
    #endregion

    #region Private Methods
    void Awake()
    {

        
    }//Starttttt




    IEnumerator Register()
     {
        WWWForm form = new WWWForm();
        
        form.AddField("username", nameField.text);
        form.AddField("email", emailField.text);

        if(charRepo.Get() == 200)
        {
            form.AddField("gender", "200");
        }
        else if (charRepo.Get() == 100)
        {
            form.AddField("gender", "100");
        }

        WWW www = new WWW("http://sadeqsoli.ir/registeration.php", form);
        yield return www;

            if (www.text == "0")
            {
                Debug.Log("User Registered successfully.");
                SetRepo();
                panelSignup.SetActive(false);
                panelLogin.SetActive(true);
            }
            else
            {
                Debug.Log("Registeration failed. Error # " + www.error);
                validation.text = "Registeration failed. " + www.error;
            }
     }


    private void SetRepo()
    {
        userRepo.PushUsername(nameField.text);
        userRepo.PushEmail(emailField.text);
        levelReached.Push(1);
        shipRepo.PushCurrentShip(0);
    }




    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
