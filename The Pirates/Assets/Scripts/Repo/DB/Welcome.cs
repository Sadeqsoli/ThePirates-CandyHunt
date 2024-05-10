using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Welcome : MonoBehaviour
{
    #region Public Variables
    public GameObject pnlwelcome;

    #endregion

    #region Private Variables
    [SerializeField] private UserRepo userRepo;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    private void Awake()
    {
        
        StartCoroutine(WelcomeGoOff());
    }//Startttttt
    


    IEnumerator WelcomeGoOff()
    {
        StartCoroutine(LoginForm());
        pnlwelcome.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        pnlwelcome.SetActive(false);
    }

    private IEnumerator LoginForm()
    {

        WWW www = new WWW("http://sadeqsoli.ir/getinfo.php");
        yield return www;

        if (www.text[0] == '0')
        {
            if ((www.text.Split('\t')[1]) == userRepo.GetUser())
            {
                DBManager.username = (www.text.Split('\t')[1]);
                DBManager.email = (www.text.Split('\t')[2]);
                DBManager.character = int.Parse(www.text.Split('\t')[3]);
                DBManager.current_ship = int.Parse(www.text.Split('\t')[4]);
                DBManager.levels = int.Parse(www.text.Split('\t')[5]);
                DBManager.score = int.Parse(www.text.Split('\t')[6]);
                DBManager.kelid = int.Parse(www.text.Split('\t')[7]);
                DBManager.col_coins = int.Parse(www.text.Split('\t')[8]);
                DBManager.col_candy = int.Parse(www.text.Split('\t')[9]);
                DBManager.col_powerups = int.Parse(www.text.Split('\t')[10]);
                DBManager.des_junkcandy = int.Parse(www.text.Split('\t')[11]);
                DBManager.des_enemyships = int.Parse(www.text.Split('\t')[12]);
                DBManager.des_childships = int.Parse(www.text.Split('\t')[13]);
                DBManager.crossed_coins = int.Parse(www.text.Split('\t')[14]);
                DBManager.crossed_candy = int.Parse(www.text.Split('\t')[15]);
                DBManager.crossed_powerups = int.Parse(www.text.Split('\t')[16]);
                DBManager.crossed_junkcandy = int.Parse(www.text.Split('\t')[17]);
                DBManager.crossed_enemyships = int.Parse(www.text.Split('\t')[18]);
                DBManager.crossed_childships = int.Parse(www.text.Split('\t')[19]);

                Debug.Log("User Logged in successfuly");
            }
        }
        else
        {
            Debug.Log("Login Failed. Error #" + www.text);
        }
    }


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
