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
    [SerializeField]
    private float weight;
    [SerializeField]
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
        if (WeightCanBePlayed(selectedWeight))
        {
            StackWeightManager.instance.AddCollidedWeightToGUI(selectedWeight);
            Destroy(selectedWeight);
        }

        GameObject weightsContainer = GameController.instance.GetWeightsContainer();
        GameObject obj = Instantiate(prefab, weightsContainer.transform);
        GameController.instance.SetSelectedWeight(obj);

    }

    private bool WeightCanBePlayed(GameObject gameObjectParam)
    {
        return gameObjectParam.GetComponent<WeightController>().enabled;
    }
}
