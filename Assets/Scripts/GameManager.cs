using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (!_instance)
            {
                _instance = new GameObject().AddComponent<GameManager>();
                _instance.name = _instance.GetType().ToString();
                DontDestroyOnLoad(_instance);
            } 
            return _instance;
        }
    }
    
    public static float gridCellSize = 5f;
    
    public GameObject player;
    public GameObject pauseMenuCanvas;
    
    //STATE MACHINE TO CONTROL THE STATE OF THE GAME PAUSE/PLAYING/DEAD/ETC
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pauseMenuCanvas = GameObject.Find("PauseMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        Debug.Log("Player Death");
    }
}
