using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ClassificationManager : MonoBehaviour
{
    public NetworkingDataScriptableObject loginDataSO;
    public void getClassification()
    {
        Debug.Log("Getting Classification");
        StartCoroutine(TryGetClassification());
    }
    
    private IEnumerator TryGetClassification()
    {
            
            UnityWebRequest httpClient = new UnityWebRequest();
            httpClient.method = UnityWebRequest.kHttpVerbGET;
            httpClient.url = loginDataSO.apiUrl + "/Leaderboard/GetClassification";
            httpClient.SetRequestHeader("Content-type", "application/json");
            httpClient.SetRequestHeader("Accept", "application/json");

            // string data = null;
            // string jsonData = JsonConvert.SerializeObject(data);
            // byte[] dataToSend = Encoding.UTF8.GetBytes(jsonData);
            //
            // httpClient.uploadHandler = new UploadHandlerRaw( dataToSend );
            httpClient.downloadHandler = new DownloadHandlerBuffer();
            
            yield return httpClient.SendWebRequest();

            if (httpClient.result == UnityWebRequest.Result.ConnectionError || httpClient.result == UnityWebRequest.Result.ProtocolError)
            {
              throw new Exception("getClassification: " + httpClient.error);  
            }
            
            string jsonResponse = httpClient.downloadHandler.text;
            
            Debug.Log(jsonResponse);
            
            // AuthTokenDto authTokenDto = JsonConvert.DeserializeObject<AuthTokenDto>(jsonResponse);
            // loginDataSO.user.name = authTokenDto.username;
            // loginDataSO.user.email = authTokenDto.email;
            // loginDataSO.token = authTokenDto.token;
            
            httpClient.Dispose();
            
            // loginMenuManager.GoLanding(loginDataSO.user.name,loginDataSO.user.email);
    }
}
