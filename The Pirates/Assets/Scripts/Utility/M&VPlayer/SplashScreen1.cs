using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen1 : MonoBehaviour
{
    //public Text txtHint;
    //public Text txtHint1;
    public GameObject splashLoading;
    public GameObject splashLogo;

    void Awake()
    {
        //HintChoser();
        StartCoroutine(SplashScreenLogo());
    }

    IEnumerator SplashScreenLogo()
    {
        yield return new WaitForSeconds(3f);
        splashLoading.SetActive(true);
        splashLogo.SetActive(false);
        StartCoroutine(SplashScreenLoading());
    }
    IEnumerator SplashScreenLoading()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }


    //private void HintChoser()
    //{
    //    int hintNumb = (int)Random.Range(1, 10);

    //    switch (hintNumb)
    //    {
    //        case 1:
    //            txtHint.text = "This is the test of hint number 1";
    //            txtHint1.text = "This is the test of hint number 1";
    //            break;
    //        case 2:
    //            txtHint.text = "This is the test of hint number 2";
    //            txtHint1.text = "This is the test of hint number 2";
    //            break;
    //        case 3:
    //            txtHint.text = "This is the test of hint number 3";
    //            txtHint1.text = "This is the test of hint number 3";
    //            break;
    //        case 4:
    //            txtHint.text = "This is the test of hint number 4";
    //            txtHint1.text = "This is the test of hint number 4";
    //            break;
    //        case 5:
    //            txtHint.text = "This is the test of hint number 5";
    //            txtHint1.text = "This is the test of hint number 5";
    //            break;
    //        case 6:
    //            txtHint.text = "This is the test of hint number 6";
    //            txtHint1.text = "This is the test of hint number 6";
    //            break;
    //        case 7:
    //            txtHint.text = "This is the test of hint number 7";
    //            txtHint1.text = "This is the test of hint number 7";
    //            break;
    //        case 8:
    //            txtHint.text = "This is the test of hint number 8";
    //            txtHint1.text = "This is the test of hint number 8";
    //            break;
    //        case 9:
    //            txtHint.text = "This is the test of hint number 9";
    //            txtHint1.text = "This is the test of hint number 9";
    //            break;
    //        case 10:
    //            txtHint.text = "This is the test of hint number 10";
    //            txtHint1.text = "This is the test of hint number 10";
    //            break;
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
