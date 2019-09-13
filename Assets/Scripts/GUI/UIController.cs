using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField]
    private Animator menuPanel;
    [SerializeField]
    private GameObject scoreUI;


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

    public void SetScore(int score)
    {
        scoreUI.GetComponent<Text>().text = "Moves: " + score;
    }

    public void SetMenuPanel()
    {
        bool isPanelVisible = menuPanel.GetCurrentAnimatorStateInfo(0).IsName("ShowMenuPanel");
        if (isPanelVisible)
        {
            HideMenuPanel();
        }
        else
        {
            ShowMenuPanel();
        }
    }


    private void ShowMenuPanel()
    {
        menuPanel.Play("ShowMenuPanel");
    }
    private void HideMenuPanel()
    {
        menuPanel.Play("HideMenuPanel");
    }

}
