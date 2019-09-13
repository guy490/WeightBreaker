using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsManager : MonoBehaviour
{

    public static WoodsManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public int WoodsLeft()
    {
        return gameObject.transform.childCount;
    }

}
