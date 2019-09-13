using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;
    [SerializeField]
    private GameObject levelPrefab;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            if (scenes[i].StartsWith("Level"))
            {
                GameObject levelObj = Instantiate(levelPrefab, transform);
                levelObj.GetComponent<Level>().LevelName = scenes[i];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
