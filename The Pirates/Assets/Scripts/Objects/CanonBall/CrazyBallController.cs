using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrazyBallDirection
{
    UP,
    DOWN
}

public class CrazyBallController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float hSpeed;
    public CrazyBallDirection direction;
    public GameObject explosionsPrefabs;
    public Sprite[] sprites;
    public int power;
    #endregion

    #region Private Variables
    [SerializeField] private SpriteRenderer spRender;
    private int directionX = 0;
    Vector3 move1 = Vector3.down;
    private Transform enemy;
    private int initPower;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
	{
        initPower = power;
        StartCoroutine(ExplosionCrazyBall());
        if (sprites.Length > 1)
        {
            spRender.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        }
        InvokeRepeating("ChangeDirection", 0.3f, 0.1f);
        
	}//Starttttt

    IEnumerator ExplosionCrazyBall()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
        initPower = power;
        gameObject.SetActive(false);
    }
    private void ChangeDirection()
    {
        directionX = Random.Range(-1, 2); // -1 , 0 , 1
    }
    private void CheckBallOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -3, 3);
        if (pos.x >= 3 || pos.x <= -3)
        {
            Invoke("ChangeDirection", 0.0001f);
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
        
        if (direction == CrazyBallDirection.DOWN)
        {
            move1 = Vector3.down;
            Vector3 move = Vector3.down;
            move.x = directionX * hSpeed;
            move.y = move.y * speed;
            transform.position += move * Time.deltaTime;

        }
        else
        {
            move1 = Vector3.up;
            Vector3 move = Vector3.up;
            move.x = directionX * hSpeed;
            move.y = move.y * speed;
            transform.position += move * Time.deltaTime;
        }
        
        
        CheckBallOutOfBounds();
    }//Updateeeee 

    #endregion

}//EndClasssss
