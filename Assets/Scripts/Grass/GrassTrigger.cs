using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator weightGainAnimation;
    private bool somthingOnFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        somthingOnFloor = true;
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.tag == "Weight")
    //    {
    //        col.GetComponent<WeightController>().enabled = true;
    //        if (somthingOnFloor && false)
    //        {
    //            weightGainAnimation.Play("GainWeight");
    //            Destroy(col.gameObject);
    //        }
    //    }
    //}
    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.tag == "Weight")
    //    {
    //        col.GetComponent<WeightController>().enabled = false;
    //        somthingOnFloor = false;
    //    }
    //}
}
