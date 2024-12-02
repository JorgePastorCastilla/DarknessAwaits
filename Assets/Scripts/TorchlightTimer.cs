using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchlightTimer : MonoBehaviour
{
    private float totalDuration = 15f;
    private float currentDuration;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        currentDuration = totalDuration;
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
            gameManager.PlayerDeath();
            this.enabled = false;
        }
    }
}
