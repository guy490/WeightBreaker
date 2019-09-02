using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private GameObject errorText;
    [SerializeField]
    private GameObject arrow;
    private bool mouseIsDown = false;
    public Vector3 MouseDownPosition { get; private set; }

    void Awake()
    {
        if (instance == null)
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

        if (ObjectIsNotMoving())
        {
            MouseButtonRecognition();
            if (mouseIsDown)
            {
                arrow.SetActive(true);
                ArrowController.instance.FollowArrowToMousePosition();
                ArrowController.instance.SetArrowLengthRelativeToMouse();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShowErrorMessage();
                Invoke("RemoveErrorMessage", 1.5f);
            }
        }

    }

    private void ShowErrorMessage()
    {
        errorText.SetActive(true);
    }
    private void RemoveErrorMessage()
    {
        errorText.SetActive(false);

    }
    private void MouseButtonRecognition()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseIsDown = true;
            arrow.SetActive(true);
            MouseDownPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && mouseIsDown)
        {
            mouseIsDown = false;
            arrow.SetActive(false);
            WeightController.instance.ThrowWeight();
        }

    }

    private bool ObjectIsNotMoving()
    {
        
        Rigidbody2D rb = WeightController.instance.gameObject.GetComponent<Rigidbody2D>();
        return rb.IsSleeping();
    }



}
