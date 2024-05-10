using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerdown_triplechildship : MonoBehaviour
{
    #region Public Variables
    public GameObject pickupEffect;
    public GameObject trailEffect;
    public GameObject childship;
    public AudioClip clip;
    public AudioSource audioSource;
    public float duration = 4f;
    public JunkCandyController junkCandy;
    #endregion

    #region Private Variables
    private GameObject trail;
    #endregion

    #region Public Methods
    public void BeingShot(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("simpleBal"))
        {

            junkCandy.health -= collision.gameObject.GetComponent<BulletController>().power;
            Debug.Log("boom");
        }
        else if (collision.gameObject.CompareTag("clusterBall"))
        {
            junkCandy.health -= collision.gameObject.GetComponent<ClusterController>().power;
        }
        else if (collision.gameObject.CompareTag("littleClusterBall"))
        {
            junkCandy.health -= collision.gameObject.GetComponent<LittleClusterController>().power;
        }
        else if (collision.gameObject.CompareTag("seaMine"))
        {
            junkCandy.health -= collision.gameObject.GetComponent<SeaMineController>().power;
        }
        else if (collision.gameObject.CompareTag("chaseBall"))
        {
            junkCandy.health -= collision.gameObject.GetComponent<ChaseBallController>().power;
        }
        else if (collision.gameObject.CompareTag("crazyBall"))
        {
            junkCandy.health -= collision.gameObject.GetComponent<CrazyBallController>().power;
        }
        else if (collision.gameObject.CompareTag("fireBall"))
        {
            junkCandy.health -= collision.gameObject.GetComponent<FireBallController>().power;
        }
        junkCandy.CheckingHealth();
    }
    #endregion

    #region Private Methods
    void Start()
    {

    }//Starttttt


    private void OnTriggerEnter2D(Collider2D powerdown)
    {
        if (powerdown.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
            StartCoroutine(Pickup(powerdown));
        }
        BeingShot(powerdown);
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, new Vector3(0, 4, 0), transform.rotation);
        Instantiate(pickupEffect, new Vector3(4, 4, 0), transform.rotation);
        Instantiate(pickupEffect, new Vector3(-4, 4, 0), transform.rotation);
        //dynamic
        
        Instantiate(childship, new Vector3 (0,5,0), transform.rotation);
        Instantiate(childship, new Vector3(4, 5, 0), transform.rotation);
        Instantiate(childship, new Vector3(-4, 5, 0), transform.rotation);
        TrailSpawn();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        //dynamic
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

