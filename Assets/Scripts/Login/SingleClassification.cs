using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingleClassification : MonoBehaviour
{
    
    public TextMeshProUGUI username;
    public TextMeshProUGUI points;

    public void SetTexts(string username, float points)
    {
        this.username.text = username;
        this.points.text = points.ToString("0000.00");
    }
}
