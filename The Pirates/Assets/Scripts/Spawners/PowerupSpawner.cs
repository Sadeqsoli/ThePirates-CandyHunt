using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    #region Public Variables
    public GameObject[] puPrefabs;
    public Vector2 timeToSpawn;
    public Vector2 xAxisLimitToSpawn;
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
        pos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);
        int rnd = Random.Range(0, puPrefabs.Length);
        Instantiate(puPrefabs[rnd], pos, Quaternion.identity);
        StartCoroutine(Spawn());
    }





    void Update()
    {


    }//Updateeeee

    #endregion
}//EndClasssss
