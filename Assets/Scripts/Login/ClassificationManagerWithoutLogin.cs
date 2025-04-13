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
    public TMP_InputField usernameInputField;

    public Transform container;

    public GameObject formulario;
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
    public void PushClassification()
    {
        Debug.Log("Getting Classification");
        StartCoroutine(TryPushClassification());
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

            foreach (Transform child in container) {
                GameObject.Destroy(child.gameObject);
            }
            foreach (var classification in classifications)
            {
                var classificationText = Instantiate(classificationTextPrefab, container);
                
                classificationText.GetComponent<SingleClassification>().SetTexts(classification.Name,classification.Puntuacion);
            }
            
            httpClient.Dispose();
    }
    
    private IEnumerator TryPushClassification()
    {
        UnityWebRequest httpRequest = new UnityWebRequest();
        httpRequest.method = UnityWebRequest.kHttpVerbPOST;
        httpRequest.url = loginDataSO.apiUrl + "/classification";
        httpRequest.SetRequestHeader("Content-type", "application/json");
        httpRequest.SetRequestHeader("Accept", "application/json");
        
        SendClassificationDTO sendClassificationDto = new SendClassificationDTO();
        sendClassificationDto.api_token = loginDataSO.token;
        sendClassificationDto.name = usernameInputField.text;
        sendClassificationDto.puntuacion = loginDataSO.puntuacion;
        
        string jsonData = JsonConvert.SerializeObject(sendClassificationDto);
        byte[] dataToSend = Encoding.UTF8.GetBytes(jsonData);
        httpRequest.uploadHandler = new UploadHandlerRaw(dataToSend);
        
        httpRequest.downloadHandler = new DownloadHandlerBuffer();
        
        yield return httpRequest.SendWebRequest();

        if (httpRequest.result == UnityWebRequest.Result.ConnectionError || httpRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            throw new Exception("Send Classification: " + httpRequest.error);  
        }
        
        // Debug.Log(httpRequest.result.ToString());
        
        string jsonResponse = httpRequest.downloadHandler.text;
        
        formulario.SetActive(false);
        // UserDTO registeredUser = JsonConvert.DeserializeObject<UserDTO>(jsonResponse);
        
        
        Debug.Log(jsonResponse);
        
        GetClassification();
        
        
    }
}
