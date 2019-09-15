﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTrigger : MonoBehaviour
{
    private float weightSum;
    private float woodValue;

    void Start()
    {
        weightSum = 0;
        woodValue = GetComponentInParent<WoodController>().Weight;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Weight")
        {
            float weightValue = col.GetComponent<WeightController>().Weight;
            weightSum += weightValue;
            if (weightSum >= woodValue)
            {
                StartCoroutine("BreakTheWood");
            }
            else if (NoWeightsLeft())
            {
                StartCoroutine("GameOver");

            }
            col.GetComponent<WeightController>().enabled = false;
        }
        
    }

    private bool NoWeightsLeft()
    {
        return StackWeightManager.instance.CountWeightsLeft() == 0;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Weight")
        {
            col.GetComponent<WeightController>().enabled = true;
            float weightValue = col.GetComponent<WeightController>().Weight;
            weightSum -= weightValue;
        }
    }

    private IEnumerator BreakTheWood()
    {
        yield return new WaitUntil(GameController.instance.ObjectIsNotMoving);
        if (weightSum >= woodValue)//double check if it still on it
        {
            GetComponentInParent<Animator>().enabled = true;
            Destroy(transform.parent.gameObject, 1.1f);
            //ScoreManager.instance.incrementScore();
        }
        StopCoroutine("BreakTheWood");


    }

    private IEnumerator GameOver()
    {
        yield return new WaitUntil(GameController.instance.ObjectIsNotMoving);

        if (NoWeightsLeft())//Double Check
        {
            InGameMenuController.instance.ShowGameOver();
            UIController.instance.SetMenuPanel();
        }
        StopCoroutine("GameOver");

    }

}
