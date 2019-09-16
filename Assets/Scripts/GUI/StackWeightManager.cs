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
        FillTheWeightList();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    private void FillTheWeightList()
    {
        float weight;
       foreach(Transform child in transform)
        {
            if (child.name != "PlusButton")
            {
                weight = child.GetComponent<WeightGUIObject>().Weight;
                AddWeightToList(weight, child.gameObject);
            }
        }
    }
    public void AddCollidedWeightToGUI(GameObject weightObj)
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
        GameObject weightGUI = Instantiate(prebafWeight, transform) as GameObject;
        AddWeightToList(weightValue, weightGUI);
        weightGUI.GetComponent<WeightGUIObject>().Weight = weightObj.GetComponent<WeightController>().Weight;
    }
    private void AddWeightToList(float weightValue, GameObject weightGUI)
    {
       weightList.Add(weightValue, weightGUI);
    }
    public void DeleteWeightFromList(float weightValue)
    {
        Destroy(weightList[weightValue]);
        weightList.Remove(weightValue);
    }

    public int CountWeightsLeft()
    {
        return transform.childCount-1;
    }
}
