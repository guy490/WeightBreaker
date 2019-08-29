using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    [SerializeField]
    private GameObject stackView;
    private Animator stackViewAnimator;
    // Start is called before the first frame update
    void Start()
    {
        stackViewAnimator = stackView.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetPanel()
    {
        bool isPanelVisible = stackViewAnimator.GetCurrentAnimatorStateInfo(0).IsName("StackAnimationIn");
        if (isPanelVisible)
        {
            HidePanel();
        }
        else
        {
            ShowPanel();
        }
    }
    private void ShowPanel()
    {
        stackViewAnimator.Play("StackAnimationIn");
    }
    private void HidePanel()
    {
        stackViewAnimator.Play("StackAnimationOut");

    }
}
