using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColliderSet : MonoBehaviour
{
    private BoxCollider2D[] boxColliders;
    private List<Vector2> newVerticies = new List<Vector2>();
    private Vector2 screenBounds;

    void Awake()
    {
        boxColliders = GetComponents<BoxCollider2D>();
    }
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenUpLimit = new Vector2(0,screenBounds.y + boxColliders[0].size.y);
        Vector2 screenLeftLimit = new Vector2(-(screenBounds.x + boxColliders[1].size.x), 0);
        Vector2 screenRightLimit =  new Vector2(screenBounds.x + boxColliders[2].size.x, 0);


        boxColliders[0].offset = screenUpLimit;
        boxColliders[1].offset = screenLeftLimit;
        boxColliders[2].offset = screenRightLimit;

    }


}
