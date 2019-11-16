using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private int highScoreCount;

    public Text highScoreText;
    public Text scoreText;

    void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
            highScoreCount = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        if (GM.score > highScoreCount)
        {
            highScoreCount = GM.score;
            PlayerPrefs.SetInt("highscore", highScoreCount);
        }

        UpdateScore();
        UpdateHighScore();
    }

    void UpdateScore()
    {
        if (GM.score == 0)
            scoreText.text = "000" + GM.score.ToString();
        else if (GM.score < 1000)
            scoreText.text = "0" + GM.score.ToString();
        else
            scoreText.text = GM.score.ToString();
    }

    void UpdateHighScore()
    {
        if (highScoreCount == 0)
            highScoreText.text = "000" + highScoreCount.ToString();
        else if (highScoreCount < 1000)
            highScoreText.text = "0" + highScoreCount.ToString();
        else
            highScoreText.text = highScoreCount.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;

        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        // Application.Quit();
    }
}
