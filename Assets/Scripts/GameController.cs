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
    private float minimumDistance;
    [SerializeField]
    private GameObject weightsContainer;

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
        selectedWeight = weightsContainer.transform.Find("WeightSprite").gameObject;
        selectedArrowWeight = selectedWeight.transform.Find("Arrow").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (ObjectIsOnGround())
        {
            MouseButtonRecognition();
            if (mouseIsDown)
            {
                ControlTheArrow();
            }

        }
    }

    private void MouseButtonRecognition()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseIsDown = true;
            selectedArrowWeight.SetActive(true);
            MouseDownPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && mouseIsDown)
        {
            float distance = Math.Abs(Vector2.Distance(MouseDownPosition, Input.mousePosition));
            selectedArrowWeight.SetActive(false);

            if (distance >= minimumDistance)
            {
                ScoreManager.instance.incrementScore();
                mouseIsDown = false;
                selectedWeight.GetComponent<WeightController>().ThrowWeight();
            }
            
            
        }

    }

    public bool ObjectIsOnGround()
    {
        return selectedWeight.GetComponent<WeightController>().enabled;
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
    public void QuitButton()
    {

        SceneManager.LoadScene("Menu");

    }

    public GameObject GetWeightsContainer()
    {
        return weightsContainer;
    }
}
