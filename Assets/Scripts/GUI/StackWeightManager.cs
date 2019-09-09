using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackWeightManager : MonoBehaviour
{
    public static StackWeightManager instance;
    [SerializeField]
    private GameObject prebafWeight;

    private Dictionary<float, GameObject> weightList;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        weightList = new Dictionary<float, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCurrentdWeightToGUI(GameObject weightObj)
    {
        float weightValue = weightObj.GetComponent<WeightController>().Weight;
        if (weightList.ContainsKey(weightValue))
        {
            weightList[weightValue].GetComponent<WeightGUIObject>().Amount++;
        }
        else
        {
            AddNewWeightToGUI(weightObj,weightValue);

        }
    }

    private void AddNewWeightToGUI(GameObject weightObj,float weightValue)
    {
        GameObject weightButton = Instantiate(prebafWeight, transform) as GameObject;
        weightList.Add(weightValue, weightButton);
        weightButton.GetComponent<WeightGUIObject>().Weight = weightObj.GetComponent<WeightController>().Weight;
    }

    public void DeleteWeightFromList(float weightValue)
    {
        Destroy(weightList[weightValue]);
        weightList.Remove(weightValue);
    }
}
