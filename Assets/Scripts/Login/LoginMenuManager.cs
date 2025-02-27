using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginMenuManager : MonoBehaviour
{
    public LoginManager loginManager;
    public ClassificationManager classificationManager;
    
    public GameObject loginCanvas, registerCanvas, generalCanvas, landingCanvas;
    public TextMeshProUGUI landing_name, landing_email;
    
    // Start is called before the first frame update

    public void GoLogin()
    {
        loginCanvas.SetActive(true);
        registerCanvas.SetActive(false);
        generalCanvas.SetActive(false);
    }
    public void GoRegister()
    {
        registerCanvas.SetActive(true);
        loginCanvas.SetActive(false);
        generalCanvas.SetActive(false);
    }
    public void GoGeneral()
    {
        generalCanvas.SetActive(true);
        loginCanvas.SetActive(false);
        registerCanvas.SetActive(false);
    }
    public void GoLanding(string name, string email)
    {
        generalCanvas.SetActive(false);
        loginCanvas.SetActive(false);
        registerCanvas.SetActive(false);
        
        landing_name.text = name;
        landing_email.text = email;
        landingCanvas.SetActive(true);
        classificationManager.getClassification();
    }
    
}
