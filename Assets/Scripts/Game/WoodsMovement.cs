using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsMovement : MonoBehaviour
{
    [SerializeField]
    private float repeatRate = 0;
    [SerializeField]
    private GameObject sideColliders;
    [SerializeField]
    private GameObject grassCollider;
    [SerializeField]
    private GameObject[] upDownMove;
    [SerializeField]
    private GameObject[] downUpMove;
    [SerializeField]
    private GameObject[] rightLeftMove;
    [SerializeField]
    private GameObject[] leftRightMove;
    [SerializeField]
    private GameObject[] rightCircleMove;
    [SerializeField]
    private GameObject[] leftCircleMove;
    private bool lessThanMax = true;
    private const float offset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartUpDown", 0f, repeatRate);
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void StartUpDown()
    {
        float upColliderPosition = sideColliders.GetComponent<ScreenColliderSet>().GetBoxColliders()["up"].transform.position.y;
        float grassColliderPosition = grassCollider.GetComponent<BoxCollider2D>().transform.position.y;
        foreach (GameObject wood in upDownMove)
        {
            if(lessThanMax)
                wood.GetComponent<WoodController>().moveUp();
            else
                wood.GetComponent<WoodController>().moveDown();
            if (Mathf.Abs(wood.transform.position.y - upColliderPosition) < offset)
            {
                lessThanMax = false;
            }else if (Mathf.Abs(wood.transform.position.y - grassColliderPosition) < offset)
            {
                lessThanMax = true;
            }
        }
        
    }



}
