using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchlightFlicker : MonoBehaviour
{
    
    private float minIntensity;
    private float maxIntensity;
    private float flickerRate = 0.15f;

    public Light light;
    private float flickerCoolDown = 0.1f;
    private float LastActivation = 0f;
    private float lightIntensity;

    private bool isIncreasing = true;
    // Start is called before the first frame update
    void Start()
    {
        minIntensity = light.intensity - (flickerRate * 2);
        maxIntensity = light.intensity + (flickerRate * 2);
        lightIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastActivation > flickerCoolDown)
        {
            LastActivation = Time.time;
            Flicker();
            // light.intensity = Random.Range(-flickerRate+lightIntensity , flickerRate+lightIntensity );
        }
        // float currentLightPercentage =  (currentDuration * lightIntensity) / totalDuration;
        
    }

    public void Flicker()
    {
         
        if (lightIntensity + flickerRate > maxIntensity)
        {
            isIncreasing = false;
        }

        if (lightIntensity - flickerRate < minIntensity)
        {
            isIncreasing = true;
        }
        
        if (isIncreasing)
        {
            lightIntensity += flickerRate;
        }
        else
        {
            lightIntensity -= flickerRate;
        } 
        
        float probabilityToSkip = 20f;//20% probability
        if (Random.Range(0f,100f) >= probabilityToSkip )
        {
            light.intensity = lightIntensity;
        }
        
    }
}
