using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private GameObject preview;
    [SerializeField]
    private GameObject errorText;
    private bool mouseIsDown = false;
    public Vector3 MouseDownPosition { get; private set; }
    private float lastActionTime;
    private float maxTime;

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
        maxTime = 5f;
        InvokeRepeating("StartPreview", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectIsNotMoving())
        {
            MouseButtonRecognition();
            if (mouseIsDown)
            {
                lastActionTime = Time.time;
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
            StopPreview();
            mouseIsDown = true;
            MouseDownPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && mouseIsDown)
        {
            mouseIsDown = false;
            WeightController.instance.ThrowWeight();
        }

    }

    private bool ObjectIsNotMoving()
    {
        
        Rigidbody2D rb = WeightController.instance.gameObject.GetComponent<Rigidbody2D>();
        return rb.IsSleeping();
    }

    private void StopPreview()
    {

    }
    private void StartPreview()
    {

    }
    private bool IsPlayerSleeping()
    {
        float currentTime = Time.time;
        return ((currentTime - lastActionTime) >= maxTime);
    }


}
