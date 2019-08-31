using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightController : MonoBehaviour
{
    [SerializeField]
    private float weight;
    [SerializeField]
    private float force;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private TextMesh weightText;
    private Rigidbody2D rb;
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
        if (distance > maxDistance)
        {
            distance = maxDistance;
        }
        Vector2 direction = (mouseUpWorldPosition - transform.position) / Vector2.Distance(mouseUpWorldPosition ,transform.position);
        
        if (!float.IsNaN(direction.x) && !float.IsNaN(direction.y))
        {
            rb.AddForce(direction * distance*  force, ForceMode2D.Impulse);
        }
    }

    public void setWeightText(float weight)
    {
        Weight = weight;
        weightText.text = Weight + "KG";
    }


}
