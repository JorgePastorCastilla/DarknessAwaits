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
    public LoginMenuManager loginMenuManager;

    public TMP_InputField login_emailInput, login_passwordInput, register_nameInput, register_emailInput, register_passwordInput;

    public NetworkingDataScriptableObject loginDataSO;

    public void login(string email = "", string password = "")
    {
        if (email == "" && password == "")
        {
            email = login_emailInput.text;
            password = login_passwordInput.text;
        }
        Debug.Log("Login");
        StartCoroutine(TryLogin(email, password));
    }
    public void login()
    {
        Debug.Log("Login");
        StartCoroutine(TryLogin(login_emailInput.text, login_passwordInput.text));
    }
    
    public void register()
    {
        Debug.Log("Register");
        StartCoroutine(TryRegister());
    }

    private IEnumerator TryLogin(string email = "", string password = "")
    {
        if (usuari == null)
        {
            loginDataSO.InitializeData();
            
            UnityWebRequest httpClient = new UnityWebRequest();
            httpClient.method = UnityWebRequest.kHttpVerbPOST;
            httpClient.url = loginDataSO.apiUrl + "/Auth/Login";
            httpClient.SetRequestHeader("Content-type", "application/json");
            httpClient.SetRequestHeader("Accept", "application/json");

            RegisterUserDTO loginDataUsuari = new RegisterUserDTO();
            loginDataUsuari.Username = "prova";
            loginDataUsuari.Email = email;
            loginDataUsuari.Password = password;
            
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
            loginDataSO.user.name = authTokenDto.username;
            loginDataSO.user.email = authTokenDto.email;
            loginDataSO.token = authTokenDto.token;
            
            // Debug.Log($"username: {authTokenDto.username}");
            // Debug.Log($"email: {authTokenDto.email}");
            Debug.Log($"token: {authTokenDto.token}");
            
            
            httpClient.Dispose();
            
            loginMenuManager.GoLanding(loginDataSO.user.name,loginDataSO.user.email);

        }
    }

    private IEnumerator TryRegister()
    {
        UnityWebRequest httpRequest = new UnityWebRequest();
        httpRequest.method = UnityWebRequest.kHttpVerbPOST;
        httpRequest.url = loginDataSO.apiUrl + "/Auth/Register";
        httpRequest.SetRequestHeader("Content-type", "application/json");
        httpRequest.SetRequestHeader("Accept", "application/json");
        
        RegisterUserDTO registerUserDto = new RegisterUserDTO();
        registerUserDto.Username = register_nameInput.text;
        registerUserDto.Email = register_emailInput.text;
        registerUserDto.Password = register_passwordInput.text;
        
        string jsonData = JsonConvert.SerializeObject(registerUserDto);
        byte[] dataToSend = Encoding.UTF8.GetBytes(jsonData);
        httpRequest.uploadHandler = new UploadHandlerRaw(dataToSend);
        
        httpRequest.downloadHandler = new DownloadHandlerBuffer();
        
        yield return httpRequest.SendWebRequest();

        if (httpRequest.result == UnityWebRequest.Result.ConnectionError || httpRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            throw new Exception("Register: " + httpRequest.error);  
        }
        
        // Debug.Log(httpRequest.result.ToString());
        
        string jsonResponse = httpRequest.downloadHandler.text;
        
        
        UserDTO registeredUser = JsonConvert.DeserializeObject<UserDTO>(jsonResponse);
        
        
        Debug.Log($"Creado usuario: {registeredUser.Id}, {registeredUser.Username}, {registeredUser.Email}");
        
        login(registerUserDto.Email, registerUserDto.Password);
        
        
        
    }
}
