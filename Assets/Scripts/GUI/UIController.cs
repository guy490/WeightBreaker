using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField]
    private Animator stackPanelView;
    [SerializeField]
    private Animator gameMenuButton;
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

    public void SetStackPanel()
    {
        bool isPanelVisible = stackPanelView.GetCurrentAnimatorStateInfo(0).IsName("StackAnimationIn");
        if (isPanelVisible)
        {
            HideStackPanel();
            ShowMenuButton();

        }
        else
        {
            ShowStackPanel();
            HideMenuButton();

        }
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


    private void ShowStackPanel()
    {
        stackPanelView.Play("StackAnimationIn");
    }
    private void HideStackPanel()
    {
        stackPanelView.Play("StackAnimationOut");
    }
    private void ShowMenuButton()
    {
        gameMenuButton.Play("ShowMenuButton");
    }
    private void HideMenuButton()
    {
        gameMenuButton.Play("HideMenuButton");
    }

    private void ShowMenuPanel()
    {
        menuPanel.Play("ShowMenuPanel");
    }
    private void HideMenuPanel()
    {
        menuPanel.Play("HideMenuPanel");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
