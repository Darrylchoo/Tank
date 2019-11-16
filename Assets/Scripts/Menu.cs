using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int highScoreCount;

    public Text highScoreText;

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

        UpdateHighScore();
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

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        //Application.Quit();
    }

    
}
