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
    private float force;
    [SerializeField]
    private float maxDistance;

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
        Vector3 mouseUpWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mouseDownWorldPosition, mouseUpWorldPosition);
        Vector2 direction = (mouseUpWorldPosition - mouseDownWorldPosition) / distance;
        if(distance > 2)
        {
            distance = 2;
        }
        if (!float.IsNaN(direction.x) && !float.IsNaN(direction.y))
        {
            rb.AddForce(direction * distance * force, ForceMode2D.Impulse);
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
