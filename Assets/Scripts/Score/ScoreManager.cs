using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    //private int highScore;


    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //PlayerPrefs.SetInt("score", score);
    }
    public void incrementScore()
    {
        score++;
        UIController.instance.SetScore(score);
        //PlayerPrefs.SetInt("score", score);
        //if (PlayerPrefs.HasKey("highScore"))
        //{
        //    if (score > PlayerPrefs.GetInt("highScore"))
        //    {
        //        PlayerPrefs.SetInt("highScore", score);
        //    }
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("highScore", score);
        //}
    }


}
