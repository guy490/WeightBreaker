using System.Collections.Generic;
using UnityEngine;

public class ScreenColliderSet : MonoBehaviour
{
    private Dictionary<string, GameObject> boxColliders;
    private List<Vector2> newVerticies = new List<Vector2>();
    private Vector2 screenBounds;

    void Awake()
    {
        
    }
    void Start()
    {
        initializeBoxCollider();
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenUpLimit = new Vector2(0,screenBounds.y + boxColliders["up"].GetComponent<BoxCollider2D>().size.y + 0.3f);
        Vector2 screenLeftLimit = new Vector2(-(screenBounds.x + boxColliders["left"].GetComponent<BoxCollider2D>().size.x+0.3f), 0 );
        Vector2 screenRightLimit =  new Vector2(screenBounds.x + boxColliders["right"].GetComponent<BoxCollider2D>().size.x + 0.3f, 0);


        boxColliders["up"].transform.localPosition = screenUpLimit;
        boxColliders["left"].transform.localPosition = screenLeftLimit;
        boxColliders["right"].transform.localPosition = screenRightLimit;

    }

    private void initializeBoxCollider()
    {
        boxColliders = new Dictionary<string, GameObject>();
        boxColliders.Add("up", transform.GetChild(0).gameObject);
        boxColliders.Add("left", transform.GetChild(1).gameObject);
        boxColliders.Add("right", transform.GetChild(2).gameObject);
    }

    public Dictionary<string, GameObject> GetBoxColliders()
    {
        return boxColliders;
    }


}
