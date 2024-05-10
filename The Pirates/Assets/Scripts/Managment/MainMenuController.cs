using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class MainMenuController : MonoBehaviour
{
    #region Public Variables
    [Header("Game Objects")]
    public GameObject panelGender;
    public GameObject buttons;
    public GameObject settingPanel;
    public GameObject profilePanel;
    public GameObject emailChangePnl;
    public GameObject anouncePnl;
    public GameObject noConnectionPnl;
    public GameObject bgConnection;
    public GameObject problemPnl;
    public GameObject process;
    public GameObject mPlayer;


    

    [Header("GUI")]
    public Text playername;
    public Text playername1;
    public Text invalidationtxt;
    public InputField o_EmailField;
    public InputField n_EmailField1;
    public InputField n_EmailField2;
    public Button btnChange;


    #endregion

    #region Private Variables
    [Header("Scripts")]
    [SerializeField] private RetriveData retriveData;
    [SerializeField] private SaveData saveData;
    [SerializeField] private Login log;
    [SerializeField] private UserRepo userRepo;
    [SerializeField] private LevelReached levelReached;
    #endregion

    #region Public Methods
    public void EqualEmail()
    {
        if (n_EmailField1.text != n_EmailField2.text)
        {
            btnChange.interactable = false;
        }
        else
        {
            btnChange.interactable = true;
        }
    }
    public void ShareBtn()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted!");
    }
    public void RestValues()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted!");
    }

    public void ShowSettingPanel()
    {
        buttons.SetActive(false);
        settingPanel.SetActive(true);
    }
    public void HideSettingPanel()
    {
        settingPanel.SetActive(false);
        buttons.SetActive(true);
    }

    public void ShowChangingEmail()
    {
        profilePanel.SetActive(false);
        emailChangePnl.SetActive(true);
    }
    public void HideChangingEmail()
    {
        emailChangePnl.SetActive(false);
        profilePanel.SetActive(true);
    }
    public void SendNewEmail()
    {
        StartCoroutine(SaveNewEmail());
    }

    public void ShowProfilePanel()
    {
        buttons.SetActive(false);
        profilePanel.SetActive(true);
    }
    public void HideProfilePanel()
    {
        profilePanel.SetActive(false);
        buttons.SetActive(true);
    }
    public void RetryConnection()
    {
        StartCoroutine(Process());
    }
    #endregion


    #region Private Methods
    void Awake()
    {
        Connectivity();
    }//Awakeee

    


    private void SetUsername()
    {
        retriveData.CallRetrive();
        playername1.text = userRepo.GetUser();
        playername.text = userRepo.GetUser();
    }
    private IEnumerator SaveNewEmail()
    {
        WWWForm form = new WWWForm();

        form.AddField("o_email", o_EmailField.text);
        form.AddField("n_email", n_EmailField1.text);

        WWW www = new WWW("http://localhost/pirate/saveemail.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("New Email Saved.");
            userRepo.PushEmail(n_EmailField1.text);
            emailChangePnl.SetActive(false);
            profilePanel.SetActive(true);
            anouncePnl.SetActive(true);

        }
        else
        {
            Debug.Log("Save Failed. Error #" + www.text);
            invalidationtxt.gameObject.SetActive(true);
        }

    }
    private void SignUpCheck()
    {
        if (!(PlayerPrefs.HasKey(userRepo.RepoUser)))
        {
            panelGender.SetActive(true);
        }
        if (PlayerPrefs.HasKey(userRepo.RepoUser))
        {
            panelGender.SetActive(false);
            SetUsername();
        }
    }

    private void Connectivity()
    {
        noConnectionPnl.SetActive(false);
        SignUpCheck();
        StartCoroutine(CheckConnectivity((isConnected) =>
        {
            if (isConnected)
            {
                Debug.Log("Connected");
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            else
            {
                noConnectionPnl.SetActive(true);
                mPlayer.SetActive(false);
                Debug.Log("Not Connected");
            }

        }));
    }
    private IEnumerator CheckConnectivity(Action<bool> action)
    {

        WWW www = new WWW("https://google.com");
        yield return www;
        if(www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }
    private IEnumerator Process()
    {
        bgConnection.SetActive(false);
        process.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





    void Update()
    {
        
    }//Updateeeee

    #endregion
}//EndClasssss
