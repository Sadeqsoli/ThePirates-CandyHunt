using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildShipSpawner : MonoBehaviour
{
    #region Public Variables
    public GameObject childShipPrefabs;
    public Vector2 shipToSpawn;
    public Vector2 timeToSpawn;

    #endregion

    #region Private Variables

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
    {
        StartCoroutine(Spawn());
    }//Starttttt





    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x, timeToSpawn.y));
        Vector3 pos = transform.position;
        int countOfShipToSpawn = (int)Random.Range(shipToSpawn.x, shipToSpawn.y);
        for (int i = 0; i < countOfShipToSpawn; i++)
        {
            Instantiate(childShipPrefabs, transform.position , Quaternion.identity);
        }
        StartCoroutine(Spawn());
    }





    void Update()
    {


    }//Updateeeee

    #endregion
}//EndClasssss
