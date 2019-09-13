using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Level : MonoBehaviour, IPointerClickHandler
{
    private string levelName;
    public string LevelName
    {
        get
        {
            return levelName;
        }
        set
        {
            levelName = value;
            levelText.text = levelName;
        }
    }

    private Text levelText;
    void Awake()
    {
        levelText = gameObject.GetComponent<Text>();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        LevelsManager.instance.LoadScene(LevelName);
    }
}
