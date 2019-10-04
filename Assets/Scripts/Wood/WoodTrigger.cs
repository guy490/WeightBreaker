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
            if (weightSum >= woodValue)
            {
                StartCoroutine("BreakTheWood",col.gameObject);
            }
            else if (NoWeightsLeft())
            {
                StartCoroutine("GameOver", col.gameObject);

            }
        }
        
    }

    private bool NoWeightsLeft()
    {
        return StackWeightManager.instance.CountWeightsLeft() == 0 && IsAllWeightsDisabled();
    }
    private bool IsAllWeightsDisabled()
    {
        GameObject weightsContainer = GameController.instance.GetWeightsContainer();
        WeightController[] weightsControllers =  weightsContainer.GetComponentsInChildren<WeightController>();
        foreach(WeightController component in weightsControllers)
        {
            if (component.enabled)
            {
                return false;
            }
        }
        return true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Weight")
        {
            float weightValue = col.GetComponent<WeightController>().Weight;
            weightSum -= weightValue;
        }
    }

    private IEnumerator BreakTheWood(GameObject weight)
    {

        yield return new WaitUntil(weight.GetComponent<WeightController>().WeightIsNotMoving);

        if (weightSum >= woodValue)//double check if it still on it
        {
            GetComponentInParent<Animator>().enabled = true;
            Destroy(transform.parent.gameObject, 1.1f);
            //ScoreManager.instance.incrementScore();
        }
        StopCoroutine("BreakTheWood");


    }

    private IEnumerator GameOver(GameObject weight)
    {
        yield return new WaitUntil(weight.GetComponent<WeightController>().WeightIsNotMoving);

        if (NoWeightsLeft())//Double Check
        {
            InGameMenuController.instance.ShowGameOver();
            UIController.instance.SetMenuPanel();
        }
        StopCoroutine("GameOver");

    }

}
