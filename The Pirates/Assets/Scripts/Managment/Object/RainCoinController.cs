using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoinController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public AudioClip[] clips;
    public AudioSource audioSource;
    public bool hasMagnet = false;
    public float dist = 500f;
    #endregion

    #region Private Variables
    private AudioClip clip;
    private Vector2 randomXDirection;
    private Transform player;
    #endregion

    #region Public Methods
    public void DestroyIt()
    {
        StartCoroutine(DestroyAfterSound());
        //Invoke ("",clip.lenght);
    }
    #endregion

    #region Private Methods
    void Start()
    {
        clip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip);
        randomXDirection = Vector2.up;
        randomXDirection.x = Random.Range(-4f, 4f);
        Invoke("GoDown", 0.1f);
    }//Starttttt



    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }
    private void GoDown()
    {
        randomXDirection.y *= -1;
        randomXDirection.x = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

    private void FollowShip()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (hasMagnet == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < dist)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
            }
        }
    }

    void Update()
    {
        transform.Translate(randomXDirection * speed * Time.deltaTime);
        FollowShip();
    }//Updateeeee
    #endregion
}//EndClasssss
