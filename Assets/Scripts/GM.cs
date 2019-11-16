using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    private float time;
    private float spawnTime;
    private float searchCountdown = 15f;

    public GameObject heart1, heart2, heart3;
    public GameObject player;
    public GameObject heart;
    public GameObject aliveSprite;
    public Image gameOver;
    public Text scoreText;
    public float minTime = 30f;
    public float maxTime = 60f;
    public float delay = 1f;
    public static int health;
    public static int score;
    public static GM instance = null;

    void Awake()
    {   
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        Instantiate(player, new Vector3(-6f, -12.5f, 0f), Quaternion.identity);
        Instantiate(aliveSprite, new Vector3(0.1f, -12.5f, 0f), Quaternion.identity);

        score = 0;
        UpdateScore();

        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

        SetRandomTime();
        time = minTime;
    }

    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0.25f;
                Invoke("GameOver", delay);
                break;
        }
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            if (!IsHeartAvailable())
            {
                SpawnObject();
                SetRandomTime();
            } else
            {
                return;
            }
        }
    }

    bool IsHeartAvailable()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectWithTag("Heart") == null)
                return false;
        }

        return true;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void UpdateScore()
    {
        if (score == 0)
            scoreText.text = "000" + score.ToString();
        else if (score < 1000)
            scoreText.text = "0" + score.ToString();
        else
            scoreText.text = score.ToString();
    }

    public void KillEnemy()
    {
        if (SpawnManager.waveCount < 20)
            score += 100;
        else if (SpawnManager.waveCount >= 20)
            score += 200;
    }

    public void HurtPlayer()
    {
        health -= 1;
    }

    public void AddHealth()
    {
        health += 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBullet bullet = GetComponent<EnemyBullet>();

        if (bullet != null)
        {
            HurtPlayer();
        }
    }

    void SpawnObject()
    {
        time = 0f;
        Instantiate(heart, new Vector3(Random.Range(-30f, 30f), Random.Range(-12.5f, 12.5f), 0f), Quaternion.identity);
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
// var length = transform.childCount;
            // var spawnPoints = new Transform[length];
            // for ( int i = 0; i < length; i++ ){
            //     spawnPoints[i] = transform.GetChild(i);
            // }

            // var index = Random.Range(0, spawnPoints.Length);
            // var pos = spawnPoints[index].position;