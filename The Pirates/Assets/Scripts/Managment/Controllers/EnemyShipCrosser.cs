using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCrosser : MonoBehaviour
{
    #region Public Variables
    public float vSpeed; 
    public float hSpeed; 
    public GameObject bulletPrefab;
    public Vector2 timeToFire;
    public GameObject[] guns;
    public int initPower;
    public GameObject explosionPrefab;
    #endregion

    #region  Private Variables
    private int direction = 0; // 1 => right , -1 => left , 0 
    private GameController gameController;
    [SerializeField] private int power;
    private List<GameObject> eeBallPooling;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        eeBallPooling = new List<GameObject>();
        initPower = power;
        gameController = GameObject.FindObjectOfType<GameController>();
        InvokeRepeating("ChangeDirection", 1, 0.5f);
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
    }//Startttttt


    private void CheckShipOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -8, 8);
        transform.position = pos;
        if(pos.x >= 8 || pos.x <= -8)
        {
            Invoke("ChangeDirection", 0.0001f);
        }
    }
    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2); // -1 , 0 , 1
    }

    private void EBallPooling(Vector3 pos)
    {
        bool find = false;
        for (int i = 0; i < eeBallPooling.Count && find == false; i++)
        {

            if (!eeBallPooling[i].activeInHierarchy)
            {
                eeBallPooling[i].SetActive(true);
                eeBallPooling[i].transform.position = pos;
                find = true;
            }
        }
        if (find == false)
        {
            GameObject ball = Instantiate(bulletPrefab, pos, Quaternion.identity) as GameObject;
            eeBallPooling.Add(ball);
        }
    }
    private void Fire()
    {
        int choose = Random.Range(0, guns.Length);
        for (int i = 0; i <= choose; i++)
        {
            //Instantiate(bulletPrefab, guns[i].transform.position, Quaternion.identity);
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
        if (initPower <= 0)
        {
            initPower = power;
            gameController.AddScore(power);
            gameController.AddDestroyedItems(gameObject.tag);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * hSpeed;
        move.y = move.y * vSpeed;
        transform.position += move * Time.deltaTime;
        CheckShipOutOfBounds();
    }
    #endregion
}//EndClasssss
