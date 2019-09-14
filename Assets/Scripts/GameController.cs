using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private GameObject errorText;
    private GameObject selectedWeight;
    private GameObject selectedArrowWeight;
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
        selectedWeight = transform.Find("WeightSprite").gameObject;
        selectedArrowWeight = selectedWeight.transform.Find("Arrow").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (ObjectIsNotMoving() )
        {
            if (selectedWeight.GetComponent<WeightController>().enabled)
            {
                MouseButtonRecognition();
                if (mouseIsDown)
                {
                    ControlTheArrow();
                }
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
            selectedArrowWeight.SetActive(true);
            MouseDownPosition = Input.mousePosition;
            ScoreManager.instance.incrementScore();
        }
        else if (Input.GetMouseButtonUp(0) && mouseIsDown)
        {
            mouseIsDown = false;
            selectedArrowWeight.SetActive(false);
            selectedWeight.GetComponent<WeightController>().ThrowWeight();
        }

    }

    public bool ObjectIsNotMoving()
    {
        
        Rigidbody2D rb = selectedWeight.GetComponent<Rigidbody2D>();
        return rb.IsSleeping();
    }
    private void ControlTheArrow()
    {
        selectedArrowWeight.GetComponent<ArrowController>().FollowArrowToMousePosition();
        selectedArrowWeight.GetComponent<ArrowController>().SetArrowLengthRelativeToMouse();
    }
    
    public void SetSelectedWeight(GameObject selectedWeight)
    {
        this.selectedWeight = selectedWeight;
        this.selectedArrowWeight = selectedWeight.transform.Find("Arrow").gameObject;
    }
    public GameObject GetSelectedWeight()
    {
        return selectedWeight;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {

        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex+1 < sceneCount)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);

        }
    }
}
