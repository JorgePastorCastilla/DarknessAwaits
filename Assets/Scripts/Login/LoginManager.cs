using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;

public class LoginManager : MonoBehaviour
{
    private GameObject usuari;

    public TMP_InputField emailInput, passwordInput;

    public NetworkingDataScriptableObject loginDataSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void login()
    {
        Debug.Log("Login");
        StartCoroutine(TryLogin());
    }

    private IEnumerator TryLogin()
    {
        if (usuari == null)
        {
            UnityWebRequest httpClient = new UnityWebRequest();
            httpClient.method = UnityWebRequest.kHttpVerbPOST;
            httpClient.url = loginDataSO.apiUrl + "/Auth/Login";
            httpClient.SetRequestHeader("Content-type", "application/json");
            httpClient.SetRequestHeader("Accept", "application/json");

            RegisterUserDTO loginDataUsuari = new RegisterUserDTO();
            loginDataUsuari.Nom = "prova";
            loginDataUsuari.Email = emailInput.text;
            loginDataUsuari.Password = passwordInput.text;
            
            string jsonData = JsonConvert.SerializeObject(loginDataUsuari);
            byte[] dataToSend = Encoding.UTF8.GetBytes(jsonData);
            
            httpClient.uploadHandler = new UploadHandlerRaw(dataToSend);
            httpClient.downloadHandler = new DownloadHandlerBuffer();
            
            yield return httpClient.SendWebRequest();

            if (httpClient.result == UnityWebRequest.Result.ConnectionError || httpClient.result == UnityWebRequest.Result.ProtocolError)
            {
              throw new Exception("Login: " + httpClient.error);  
            }

            string jsonResponse = httpClient.downloadHandler.text;
            
            AuthTokenDto authTokenDto = JsonConvert.DeserializeObject<AuthTokenDto>(jsonResponse);
            loginDataSO.token = authTokenDto.token;
            Debug.Log(authTokenDto.token);
            httpClient.Dispose();

        }
    }
}
