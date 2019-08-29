using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    [SerializeField]
    private Animator stackPanelView;
    [SerializeField]
    private Animator gameMenuButton;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
}
