using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static float gridCellSize = 5f;
    
    public GameObject player;
    public GameObject pauseMenuCanvas;
    public GameObject deathMenuCanvas;
    public GameObject winMenuCanvas;

    public static GameManager instance
    {
        get
        {
            if (!_instance)
            {
                _instance = new GameObject().AddComponent<GameManager>();
                _instance.name = _instance.GetType().ToString();
                // DontDestroyOnLoad(_instance);
            } 
            return _instance;
        }
    }

    //STATE MACHINE TO CONTROL THE STATE OF THE GAME PAUSE/PLAYING/DEAD/ETC
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pauseMenuCanvas = GameObject.Find("PauseMenu");
        pauseMenuCanvas.SetActive(false);
        deathMenuCanvas = GameObject.Find("DeathMenu");
        deathMenuCanvas.SetActive(false);
        winMenuCanvas = GameObject.Find("WinMenu");
        winMenuCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        OpenCanvas(deathMenuCanvas);
    }

    public void PlayerWin()
    {
        OpenCanvas(winMenuCanvas);
    }

    public void OpenCanvas(GameObject canvas)
    {
        ActiveDesactiveCanvas(canvas, true);
        // canvas.SetActive(true);
        // player.GetComponent<CharacterMovement>().enabled = false;
    }
    public void CloseCanvas(GameObject canvas)
    {
        ActiveDesactiveCanvas(canvas, false);
        // canvas.SetActive(false);
        // player.GetComponent<CharacterMovement>().enabled = true;
    }

    private void ActiveDesactiveCanvas(GameObject canvas, bool activate)
    {
        canvas.SetActive(activate);
        player.GetComponent<CharacterMovement>().enabled = !activate;
    }

}
