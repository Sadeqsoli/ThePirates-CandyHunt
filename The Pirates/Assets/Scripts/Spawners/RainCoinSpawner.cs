using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoinSpawner : MonoBehaviour
{
    #region Public Variables
    public Vector2 coinToSpawn;
    public Vector2 timeToSpawn;
    public Vector2 xAxisLimitToSpawn;
    public GameObject coinPrefab;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {
        StartCoroutine(RainCoin());
    }//Starttttt




    IEnumerator RainCoin()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x, timeToSpawn.y));
        Vector3 pos = transform.position;
        pos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);
        int countOfCoinToSpawn = (int)Random.Range(coinToSpawn.x, coinToSpawn.y);
        for (int i = 0; i < countOfCoinToSpawn; i++)
        {
            Instantiate(coinPrefab, pos, Quaternion.identity);
        }
        StartCoroutine(RainCoin());
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
