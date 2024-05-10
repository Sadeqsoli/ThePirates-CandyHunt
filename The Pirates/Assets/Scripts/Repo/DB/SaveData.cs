using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    
    public void CallSaveData()
    {
        //StartCoroutine(SavePoints());
    }
    public void CallShopData()
    {
        StartCoroutine(SaveShop());
    }
    #endregion

    #region Private Methods

    void Start()
    {
        
    }//Starttttt




    IEnumerator SavePoints()
    {
        WWWForm form = new WWWForm();

        form.AddField("username", DBManager.username);
        form.AddField("email", DBManager.email);
        form.AddField("current_ship", DBManager.current_ship);
        form.AddField("levels", DBManager.levels);
        form.AddField("score", DBManager.score);
        form.AddField("kelid", DBManager.kelid);
        form.AddField("col_coins", DBManager.col_coins);
        form.AddField("col_candy", DBManager.col_candy);
        form.AddField("col_powerups", DBManager.col_powerups);
        form.AddField("des_junkcandy", DBManager.des_junkcandy);
        form.AddField("des_enemyships", DBManager.des_enemyships);
        form.AddField("des_childships", DBManager.des_childships);
        form.AddField("crossed_coins", DBManager.crossed_coins);
        form.AddField("crossed_candy", DBManager.crossed_candy);
        form.AddField("crossed_powerups", DBManager.crossed_powerups);
        form.AddField("crossed_junkcandy", DBManager.crossed_junkcandy);
        form.AddField("crossed_enemyships", DBManager.crossed_enemyships);
        form.AddField("crossed_childships", DBManager.crossed_childships);

        WWW www = new WWW("http://sadeqsoli.ir/savedata.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save Failed. Error #" + www.text);
        }
    }

    IEnumerator SaveShop()
    {
        WWWForm form = new WWWForm();

        form.AddField("username", DBManager.username);
        form.AddField("email", DBManager.email);
        form.AddField("current_ship", DBManager.current_ship);
        form.AddField("score", DBManager.score);
        form.AddField("kelid", DBManager.kelid);
        form.AddField("col_coins", DBManager.col_coins);

        WWW www = new WWW("http://sadeqsoli.ir/saveshopdata.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Shop Data Saved.");
        }
        else
        {
            Debug.Log("Save Failed. Error #" + www.text);
        }
    }


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss

