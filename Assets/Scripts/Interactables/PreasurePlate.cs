using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    private void OnTriggerEnter(Collider other)
    {
        if (!interactiveItem.isActive)
        {
            interactiveItem.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactiveItem.isActive)
        {
            interactiveItem.Deactivate();
        }
    }
}
