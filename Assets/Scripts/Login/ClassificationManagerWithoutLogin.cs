using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ClassificationManagerWithoutLogin : MonoBehaviour
{
    public NetworkingDataScriptableObject loginDataSO;
    public GameObject classificationTextPrefab;

    public Transform container;
    // public GameObject classificationPanel;

    public void Start()
    {
        GetClassification();
    }

    public void GetClassification()
    {
        Debug.Log("Getting Classification");
        StartCoroutine(TryGetClassification());
    }
    
    private IEnumerator TryGetClassification()
    {
            
            UnityWebRequest httpClient = new UnityWebRequest();
            httpClient.method = UnityWebRequest.kHttpVerbGET;
            httpClient.url = loginDataSO.apiUrl + $"/classification/{loginDataSO.token}";
            httpClient.SetRequestHeader("Content-type", "application/json");
            httpClient.SetRequestHeader("Accept", "application/json");

            httpClient.downloadHandler = new DownloadHandlerBuffer();
            
            yield return httpClient.SendWebRequest();

            if (httpClient.result == UnityWebRequest.Result.ConnectionError || httpClient.result == UnityWebRequest.Result.ProtocolError)
            {
              throw new Exception("getClassification: " + httpClient.error);  
            }
            
            string jsonResponse = httpClient.downloadHandler.text;
            
            Debug.Log(jsonResponse);
            
            ClassificationDTOWithoutLogin classificationsRoot = JsonConvert.DeserializeObject<ClassificationDTOWithoutLogin>(jsonResponse);
            
            Debug.Log(classificationsRoot.Data);
            UserDTOWithoutLogin[] classifications = classificationsRoot.Data;

            
            foreach (var classification in classifications)
            {
                var classificationText = Instantiate(classificationTextPrefab, container);
                
                classificationText.GetComponent<SingleClassification>().SetTexts(classification.Name,classification.Puntuacion);
            }
            
            httpClient.Dispose();
    }
}
