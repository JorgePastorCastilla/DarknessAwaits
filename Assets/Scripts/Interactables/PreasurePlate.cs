using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    public PreasurePlateInventory preasurePlateInventory;

    private void Start()
    {
        preasurePlateInventory = gameObject.GetComponent<PreasurePlateInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if ( other.CompareTag("Player") && !preasurePlateInventory.itemPlaced && !interactiveItem.isActive )
        {
            interactiveItem.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.CompareTag("Player") && !preasurePlateInventory.itemPlaced && interactiveItem.isActive )
        {
            interactiveItem.Deactivate();
        }
    }
}
