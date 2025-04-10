using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoginData", menuName = "ScriptableObjects/NetworkingManagerScriptableObject", order = 1)]

public class NetworkingDataScriptableObject : ScriptableObject
{
    // public string apiUrl = "https://apidarknessawaits.azurewebsites.net/api";
    public string apiUrl = "https://phpstack-1076337-5399863.cloudwaysapps.com/api";
    public User user;
    public string token;

    public void InitializeData()
    {
        token = "";
        user = new User();
    }
}

