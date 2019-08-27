using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private GameObject preview;
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject mouseRelativePoint;
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
            ResetWeightRotation();
            MouseButtonRecognition();
            if (mouseIsDown)
            {
                lastActionTime = Time.time;
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
            StopPreview();
            arrow.SetActive(true);
            mouseRelativePoint.SetActive(true);
            mouseIsDown = true;
            MouseDownPosition = Input.mousePosition;
            SetRedDot();
        }
        else if (Input.GetMouseButtonUp(0) && mouseIsDown)
        {
            mouseIsDown = false;
            mouseRelativePoint.SetActive(false);
            arrow.SetActive(false);
            WeightController.instance.ThrowWeight();
        }

    }

    private void SetRedDot()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(MouseDownPosition);
        mouseRelativePoint.transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, 0); 

    }

    
    private bool ObjectIsNotMoving()
    {
        
        Rigidbody2D rb = WeightController.instance.gameObject.GetComponent<Rigidbody2D>();
        return rb.IsSleeping();
    }
    private void ResetWeightRotation()
    {
        WeightController.instance.ResetRotation();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    private void StopPreview()
    {
        if (preview.activeSelf)
            preview.SetActive(false);   
    }
    private void StartPreview()
    {
        preview.transform.Find("Arrow").position = arrow.transform.position;
        if (!preview.activeSelf && ObjectIsNotMoving() && IsPlayerSleeping())
            preview.SetActive(true);
    }
    private bool IsPlayerSleeping()
    {
        float currentTime = Time.time;
        return ((currentTime - lastActionTime) >= maxTime);
    }


}
