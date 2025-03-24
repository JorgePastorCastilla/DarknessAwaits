using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using RenderSettings = UnityEngine.RenderSettings;

public class TorchlightTimer : MonoBehaviour
{
 
    private float totalDuration = 240f;// 4min/240secs
    private float currentDuration;
    private GameManager gameManager;

    //TODO: DELETE THIS AS THIS IS JUST FOR DEBUG PURPOSES
    // private Image image;

    public float fogValue;
    public float finalFogValue = 1f;
    public float fogReduction;

    public float torchLightRange;
    public float finalTorchLightRange = 0f;
    public float torchReduction;

    public float torchFlameScale;
    public float finalTorchFlameScale = 0f;
    public float torchFlameReduction;
    
    public float reductionCooldown;
    
    public Light torch;
    public GameObject torchFlame;

    public float lastReductionTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        currentDuration = totalDuration;
        //TODO: DELETE THIS AS THIS IS JUST FOR DEBUG PURPOSES
        // image = GameObject.Find("TorchTimerCanva").transform.GetChild(0).Find("Fill").gameObject.GetComponent<Image>();
        
        torch = transform.Find("Visuals").Find("Light").GetComponent<Light>();
        torchFlame = transform.Find("Visuals").Find("Torch_B").Find("VFX_Fire_01_Small_Smoke").gameObject;

        torchFlameScale = torchFlame.transform.localScale.x;
        fogValue = RenderSettings.fogDensity - finalFogValue;
        
        float totalReductionDuration = totalDuration - 1f; 
        reductionCooldown = totalReductionDuration / (30*totalReductionDuration);
        torchReduction = torch.range / totalReductionDuration * reductionCooldown;
        fogReduction = fogValue / totalReductionDuration * reductionCooldown;
        torchFlameReduction = torchFlameScale / totalReductionDuration * reductionCooldown;
        
        // lightIntensityReduction = light.intensity / timeToFadeOut * lightReductionCooldown;
        
        
        lastReductionTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;
        }

        if (Time.time - lastReductionTime > reductionCooldown)
        {
            lastReductionTime = Time.time;
            if (torch.range > 5f || currentDuration < 5f)
            {
                if (currentDuration < 5f)
                {
                    reductionCooldown = currentDuration / (30*currentDuration);
                    torchReduction = torch.range / currentDuration * reductionCooldown;
                }
                lastReductionTime = Time.time;
                torch.range -= torchReduction;
            }
            if (torchFlame.transform.localScale.x > 0.1f || currentDuration < 5f)
            {
                if (currentDuration < 5f)
                {
                    reductionCooldown = currentDuration / (30*currentDuration);
                    torchFlameReduction = torchFlame.transform.localScale.x / currentDuration * reductionCooldown;
                }
                lastReductionTime = Time.time;
                float newScale = torchFlame.transform.localScale.x;
                newScale -= torchFlameReduction;
                torchFlame.transform.localScale = new Vector3(newScale, newScale, newScale);
            }

            if (RenderSettings.fogDensity <= 1)
            {
                RenderSettings.fogDensity -= fogReduction;
            }
        }
        
        // Debug.Log($"Current Duration: {currentDuration}");
        if(currentDuration <= 0)
        {
            gameManager.PlayerDeath();
            this.enabled = false;
        }
        //TODO: DELETE THIS AS THIS IS JUST FOR DEBUG PURPOSES
        // image.fillAmount = ( ( currentDuration * 100f ) / totalDuration ) / 100f;
    }
}
