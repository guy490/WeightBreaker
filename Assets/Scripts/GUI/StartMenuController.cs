using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenuController : MonoBehaviour
{
    [SerializeField]
    private Animator levelPanel;
    [SerializeField]
    private Animator menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelMenuIn()
    {
        menuPanel.Play("MenuOut");
        levelPanel.Play("LevelsPanelIn");
    }
    public void StartLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
