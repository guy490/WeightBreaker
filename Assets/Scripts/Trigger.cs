using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
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
        float weightValue = col.GetComponent<WeightController>().Weight;
        weightSum += weightValue;
        if (weightSum > woodValue)
        {
            Invoke("BreakTheWood", 0.5f);
        }
        

    }
    void OnTriggerExit2D(Collider2D col)
    {
        float weightValue = col.GetComponent<WeightController>().Weight;
        weightSum -= weightValue;
    }

    private void BreakTheWood()
    {
        if (weightSum > woodValue)//double check if it still on it
        {
            GetComponentInParent<Animator>().enabled = true;
            Destroy(transform.parent.gameObject, 1.1f);
        }

    }
}
