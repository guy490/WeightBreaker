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
    private bool isMoving;
    private const float noMovementThreshold = 0.002f;
    private const int noMovementFrames = 3;
    private float[] previousHeights = new float[noMovementFrames];
    
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
        for (int i = 0; i < previousHeights.Length; i++)
        {
            previousHeights[i] = 0;
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
        //Store the newest vector at the end of the list of vectors
        for (int i = 0; i < previousHeights.Length - 1; i++)
        {
            previousHeights[i] = previousHeights[i + 1];
        }
        previousHeights[previousHeights.Length - 1] = gameObject.transform.position.y;

        for (int i = 0; i < previousHeights.Length - 1; i++)
        {
            if (Mathf.Abs(previousHeights[i]-previousHeights[i + 1]) >= noMovementThreshold)
            {
                //The minimum movement has been detected between frames
                isMoving = true;
                break;
            }
            else
            {
                isMoving = false;
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
    public bool WeightIsNotMoving()
    {
        Update();
        return isMoving==false; 
    }

}
