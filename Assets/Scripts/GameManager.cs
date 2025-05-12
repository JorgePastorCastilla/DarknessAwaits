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
    
    public bool playerIsDead = false;
    public bool gameIsPaused = false;
        
    public float maxScore = 420f;
    public float finalScore;
    public NetworkingDataScriptableObject networkData;
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
        playerIsDead = true;
        // ClassificationManagerWithoutLogin classification_component = deathMenuCanvas.GetComponent<ClassificationManagerWithoutLogin>();
        // classification_component.GetClassification();
        // SetScore();
        // classification_component.RefreshScore();
    }

    public void PlayerWin()
    {
        OpenCanvas(winMenuCanvas);
        // ClassificationManagerWithoutLogin classification_component = winMenuCanvas.GetComponent<ClassificationManagerWithoutLogin>();
        // classification_component.GetClassification();
        // SetScore();
        // classification_component.RefreshScore();
    }

    public void SetScore()
    {
        finalScore = (maxScore - player.GetComponent<PlayerScore>().score); // Segundos restantes
        
        if (playerIsDead == true)
        {
            finalScore *= 5;
        }
        else
        {
            finalScore *= 30;
        }
    }

    public void OpenCanvas(GameObject canvas)
    {
        if (!playerIsDead)
        {
            ActiveDesactiveCanvas(canvas, true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
            // canvas.SetActive(true);
            // player.GetComponent<CharacterMovement>().enabled = false;
        }
    }
    public void CloseCanvas(GameObject canvas)
    {
        if (!playerIsDead)
        {
            ActiveDesactiveCanvas(canvas, false);
            Time.timeScale = 1f;
            AudioListener.pause = false;
            // canvas.SetActive(false);
            // player.GetComponent<CharacterMovement>().enabled = true;
        }
    }

    private void ActiveDesactiveCanvas(GameObject canvas, bool activate)
    {
        gameIsPaused = activate;
        canvas.SetActive(activate);
        // player.GetComponent<CharacterMovement>().enabled = !activate;
        
        GameObject torch = GameObject.Find("Torch");
        if ( torch.GetComponent<TorchlightTimer>() != null )
        {
            torch.GetComponent<TorchlightTimer>().enabled = !activate;
        }
        
        
        
    }

}
