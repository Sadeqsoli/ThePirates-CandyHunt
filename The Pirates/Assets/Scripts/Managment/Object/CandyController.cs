using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    #region Public Variables
    public float speed ;
    public int health;
    public GameObject BigEX_Prefab;
    public GameObject sparkFX;
    public GameObject coinSpawner;
    public AudioSource audioSource;
    public AudioClip clip;
    #endregion

    #region Private Variables
    private GameController gameController;
    private int InitalHealth;
    private float rotationSpeed;
    #endregion

    #region Public Methods
    public void EatCandy()
    {
        StartCoroutine(EatCandyAfterSound());
    }
    #endregion

    #region Private Methods
    private void Awake()
    {
        InitalHealth = health;
        gameController = GameObject.FindObjectOfType<GameController>();
        rotationSpeed = Random.Range(-360f, 360f);
    }//Awakeeeee



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("simpleBal"))
        {
            health -= collision.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("clusterBall"))
        {
            health -= collision.gameObject.GetComponent<ClusterController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("littleClusterBall"))
        {
            health -= collision.gameObject.GetComponent<LittleClusterController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("seaMine"))
        {
            health -= collision.gameObject.GetComponent<SeaMineController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("chaseBall"))
        {
            health -= collision.gameObject.GetComponent<ChaseBallController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("crazyBall"))
        {
            health -= collision.gameObject.GetComponent<CrazyBallController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("fireBall"))
        {
            health -= collision.gameObject.GetComponent<FireBallController>().power;
            CheckHealth();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
            StartCoroutine(EatCandyAfterSound());
        }
        
    }
    private void CheckHealth()
    {
        if(health <= 0)
        {
            Instantiate(BigEX_Prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private IEnumerator EatCandyAfterSound()
    {
        yield return new WaitForSeconds(clip.length);
        gameController.AddCandy();
        gameController.AddScore(InitalHealth);
        int rnd = Random.Range(1, 4);
        if (rnd % 2 == 0)
        {
            Instantiate(coinSpawner, transform.position, Quaternion.identity);
        }
        Instantiate(sparkFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }//Updateeeee

    #endregion
}//EndClasssss
