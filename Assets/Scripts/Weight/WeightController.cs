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
    private GameObject woodStandingOn;
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
            weightText.text = weight + "KG";
        }
    }
    void Awake()
    {
        woodStandingOn = null;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D col = collision.collider;
        if (col.tag == "Weight" && woodStandingOn != null)
        {
            if (col.GetComponent<WeightController>().enabled)
            {
                woodStandingOn = col.gameObject.GetComponent<WeightController>().woodStandingOn;
            }
            else
            {
                woodStandingOn.GetComponentInChildren<WoodTrigger>().TriggerWoodCollisionEnter(collision);
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D col = collision.collider;
        if (col.tag == "Weight" && woodStandingOn != null)
        {
            if (col.GetComponent<WeightController>().enabled)
            {
                woodStandingOn.GetComponentInChildren<WoodTrigger>().TriggerWoodCollisionExit(collision);
                woodStandingOn = null;
            }

        }
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

    public void SetWoodStandingOn(GameObject wood)
    {
        if (wood == null || wood.tag == "Wood")
        {
            woodStandingOn = wood;
        }
    }
}
