using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    #region Public Variables
    public Vector2 coinToSpawn;
    public GameObject coinPrefab;
    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
    {
        int countOfCoinToSpawn = (int) Random.Range(coinToSpawn.x, coinToSpawn.y);
        for (int i = 0; i < countOfCoinToSpawn; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);   
        }
        Destroy(gameObject);
    }//Starttttt





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
