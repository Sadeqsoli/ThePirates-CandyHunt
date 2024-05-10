using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    #region Public Variables
    public GameObject[] loadingScreen;
    public Slider[] slider;
    public Text[] progressText;
    #endregion

    #region Private Variables
    private int i ;
    
    #endregion

    #region Public Methods
    public void LoadingLevel(string levelName)
    {
        StartCoroutine(LoadAsync(levelName + DBManager.levels));
    }

    #endregion

    #region Private Methods
    void Start()
    {
        loadingScreen[i].SetActive(false);
    }//Starttttt




    IEnumerator LoadAsync(string levelName)
    {
        AsyncOperation opration = SceneManager.LoadSceneAsync(levelName);
        LoadingSceneChooser();
        while (opration.isDone == false)
        {
            float progress = Mathf.Clamp01(opration.progress / 0.9f);
            slider[i].value = progress;
            progressText[i].text = (progress * 100f).ToString("f0") + "%";
            yield return null;
        }
    }
    private void LoadingSceneChooser()
    {
        if (DBManager.levels < 25)
        {
            loadingScreen[0].SetActive(true);
            slider[i] = slider[0];
            progressText[i] = progressText[0];
        }
        if (DBManager.levels > 24 && DBManager.levels < 49)
        {
            loadingScreen[1].SetActive(true);
            slider[i] = slider[1];
            progressText[i] = progressText[1];
        }
        if (DBManager.levels > 48 && DBManager.levels < 73)
        {
            loadingScreen[2].SetActive(true);
            slider[i] = slider[2];
            progressText[i] = progressText[2];
        }
        if (DBManager.levels > 72 && DBManager.levels < 97)
        {
            loadingScreen[3].SetActive(true);
            slider[i] = slider[3];
            progressText[i] = progressText[3];
        }
        if (DBManager.levels > 96 && DBManager.levels < 121)
        {
            loadingScreen[4].SetActive(true);
            slider[i] = slider[4];
            progressText[i] = progressText[4];
        }
        if (DBManager.levels > 120 && DBManager.levels < 145)
        {
            loadingScreen[5].SetActive(true);
            slider[i] = slider[5];
            progressText[i] = progressText[5];
        }
        if (DBManager.levels > 144 && DBManager.levels < 169)
        {
            loadingScreen[6].SetActive(true);
            slider[i] = slider[6];
            progressText[i] = progressText[6];
        }
        if (DBManager.levels > 168 && DBManager.levels < 193)
        {
            loadingScreen[7].SetActive(true);
            slider[i] = slider[7];
            progressText[i] = progressText[7];
        }
        if (DBManager.levels > 192 && DBManager.levels < 217)
        {
            loadingScreen[8].SetActive(true);
            slider[i] = slider[8];
            progressText[i] = progressText[8];
        }
        if (DBManager.levels > 216 && DBManager.levels < 241)
        {
            loadingScreen[9].SetActive(true);
            slider[i] = slider[9];
            progressText[i] = progressText[9];
        }
        if (DBManager.levels > 240 && DBManager.levels < 265)
        {
            loadingScreen[10].SetActive(true);
            slider[i] = slider[10];
            progressText[i] = progressText[10];
        }
        if (DBManager.levels > 264)
        {
            loadingScreen[11].SetActive(true);
            slider[i] = slider[11];
            progressText[i] = progressText[11];
        }
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
