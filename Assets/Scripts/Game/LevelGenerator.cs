using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
