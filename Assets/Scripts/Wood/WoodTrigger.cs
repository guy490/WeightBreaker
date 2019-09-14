using System;
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
            StartCoroutine(CheckGameStatus());
            col.GetComponent<WeightController>().enabled = false;
        }
        
    }

    private IEnumerator CheckGameStatus()
    {
        yield return new WaitUntil(GameController.instance.ObjectIsNotMoving);
        if (weightSum >= woodValue)
        {
            Invoke("BreakTheWood", 1f);
        }
        else if (NoWeightsLeft())
        {
            Invoke("GameOver", 1f);

        }
        StopCoroutine(CheckGameStatus());

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

    private void BreakTheWood()
    {
        if (weightSum >= woodValue)//double check if it still on it
        {
            GetComponentInParent<Animator>().enabled = true;
            Destroy(transform.parent.gameObject, 1.1f);
            //ScoreManager.instance.incrementScore();
        }

    }

    private void GameOver()
    {
        if (NoWeightsLeft())//Double Check
        {
            InGameMenuController.instance.ShowGameOver();
            UIController.instance.SetMenuPanel();
        }
    }

}
