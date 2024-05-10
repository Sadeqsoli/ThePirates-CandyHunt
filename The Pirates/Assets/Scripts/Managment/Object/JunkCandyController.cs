using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCandyController : MonoBehaviour
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
    public void CheckingHealth()
    {
        CheckHealth();
    }
    #endregion

    #region Private Methods
    private void Awake()
    {
        health = Random.Range(health1, health2);
        InitalHealth = health;
        gameController = GameObject.FindObjectOfType<GameController>();
        speed = Random.Range(speed1, speed2);
        rotationSpeed = Random.Range(rotation1, rotation2);
    }



    void CheckHealth()
    {
        if (health <= 0)
        {
            gameController.AddScore(InitalHealth);
            gameController.AddDestroyedItems(gameObject.tag);
            int rnd = Random.Range(1, 4);
            if(rnd % 2 == 0)
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
