using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaEnemyShipController : MonoBehaviour
{
    #region Public Variables
    public float hSpeed;
    public int initPower;
    public GameObject BiG_EXprefab;
    public GameObject EnemyShip;
    public SpriteRenderer healthBar;
    public GameObject[] enemy_Bullet;
    public GameObject[] guns;
    #endregion

    #region Private Variables
    private GameController gameController;
    [SerializeField] private int power;
    private float moveY; 
    private Vector3 healthScale;
    private Transform player;
    private Transform enemy;
    private List<GameObject> eBallPooling;
    //private BulletController bullet;
    //private bool isFiliped = false;
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods
    void Start()
    {
        eBallPooling = new List<GameObject>();
        initPower = power;
        healthScale = healthBar.transform.localScale;
        gameController = GameObject.FindObjectOfType<GameController>();
        InvokeRepeating("ChangeDirection", 0.1f, 1f);
        InvokeRepeating("Fire", 2, 2f);
    }//Starttttt

    private void CheckEnemyShipOutOfBounds()
    {
        float yLine = Random.Range(-0.6f, -3f);
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -8f, 8f),
                    transform.position.y,
                    transform.position.z);
    }
    private void FollowShip()
    {
        enemy = transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy.position = Vector3.MoveTowards(enemy.position , new Vector3( player.position.x, moveY , 0)
        , Time.deltaTime * hSpeed);
    }
    private void ChangeDirection()
    {
        moveY = Random.Range(-1f, 4);
    }

    private void BallPooling(Vector3 pos, GameObject[] bullets)
    {
        bool find = false;
        for (int i = 0; i < eBallPooling.Count && find == false; i++)
        {
            if (!eBallPooling[i].activeInHierarchy)
            {
                eBallPooling[i].SetActive(true);
                eBallPooling[i].transform.position = pos;
                find = true;
            }
        }
        if (find == false)
        {
            int bulletColor = Random.Range(0, enemy_Bullet.Length);
            GameObject ball = Instantiate(bullets[bulletColor], pos, Quaternion.identity) as GameObject;
            eBallPooling.Add(ball);
        }
    }
    private void Fire()
    {
        int choose = Random.Range(0, guns.Length);
        for (int i = 0; i <= choose; i++)
        {
            //Instantiate(enemy_Bullet[bulletColor], guns[i].transform.position, Quaternion.identity);
            BallPooling(guns[i].transform.position, enemy_Bullet);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("simpleBal"))
        {

            initPower -= collision.gameObject.GetComponent<BulletController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("clusterBall"))
        {
            initPower -= collision.gameObject.GetComponent<ClusterController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("littleClusterBall"))
        {
            initPower -= collision.gameObject.GetComponent<LittleClusterController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("seaMine"))
        {
            initPower -= collision.gameObject.GetComponent<SeaMineController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("chaseBall"))
        {
            initPower -= collision.gameObject.GetComponent<ChaseBallController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("crazyBall"))
        {
            initPower -= collision.gameObject.GetComponent<CrazyBallController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("fireBall"))
        {
            initPower -= collision.gameObject.GetComponent<FireBallController>().power;
            CheckPower();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            initPower -= collision.gameObject.GetComponent<ShipController>().Health;
            CheckPower();
        }

    }
    private void CheckPower()
    {
        UpdateHealthBar();
        if (initPower <= 0)
        {
            initPower = power;
            healthBar.transform.localScale = new Vector3(5.2f, 3.5f, 1);
            healthBar.material.color = Color.green;
            gameController.AddScore(power);
            gameController.AddDestroyedItems(gameObject.tag);
            Instantiate(BiG_EXprefab, transform.position, Quaternion.identity);
            float instX = Random.Range(-8f, 8f);
            Instantiate(EnemyShip, new Vector3(instX, 7, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void UpdateHealthBar()
    {
        float colorChange = 1 - (float)initPower * 0.001f;
        healthBar.material.color = Color.Lerp(Color.green, Color.red, colorChange);

        //float scaleX = (float)power / healthScale.x * 0.001f;
        healthBar.transform.localScale = new Vector3(5.2f, 3.5f, 1);
    }





    void Update()
    {
        FollowShip();
        CheckEnemyShipOutOfBounds();


    }//Updateeeee

    #endregion

}//EndClasssss
