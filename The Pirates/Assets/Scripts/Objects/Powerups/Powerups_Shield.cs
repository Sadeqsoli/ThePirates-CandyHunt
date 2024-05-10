using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups_Shield : MonoBehaviour
{
    #region Public Variables
    public GameObject pickupEffect;
    public GameObject shieldEffect;
    public GameObject trailEffect;
    public AudioClip clip;
    public AudioSource audioSource;
    public float duration = 4f;
    public bool isShieldActive = false;
    #endregion

    #region Private Variables
    private GameObject shield;
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
        Instantiate(pickupEffect, player.transform.position, player.transform.rotation);

        //dynamic
        if (isShieldActive == false)
        {

            ShieldSpawn();
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        //dynamic

        isShieldActive = true;
        Destroy(shield);
        Destroy(trail);
        Destroy(gameObject);
    }

    private void ShieldSpawn()
    {
        Transform ship = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shield = (GameObject)Instantiate(shieldEffect, ship.transform.position, ship.transform.rotation);
        trail = (GameObject)Instantiate(trailEffect, ship.transform.position, ship.transform.rotation);
        shield.transform.localPosition = ship.transform.localPosition;
        trail.transform.localPosition = ship.transform.localPosition + new Vector3 (0,-1,0);
        shield.transform.SetParent(ship.transform);
        trail.transform.SetParent(ship.transform);
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
