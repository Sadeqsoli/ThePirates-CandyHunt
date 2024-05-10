using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfettiController : MonoBehaviour
{
    #region Public Variables

    #endregion


    #region Private Variables
    [SerializeField] private Transform[] pfConfetti;
    //[SerializeField] private Color[] colorArray;
    private List<Cofetti> cofettiList;
    private float spawnTimer;
    private const float SPAWN_TIME_MAX = 0.033f;
    private int i ;
    #endregion

    #region Public Methods

    #endregion


    #region Private Methods
    private void Awake()
    {
        cofettiList = new List<Cofetti>();
    }



    private class Cofetti
    {
        private RectTransform rectTransform;
        private Transform transform;
        private Vector2 anchoredPosition;
        private Vector3 eular;
        private float eularSpeed;
        private Vector2 moveSpeed;
        private float minimumY;

        public Cofetti(Transform prefab, Transform container, Vector2 anchoredPosition,  float minimumY)
        {
            this.minimumY = minimumY;
            this.anchoredPosition = anchoredPosition;
            transform = Instantiate(prefab, container);
            rectTransform = transform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;

            rectTransform.sizeDelta *= Random.Range(0.8f, 1.2f);
            eular = new Vector3(0, 0, Random.Range(0, 360f));
            eularSpeed = Random.Range(100f, 200f);
            eularSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
            transform.localEulerAngles = eular;
            moveSpeed = new Vector2(0, Random.Range(-50f ,-150f)); 
            //transform.GetComponent<Image>().color = color;
        }
        public bool Update()
        {
            Vector2 moveAmount = new Vector2(0, -100f);
            anchoredPosition += moveAmount * Time.deltaTime;
            rectTransform.anchoredPosition = anchoredPosition;

            eular.z += eularSpeed * Time.deltaTime;
            transform.localEulerAngles = eular;

            if(anchoredPosition.y < minimumY)
            {
                Destroy(transform.gameObject);
                return true;
            }
            else
            {
                return false;
            }
        }//Updateeeee
    }


    private void SpawnConfetti()
    {
        i = Random.Range(0, pfConfetti.Length);
        float width = transform.GetComponent<RectTransform>().rect.width;
        float height = transform.GetComponent<RectTransform>().rect.height;
        Vector2 anchoredPosition = new Vector2(Random.Range(-width / 2f, width / 2f), height / 2f);
        //Color color = colorArray[Random.Range(0, colorArray.Length)];
        Cofetti cofetti = new Cofetti(pfConfetti[i], transform, anchoredPosition, -height / 2f);
        cofettiList.Add(cofetti);
    }




    private void Update()
    {
        foreach (Cofetti cofetti in new List<Cofetti>(cofettiList))
        {
            if (cofetti.Update())
            {
                cofettiList.Remove(cofetti);
            }
        }
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {

            spawnTimer += SPAWN_TIME_MAX;
            int spawnAmount = Random.Range(1, 4);
            for (int i = 0; i < spawnAmount; i++)
            {

                SpawnConfetti();
            }
        }
    }
    #endregion
}//EndClasssss
