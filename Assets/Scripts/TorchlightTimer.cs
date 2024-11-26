using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchlightTimer : MonoBehaviour
{
    private float totalDuration = 15f;
    private float currentDuration = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
        }
        
        // Debug.Log($"Current Duration: {currentDuration}");
        if(currentDuration <= 0)
        {
            Debug.Log("Torchlight timer finished");
        }
    }
}
