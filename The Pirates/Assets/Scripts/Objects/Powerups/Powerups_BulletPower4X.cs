using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups_BulletPower4X : MonoBehaviour
{
    #region Public Variables
    public GameObject pickupEffect;
    public GameObject trailEffect;
    public AudioClip clip;
    public AudioSource audioSource;
    public BulletController bullet;
    public float duration = 4f;
    public int multiplier4 = 4;
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
        Instantiate(pickupEffect, transform.position , transform.rotation);
        //dynamic
        bullet.power *= multiplier4;
        TrailSpawn();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        //dynamic
        bullet.power /= multiplier4;
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
