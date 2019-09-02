using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightGUIObject : MonoBehaviour
{
    [SerializeField]
    private float weight;
    [SerializeField]
    private float amount;
    [SerializeField]
    private Text weightGUIText;
    [SerializeField]
    private Text AmountGUI;
    public float Weight { get { return weight; } set { weight = value; } }
    public float Amount { get { return amount; } set { amount = value; } }
    // Start is called before the first frame update
    void Start()
    {
        weightGUIText.text = Weight + "KG";
        AmountGUI.text = "x" + Amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeightGUIText(float weight)
    {
        Weight = weight;
        weightGUIText.text = Weight + "KG";
    }
    public void SetAmountGUIText(float amount)
    {
        Amount = amount;
        AmountGUI.text = "x" + Amount;
    }
}
