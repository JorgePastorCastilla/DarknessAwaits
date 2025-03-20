using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchlightTimer : MonoBehaviour
{
 
    private float totalDuration = 240f;// 4min/240secs
    private float currentDuration;
    private GameManager gameManager;

    //TODO: DELETE THIS AS THIS IS JUST FOR DEBUG PURPOSES
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        currentDuration = totalDuration;
        //TODO: DELETE THIS AS THIS IS JUST FOR DEBUG PURPOSES
        image = GameObject.Find("TorchTimerCanva").transform.GetChild(0).Find("Fill").gameObject.GetComponent<Image>();
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
        //TODO: DELETE THIS AS THIS IS JUST FOR DEBUG PURPOSES
        image.fillAmount = ( ( currentDuration * 100f ) / totalDuration ) / 100f;
    }
}
