using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigger : MonoBehaviour
{
    private bool somthingOnFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        somthingOnFloor = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Weight")
        {
            somthingOnFloor = true;
            col.GetComponent<WeightController>().enabled = true;
            if (somthingOnFloor && ItsNotThePlaySelectedWeight(col))
            {
                col.GetComponent<Animator>().enabled = true;
                StackWeightManager.instance.AddCollidedWeightToGUI(col.gameObject);
                Destroy(col.gameObject,2f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Weight")
        {
            col.GetComponent<WeightController>().enabled = false;
            somthingOnFloor = false;
        }
    }
    private bool ItsNotThePlaySelectedWeight(Collider2D col)
    {
        return col.transform.gameObject != GameController.instance.GetSelectedWeight();
    }
}
