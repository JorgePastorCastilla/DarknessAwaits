using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        GoToScene("MainMenu");
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameManager.instance.CloseCanvas(this.gameObject);
    }
    
    public void TryAgain()
    {
        Time.timeScale = 1;
        GoToScene("Prototype");
    }

    private void GoToScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    
}
