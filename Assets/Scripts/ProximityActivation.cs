using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProximityActivation : MonoBehaviour
{
    //TODO ONTRIGGER ENTER ONTRIGGER EXIT HABILITAR LOS OBJETOS
    // Start is called before the first frame update
    public SwitchItem[] scriptsToActivate;
    private bool isInRange = false;
    void Start()
    {
        ActivateToggle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            ActivateToggle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            ActivateToggle();
        }
    }

    void ActivateToggle()
    {
        if (isInRange)
        {
            foreach (SwitchItem script in scriptsToActivate)
            {
                script.switchOn = true;
            }
        }
        else
        {
            foreach (SwitchItem script in scriptsToActivate)
            {
                script.switchOn = false;
            }
        }
    }
}

