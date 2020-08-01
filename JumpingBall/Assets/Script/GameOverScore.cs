using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScore : MonoBehaviour
{
    public static GameOverScore instance;

    public Text Score, highScore;
    int scoreCounter, highScoreCounter;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScoreCounter = PlayerPrefs.GetInt("SaveScore");
        }
    }


    // Update is called once per frame
    void Update()
    {
        Score.text = "Score:" + scoreCounter;
        highScore.text = "HighScore:" + highScoreCounter;
    }

    public void AddScore()
    {
        scoreCounter++;
        HighScore();
    }

    public void HighScore()
    {
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;

            PlayerPrefs.SetInt("SaveScore", highScoreCounter);
        }
    }
    public void ResetScore()
    {
        scoreCounter = 0;
    }
}
