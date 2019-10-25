using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTrigger : MonoBehaviour
{
    private float weightSum;
    private float woodValue;
    private List<GameObject> currectCollidedWeights;
    private bool onDestroyment;

    void Start()
    {
        weightSum = 0;
        woodValue = GetComponentInParent<WoodController>().WoodValue;
        currectCollidedWeights = new List<GameObject>();
        onDestroyment = false;
    }
    public void TriggerWoodCollisionEnter(Collision2D collision)
    {
        OnCollisionEnter2D(collision);
    }
    public void TriggerWoodCollisionExit(Collision2D collision)
    {
        OnCollisionExit2D(collision);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D col = collision.collider;
        if (col.tag == "Weight" && !currectCollidedWeights.Contains(col.gameObject) && !onDestroyment)
        {

            col.GetComponent<WeightController>().SetWoodStandingOn(transform.parent.gameObject);
            AddWeight(col);
            if (weightSum >= woodValue)
            {
                BreakTheWood(col.gameObject);

            }
            else if (NoWeightsLeft())
            {
                GameOver(col.gameObject);

            }

        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D col = collision.collider;

        if (col.tag == "Weight")
        {
            col.GetComponent<WeightController>().SetWoodStandingOn(null);
            RemoveWeight(col);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D col = collision.collider;

        if (col.tag == "Weight")
        {
            col.GetComponent<WeightController>().SetWoodStandingOn(transform.parent.gameObject);
            col.GetComponent<WeightController>().enabled = false;

        }
    }
    private void AddWeight(Collider2D col)
    {

        float weightValue = col.GetComponent<WeightController>().Weight;
        currectCollidedWeights.Add(col.gameObject);
        weightSum += weightValue;
    }
    private void RemoveWeight(Collider2D col)
    {
        currectCollidedWeights.Remove(col.gameObject);
        float weightValue = col.GetComponent<WeightController>().Weight;
        weightSum -= weightValue;
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

    private void BreakTheWood(GameObject weight)
    {

        if (weightSum >= woodValue)//double check if it still on it
        {
            onDestroyment = true;
            currectCollidedWeights.ForEach(ResetWeight);
            currectCollidedWeights.Clear();
            GetComponentInParent<Animator>().enabled = true;
            Destroy(transform.parent.gameObject, 0.3f);
            //ScoreManager.instance.incrementScore();
        }

    }

    private void ResetWeight(GameObject obj)
    {
        obj.GetComponent<WeightController>().SetWoodStandingOn(null);
    }

    private void GameOver(GameObject weight)
    {

        if (NoWeightsLeft())//Double Check
        {
            InGameMenuController.instance.ShowGameOver();
            UIController.instance.SetMenuPanel();
        }
    }

}
