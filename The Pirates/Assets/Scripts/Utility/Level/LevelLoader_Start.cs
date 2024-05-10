using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader_Start : MonoBehaviour
{
    #region Public Variables
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    #endregion

    #region Private Variables
    
    
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

    }//Starttttt



    IEnumerator LoadAsync(string levelName)
    {
        AsyncOperation opration = SceneManager.LoadSceneAsync(levelName);
        loadingScreen.SetActive(true);
        while (opration.isDone == false)
        {
            float progress = Mathf.Clamp01(opration.progress / 0.9f);
            slider.value = progress;
            progressText.text = (progress * 100f).ToString("f0") + "%";
            yield return null;
        }
    }
   


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
