using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float gridCellSize = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;    
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
