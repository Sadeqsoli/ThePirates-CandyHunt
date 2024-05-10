using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUController : MonoBehaviour
{
    #region Public Variables
    public float speed1, speed2;
    public float rotation1, rotation2;
    public int health1, health2;
    public GameObject BigEX_Prefab;
    public GameObject coinSpawner;
    public int health;
    #endregion

    #region Private Variables
    private float speed;
    private float rotationSpeed;
    private int InitalHealth;
    private GameController gameController;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void Awake()
    {
        health = Random.Range(health1, health2);
        InitalHealth = health;
        gameController = GameObject.FindObjectOfType<GameController>();
        speed = Random.Range(speed1, speed2);
        rotationSpeed = Random.Range(rotation1, rotation2);
    }//Awakeeeee



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("simpleBal") || col.gameObject.CompareTag("clusterBall") || col.gameObject.CompareTag("littleClusterBall") ||
            col.gameObject.CompareTag("seaMine") || col.gameObject.CompareTag("chaseBall") || col.gameObject.CompareTag("crazyBall") ||
            col.gameObject.CompareTag("fireBall"))
        {
            CheckHealth();
        }
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            gameController.AddScore(InitalHealth);
            int rnd = Random.Range(1, 4);
            if (rnd % 2 == 0)
            {
                Instantiate(coinSpawner, transform.position, Quaternion.identity);
            }
            Instantiate(BigEX_Prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }//Updateeeee

    #endregion
}//EndClasssss
