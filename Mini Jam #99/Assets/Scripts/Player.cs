using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float setSpeed;
    public float flapForce;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool started;
    public Animator Anim;
    public ObstacleSpawner obstSpawner;
    public GameObject obstSpawnerObject;
    public GameObject gameOverMenu;
    public bool gameOver;
    public GameObject obstHolder;
    public GameObject startPlaceAmbience;
    public GameObject playingMusic;
    public GameObject startMenu;
    public Parallax[] parallax;
    public GameObject defaultCloudHolder;
    public GameObject DefaultClouds;
    public DifficultyScaling difficultyScaling;
    public float trailTime;
    public float setTrailTime;
    public GameObject trailObj;
    public GameObject flappedObj;
    public GameObject trailHolder;
    public ParticleSystem feathers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        started = false;
        rb.simulated = false;
        gameOverMenu.SetActive(false);
        obstSpawnerObject.SetActive(true);
        gameOver = false;
        obstHolder.SetActive(true);
        startPlaceAmbience.SetActive(true);
        startMenu.SetActive(true);
        speed = setSpeed;
        playingMusic.SetActive(false);
        trailTime = speed * 0.02f;
        setTrailTime = trailTime;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCounter.score = ((int)(transform.position.x - 61.425));
        if (started)
        {
            float newX = transform.position.x + speed * Time.deltaTime;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            rb.simulated = true;
            Anim.SetBool("Started", true);
            if (transform.rotation.z > -30)
            {
                transform.eulerAngles -= new Vector3(0f, 0f, 35 * Time.deltaTime);
            }
            startPlaceAmbience.SetActive(false);
            startMenu.SetActive(false);
            playingMusic.SetActive(true);
        }



        if (Input.GetKeyDown(KeyCode.Space) && gameOver == false)
        {
            started = true;
            obstSpawner.started = true;
            rb.velocity = Vector2.up * flapForce;
            transform.eulerAngles = new Vector3(0f, 0f, 25f);
            FindObjectOfType<AudioManager>().Play("Flap");
            Instantiate(flappedObj, transform.position, Quaternion.Euler(0, 0, 45), trailHolder.transform);
        }

        trailTime -= Time.deltaTime;
        if (trailTime <= 0)
        {
            Instantiate(trailObj, transform.position, transform.rotation, trailHolder.transform);
            trailTime = setTrailTime;
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver == true)
        {
            ResetGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        
        Time.timeScale = 0;
        FindObjectOfType<AudioManager>().Play("Died");
        sr.color = new Color(255f, 255f, 255f, 0);
        started = false;
        obstSpawner.started = false;
        gameOverMenu.SetActive(true);
        obstSpawnerObject.SetActive(false);
        gameOver = true;
        feathers.Emit(4);
    }

    void ResetGame()
    {
        obstSpawner.started = false;
        obstSpawnerObject.SetActive(true);
        gameOverMenu.SetActive(false);
        started = false;
        Time.timeScale = 1;
        gameOver = false;
        transform.position = new Vector3(61.425f, 2.302f, 0);
        rb.simulated = false;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        foreach (Transform child in obstHolder.transform)
        {
            Destroy(child.gameObject);
        }
        Anim.SetBool("Started", false);
        startPlaceAmbience.SetActive(true);
        startMenu.SetActive(true);
        for (int i = 0; i < parallax.Length; i++)
        {
            parallax[i].transform.position = new Vector3(parallax[i].startPos * parallax[i].parallaxEffect, parallax[i].transform.position.y, parallax[i].transform.position.z);
        }

        if (defaultCloudHolder.transform.childCount == 0)
        {
            Instantiate(DefaultClouds, new Vector3(71.19187f, 4.281054f, -15f), Quaternion.identity, defaultCloudHolder.transform);
        }
        difficultyScaling.ResetDifficulty();
        playingMusic.SetActive(false);
        foreach (Transform child in trailHolder.transform)
        {
            Destroy(child.gameObject);
        }
        sr.color = new Color(255f, 255f, 255f, 1);
        feathers.Clear();
    }
}
