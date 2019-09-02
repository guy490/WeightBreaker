﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [SerializeField]
    private float weight;
    public float Weight
    {
        get
        {
            return weight;
        }
        set
        {
            weight = value;
        }
    }
    [SerializeField]
    private TextMesh woodText;

    // Start is called before the first frame update
    void Start()
    {
        woodText.text = Weight + "KG";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}