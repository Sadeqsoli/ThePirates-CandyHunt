using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups_PlusBullet : MonoBehaviour
{
    #region Public Variables
    public GameObject pickupEffect;
    public GameObject trailEffect;
    public AudioClip clip;
    public AudioSource audioSource;
    public float duration;
    public int plus10 = 10;
    #endregion

    #region Private Variables
    private GameController gameController;
    private HUDBulletManager hudBullet;
    private GameObject trail;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {

    }//Starttttt




    private void OnCollisionEnter2D(Collision2D powerup)
    {
        if (powerup.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
            StartCoroutine(Pickup(powerup));
        }
    }

    IEnumerator Pickup(Collision2D player)
    {
        Instantiate(pickupEffect, player.transform.position, player.transform.rotation);
        //dynamic

        gameController = GameObject.FindObjectOfType<GameController>();
        hudBullet = GameObject.FindObjectOfType<HUDBulletManager>();
        int s = gameController.bullet += plus10;
        hudBullet.SetBullet(s);
        TrailSpawn();



        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
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

