using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class WeightGUIObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Text weightGUIText;
    [SerializeField]
    private Text AmountGUI;
    [SerializeField]
    private GameObject prefab;
    private float weight;
    private float amount;
    public float Weight
    {
        get
        {
            return weight;
        }
        set
        {
            weight = value;
            weightGUIText.text = weight + "KG";
        }
    }
    public float Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
            AmountGUI.text = "x" + amount;
        }
    }

    void Awake()
    {
        weight = 0;
        amount = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        weightGUIText.text = weight + "KG";
        AmountGUI.text = "x" + amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        GameObject selectedWeight = GameController.instance.GetSelectedWeight();

        prefab.GetComponent<WeightController>().Weight = weight;
        Amount--;
        if(Amount == 0)
        {
            StackWeightManager.instance.DeleteWeightFromList(weight);
        }
        if (WeightIsAvailable(selectedWeight))
        {
            Destroy(selectedWeight);
            StackWeightManager.instance.AddCurrentdWeightToGUI(selectedWeight);
        }
        GameObject obj = Instantiate(prefab);
        GameController.instance.SetSelectedWeight(obj);

    }

    private bool WeightIsAvailable(GameObject gameObjectParam)
    {
        return gameObjectParam.GetComponent<WeightController>().enabled;
    }
}
