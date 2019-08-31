using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightController : MonoBehaviour
{
    public static WeightController instance;
    private const float maxPositiveRotation = 250f;
    private const float minPositiveRotation = 110f;
    private const float maxNegativeRotation = -110f;
    private const float minNegativeRotation = -250f;
    [SerializeField]
    private float weight;
    public float Weight
    {
        get
        {
            return weight;
        }
        set
        {
            weight = value;
        }
    }

    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private float force;
    [SerializeField]
    private TextMesh weightText;
    private Rigidbody2D rb;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        weightText.text = Weight + "KG";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ThrowWeight()
    {
        Vector3 mouseDownWorldPosition = Camera.main.ScreenToWorldPoint(GameController.instance.MouseDownPosition);
        Vector3 mouseCurrentWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mouseDownWorldPosition, mouseCurrentWorldPosition);
        Vector2 direction = (mouseCurrentWorldPosition - mouseDownWorldPosition) / distance;
        if (!float.IsNaN(direction.x) && !float.IsNaN(direction.y))
        {
            rb.AddForce(-direction * arrow.transform.localScale.y * force, ForceMode2D.Impulse);
        }
    }

    public void ResetRotation()
    {
       
        if (BetweenPositiveAngles() || BetweenNegativeAngles())
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
    }
    private bool BetweenPositiveAngles()
    {
        Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;
        return currentRotation.z <= maxPositiveRotation && currentRotation.z >= minPositiveRotation;
    }
    private bool BetweenNegativeAngles()
    {
        Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;
        return currentRotation.z <= maxNegativeRotation && currentRotation.z >= minNegativeRotation;
    }

}
