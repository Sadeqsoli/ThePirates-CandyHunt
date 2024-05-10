using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    #region Public Variables
    public float hSpeed;
    public GameObject enemy_Bullet;
    public GameObject[] guns;
    public int initPower;
    public GameObject BiG_EXprefab;
    public GameObject EnemyShip;
    public SpriteRenderer healthBar;
    #endregion

    #region Private Variables
    private GameController gameController;
    private float moveY;
    [SerializeField] private int power;
    private Vector3 healthScale;
    private Transform player;
    private Transform enemy;
    private List<GameObject> eballPooling;
    //private BulletController bullet;
    //private bool isFiliped = false;
    #endregion

    #region Public Methods
    //public int GetPowerPercent()
    //{
    //    if (initPower == power) return 100;

    //    float currentPower = power - initPower;
    //    float p = (currentPower - power) / initPower * -100;
    //    return (int)p;
    //}
    #endregion

    #region Private Methods
    void Start()
    {
        eballPooling = new List<GameObject>();
        initPower = power;
        healthScale = healthBar.transform.localScale;
        gameController = GameObject.FindObjectOfType<GameController>();
        InvokeRepeating("ChangeDirection", 0.1f, 1f);
        InvokeRepeating("Fire", 2, 2f);
    }//Starttttt

    private void CheckEnemyShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -8f, 8f),
                    transform.position.y,
                    transform.position.z);
    }
    private void FollowShip()
    {
        enemy = transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy.position = Vector3.MoveTowards(enemy.position , new Vector3( player.position.x, moveY, 0)
        , Time.deltaTime * hSpeed);
    }

    private void ChangeDirection()
    {
        moveY = Random.Range(-1f, 4);
    }

    private void EBallPooling(Vector3 pos)
    { 
        bool find = false;
        for (int i = 0; i < eballPooling.Count && find == false; i++)
        {
            if (!eballPooling[i].activeInHierarchy)
            {
                eballPooling[i].SetActive(true);
                eballPooling[i].transform.position = pos;
                find = true;
            }
        }
        if (find == false)
        {
            GameObject ball = Instantiate(enemy_Bullet, pos, Quaternion.identity) as GameObject;
            eballPooling.Add(ball);
        }
    }
    private void Fire()
    {
        int choose = Random.Range(0, guns.Length);
        for (int i = 0; i <= choose; i++)
        {
            //Instantiate(enemy_Bullet, guns[i].transform.position, Quaternion.identity);
            EBallPooling(guns[i].transform.position);
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
        else if (collision.gameObject.CompareTag("megaPlayer"))
        {
            initPower -= collision.gameObject.GetComponent<MegaShipController>().Health;
            CheckPower();
        }

    }

    private void CheckPower()
    {
        UpdateHealthBar();
        if (initPower <= 0)
        {
            initPower = power;
            healthBar.transform.localScale = new Vector3 (5.2f,3.5f,1);
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
        healthBar.transform.localScale = new Vector3(5.2f , 3.5f, 1);
    }





    void Update()
    {
        FollowShip();
        CheckEnemyShipOutOfBounds();
    }//Updateeeee

    #endregion

}//EndClasssss
