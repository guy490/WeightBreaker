using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameMenuController : MonoBehaviour
{
    public static InGameMenuController instance;

    [SerializeField]
    private GameObject stars;
    [SerializeField]
    private GameObject goodMessage;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject nextLevelButton;
    [SerializeField]
    private Text score;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGoodMessage()
    {
        goodMessage.SetActive(true);
    }
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    public void SetScore(string text)
    {
        score.text = text;
    }

    public void ShowNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }



}
