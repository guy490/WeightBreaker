using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public static ArrowController instance;
    [SerializeField]
    private float arrowMaxLength;
    [SerializeField]
    private Transform weightPosition;
    private Vector2 mouseDownPosition;
    private Vector2 mouseCurrentPosition;
    private Vector3 arrowScale;
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

    }

    public void FollowArrowToMousePosition()
    {
        SetMousePositions();
        
        Vector2 direction = mouseCurrentPosition - (Vector2)(weightPosition.transform.position);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        gameObject.transform.rotation = rotation;
    }

    public void SetArrowLengthRelativeToMouse()
    {
        SetMousePositions();
        float currentDistance = Vector2.Distance(mouseDownPosition, mouseCurrentPosition);
        arrowScale = gameObject.transform.localScale;
        if (currentDistance <= arrowMaxLength)
        {
            gameObject.transform.localScale = new Vector3(arrowScale.x, currentDistance, arrowScale.z);
        }
    }
    private void SetMousePositions()
    {
        mouseDownPosition = Camera.main.ScreenToWorldPoint(GameController.instance.MouseDownPosition);
        mouseCurrentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}


