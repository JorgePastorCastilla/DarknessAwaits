using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public GameObject MainMenuCanvas;
    public GameObject ScoresCanvas;
    public ClassificationManagerWithoutLogin classification;

    public void LoadScene(string SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void QuitGame()
    {
        // if (Application.isEditor)
        // {
        //     UnityEditor.EditorApplication.isPlaying = false;
        // }
        // else
        // {
        //     Application.Quit();
        // }
        Application.Quit();

    }

    public void ShowScores()
    {
        ScoresCanvas.SetActive(true);
        classification.GetClassification();
        MainMenuCanvas.SetActive(false);
    }

    public void BackToMain()
    {
        ScoresCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }
}
