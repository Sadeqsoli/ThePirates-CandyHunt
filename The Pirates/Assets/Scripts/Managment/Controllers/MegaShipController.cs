using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaShipController : MonoBehaviour
{

    #region Public Variables
    public float fireRate ;
    public GameObject[] bullet;
    public GameObject BiG_EXprefab;
    public GameObject [] guns;
    public int Health { get { return _health; } }
    public int InitHealth { get { return _initHealth; } }
    //public Animator waveAnimator;
    #endregion

    #region Private Variables
    private int _initHealth = 4;
    private float speed ;
    [SerializeField] private int _health;
    private float lastShot = 0;
    private const string FLAME_ANIMATION = "speed";
    private float h;
    private float v;
    private int numOfBullets = 0;
    private GameController gameController;
    private EnemyShipController enemy;
    private List<GameObject> ballPooling;
    //private Transform enemy_ship;
    //private Transform player;
    //private bool isFiliped = false;
    #endregion

    #region Public Methods
    public int GetBulletFired()
    {
        return numOfBullets;
    }
    public void init(float _speed, float _fireRate, int _h)
    {
        speed = _speed;
        fireRate = _fireRate;
        _health = _h;
        _initHealth = _health; 
    }

    public void FireBullet()
    {
         Fire();
    }

    public void MoveUp()
    {
        v = 1;
    }
    public void MoveDown()
    {
        v = -1;
    }
    public void MoveRight()
    {
        h = 1;
    }
    public void MoveLeft()
    {
        h = -1;
    }
    public void StopMoving()
    {
        v = 0;
        h = 0;
    }

    public int GetHealthPercent()
    {
        if (_initHealth == _health) return 100;
        float currentHealth = _initHealth - _health;
        float p = (currentHealth - _initHealth ) / _initHealth * -100;
        return (int)p;
    }
    #endregion

    #region Private Methods
    private void Start()
    {
        ballPooling = new List<GameObject>();
        numOfBullets = 0;
        gameController = GameObject.FindObjectOfType<GameController>();
    }//Startttttt




    
    //private void RotateShipCanon()
    //{
        //enemy_ship = GameObject.FindGameObjectWithTag("enemy_ship").GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //if (enemy_ship.transform.position.y < player.transform.position.y && isFiliped == false)
        //{
        //    bulletController.direction = BulletDirection.UP;
        //    player.transform.localScale *= -1;
        //    isFiliped = true;
        //}
        //else if(enemy_ship.transform.position.y > player.transform.position.y && isFiliped == true)
        //{
        //    bulletController.direction = BulletDirection.DOWN;
        //    player.transform.localScale *= -1;
        //    isFiliped = false;
        //}
    //}

    private void CheckInputKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopMoving();
        }
    }


    private void BallPooling(Vector3 pos , GameObject[] bullets)
    {
        bool find = false;
        for (int i = 0; i < ballPooling.Count && find == false; i++)
        {
            if (!ballPooling[i].activeInHierarchy)
            {
                ballPooling[i].SetActive(true);
                ballPooling[i].transform.position = pos;
                find = true;
            }
        }
        if (find == false)
        {
            int bulletColor = Random.Range(0, bullet.Length);
            GameObject ball = Instantiate(bullets[bulletColor], pos, Quaternion.identity) as GameObject;
            ballPooling.Add(ball);
        }
    }
    private void Fire()
    {
        if (Time.time > fireRate + lastShot && gameController.HasBullet())
        {
            int choose = Random.Range(1, guns.Length);
            for (int i = 0; i < choose; i++)
            {
                numOfBullets += 1;
                //Instantiate(bullet[bulletColor], guns[i].transform.position, Quaternion.identity);
                BallPooling(guns[i].transform.position, bullet);
                gameController.PopBullet();
            }
            lastShot = Time.time;
        }  
    }
    private void CheckShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -8f, 8f),
                    Mathf.Clamp(transform.position.y, -4f, 3f),
                    transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("e_simpleBall"))
        {
            _health -= collision.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("e_clusterBall"))
        {
            _health -= collision.gameObject.GetComponent<ClusterController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("e_littleClusterBall"))
        {
            _health -= collision.gameObject.GetComponent<LittleClusterController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("e_seaMine"))
        {
            _health -= collision.gameObject.GetComponent<SeaMineController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("e_chaseBall"))
        {
            _health -= collision.gameObject.GetComponent<ChaseBallController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("e_crazyBall"))
        {
            _health -= collision.gameObject.GetComponent<CrazyBallController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("e_fireBall"))
        {
            _health -= collision.gameObject.GetComponent<FireBallController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("junkcandy"))
        {

            _health -= collision.gameObject.GetComponent<JunkCandyController>().health;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("powerups"))
        {
            
            if (InitHealth != _health)
            {
                _health += collision.gameObject.GetComponent<PUController>().health;
                CheckHealth();
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {

            _health -= collision.gameObject.GetComponent<EnemyShipController>().initPower;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("child_ship"))
        {

            _health -= collision.gameObject.GetComponent<EnemyShipCrosser>().initPower;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("megaEnemy"))
        {

            _health -= collision.gameObject.GetComponent<MegaEnemyShipController>().initPower;
            CheckHealth();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin")){

            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<CoinController>().DestroyIt();
            gameController.AddCoins();
        }
        if (collision.CompareTag("raincoin"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<RainCoinController>().DestroyIt();
            gameController.AddCoins();
        }
        if (collision.CompareTag("powerups"))
        {
            gameController.AddPowerups();
        }
    }

    private void CheckHealth()
    {
        
        //TODO : Need Improvement
        if(Health <= 0)
        {
            Instantiate(BiG_EXprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(GameoverPopup());
        }
    }
    private IEnumerator GameoverPopup()
    {
        yield return new WaitForSeconds(2);
        gameController.GameOver();
    }






    private void Update()
    {
        enemy = GameObject.FindObjectOfType<EnemyShipController>();
        CheckShipOutOfBounds();
        CheckInputKeyboard();
        Vector3 move = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position += move;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        //RotateShipCanon();
        //waveAnimator.SetFloat(FLAME_ANIMATION, move.sqrMagnitude);

    }//Updateeee
    #endregion


}//EndClasssssss
