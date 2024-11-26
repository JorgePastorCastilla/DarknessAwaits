using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    private void OnTriggerEnter(Collider other)
    {
        ActivateToggle();
    }

    private void OnTriggerExit(Collider other)
    {
        ActivateToggle();
    }

    private void ActivateToggle()
    {
        if (interactiveItem.isActive)
        {
            interactiveItem.Deactivate();
        }
        else
        {
            interactiveItem.Activate();
        }
    }
}
