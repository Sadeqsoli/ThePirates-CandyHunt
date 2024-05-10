using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireBallDirection
{
    UP,
    DOWN
}

public class FireBallController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float hSpeed; //horizontal speed
    public FireBallDirection direction;
    public GameObject explosionsPrefabs;
    public int power;
    #endregion

    #region Private Variables
    private Vector3 move = Vector3.down;
    private int initPower;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
	{
        initPower = power;
        StartCoroutine(ExplosionFireBall());
        if (direction == FireBallDirection.DOWN)
        {
          move =  Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
	}//Starttttt



    IEnumerator ExplosionFireBall()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
        initPower = power;
        gameObject.SetActive(false);
    }

    private void CheckBallOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("junkcandy") &&  power > 0)
        {
            StartCoroutine(ExplosionFireBall());
        }
        if (collision.CompareTag("junkcandy") && power <= 0)
        {
            Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("e_simpleBall") || collision.gameObject.CompareTag("simpleBal"))
        {
            initPower -= collision.gameObject.GetComponent<BulletController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("e_clusterBall") || collision.gameObject.CompareTag("clusterBall"))
        {
            initPower -= collision.gameObject.GetComponent<ClusterController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("e_littleClusterBall") || collision.gameObject.CompareTag("littleClusterBall"))
        {
            initPower -= collision.gameObject.GetComponent<LittleClusterController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("e_seaMine") || collision.gameObject.CompareTag("seaMine"))
        {
            initPower -= collision.gameObject.GetComponent<SeaMineController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("e_chaseBall") || collision.gameObject.CompareTag("chaseBall"))
        {
            initPower -= collision.gameObject.GetComponent<ChaseBallController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("e_crazyBall") || collision.gameObject.CompareTag("crazyBall"))
        {
            initPower -= collision.gameObject.GetComponent<CrazyBallController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("e_fireBall") || collision.gameObject.CompareTag("fireBall"))
        {
            initPower -= collision.gameObject.GetComponent<FireBallController>().power;
            CheckPower();
        }
        else
        {
            Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
            initPower = power;
            gameObject.SetActive(false);
        }
        
    }

    private void CheckPower()
    {
        if (initPower <= 0)
        {
            Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
            initPower = power;
            gameObject.SetActive(false);
        }
    }
    



    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
        CheckBallOutOfBounds();
    }//Updateeeee
    #endregion
}//EndClasssss
