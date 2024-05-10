using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups_Magnet : MonoBehaviour
{
    #region Public Variables
    public GameObject pickupEffect;
    public GameObject rainCoinSpawner;
    public GameObject trailEffect;
    public RainCoinController rainCoin;
    public CoinController coin;
    public AudioClip clip;
    public AudioSource audioSource;
    public float multiplier2 = 2;
    public float duration = 4f;
    #endregion

    #region Private Variables
    private GameObject trail;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {

    }//Starttttt



    private void OnTriggerEnter2D(Collider2D powerup)
    {
        if (powerup.CompareTag("Player")){

            audioSource.PlayOneShot(clip);
            StartCoroutine( Pickup(powerup));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        rainCoin.hasMagnet = true;
        coin.hasMagnet = true;
        Instantiate(pickupEffect, player.transform.position, player.transform.rotation);
        
        //dynamic
        GameObject spawner = Instantiate(rainCoinSpawner, new Vector3(0, 7, 0), transform.rotation);
        coin.speed *= multiplier2;
        rainCoin.speed *= multiplier2;
        TrailSpawn();


        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        //dynamic
        coin.speed /= multiplier2;
        rainCoin.speed /= multiplier2;
        coin.hasMagnet = false;
        rainCoin.hasMagnet = false;
        Destroy(spawner);
        Destroy(trail);
        Destroy(gameObject);
    }

    private void TrailSpawn()
    {
        Transform ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        trail = (GameObject)Instantiate(trailEffect, ship.transform.position, ship.transform.rotation);
        trail.transform.localPosition = ship.transform.localPosition + new Vector3(0, -1, 0);
        trail.transform.SetParent(ship.transform);
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
