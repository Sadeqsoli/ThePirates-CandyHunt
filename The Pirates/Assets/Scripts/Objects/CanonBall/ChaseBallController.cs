using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChaseBallDirection
{
    UP,
    DOWN
}

public class ChaseBallController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public GameObject explosionsPrefabs;
    public Sprite[] sprites;
    public int power;
    public ChaseBallDirection direction;
    #endregion

    #region Private Variables
    [SerializeField] private SpriteRenderer spRender;
    private Transform enemy;
    private Transform player;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    void Start()
	{
        if (sprites.Length > 1)
        {
            spRender.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        }
    }//Starttttt



    private void ChooseDirection()
    {
        if (direction == ChaseBallDirection.DOWN)
        {
            ChasePlayer();
        }
        else
        {
            ChaseEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("junkcandy"))
        {
            Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void ChaseEnemy()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy_ship").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position,
            enemy.transform.position, Time.deltaTime * speed);
    }
    private void ChasePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position,
            player.transform.position, Time.deltaTime * speed);
    }



    void Update()
    {
        ChooseDirection();
        //transform.Translate( move * speed * Time.deltaTime);
    }//Updateeeee
    #endregion
}//EndClasssss
