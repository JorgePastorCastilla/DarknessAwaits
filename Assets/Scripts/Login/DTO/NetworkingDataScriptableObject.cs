using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoginData", menuName = "ScriptableObjects/NetworkingManagerScriptableObject", order = 1)]

public class NetworkingDataScriptableObject : ScriptableObject
{
    public string apiUrl = "https://apidarknessawaits.azurewebsites.net/api";
    public User user;
    public string token;

    public void InitializeData()
    {
        token = "";
        user = new User();
    }
}

