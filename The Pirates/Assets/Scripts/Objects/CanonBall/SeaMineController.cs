using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeaMineDirection
{
    UP,
    DOWN
}

public class SeaMineController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public SeaMineDirection direction;
    public GameObject explosionsPrefabs;
    public Sprite[] sprites;
    public int power;
    #endregion

    #region Private Variables
    private bool isFired = false;
    private int initPower;
    Vector3 move = Vector3.down;
    [SerializeField] private SpriteRenderer spRender;

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
	{
        initPower = power;
        StartCoroutine(SeaMine());
        if (sprites.Length > 1)
        {
            spRender.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        }

        if (direction == SeaMineDirection.DOWN)
        {
          move =  Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
	}//Starttttt


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        Instantiate(explosionsPrefabs, transform.position, Quaternion.identity);
        initPower = power;
        gameObject.SetActive(false);
    }
    IEnumerator SeaMine()
    {
        isFired = true;
        float Fire = Random.Range(0.5f, 0.9f);
        yield return new WaitForSeconds(Fire);
        move = Vector3.zero;
        StartCoroutine(Timer());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("junkcandy"))
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
    }//Updateeeee

    #endregion
}//EndClasssss
