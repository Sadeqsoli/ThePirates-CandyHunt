using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LittleClusterDirection
{
    UP,
    DOWN
}
public class LittleClusterController : MonoBehaviour
{
    #region Public Variables
    public GameObject explosionsPrefabs;
    public int power;
    public LittleClusterDirection direction;
    #endregion

    #region Private Variables
    private Vector2 randomXDirection;
    private float speed;
    #endregion

    #region Public Methods


    #endregion

    #region Private Methods
    void Start()
    {
        if (direction == LittleClusterDirection.DOWN)
        {
            randomXDirection = Vector3.down;
        }
        else
        {
            randomXDirection = Vector3.up;
        }

        randomXDirection.x = Random.Range(-4f, 4f);
        speed = Random.Range(4, 6);
    }//Starttttt


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("junkcandy"))
        {
            Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    void Update()
    {
        transform.Translate(randomXDirection * speed * Time.deltaTime);
        
    }//Updateeeee

    #endregion
}//EndClasssss
