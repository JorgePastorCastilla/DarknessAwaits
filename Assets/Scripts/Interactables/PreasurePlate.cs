using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    public InteractiveItem[] interactiveItems;
    public PreasurePlateInventory preasurePlateInventory;
    public AudioSource audioSource;
    private void Start()
    {
        preasurePlateInventory = gameObject.GetComponent<PreasurePlateInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if ( other.CompareTag("Player") && !preasurePlateInventory.itemPlaced )
        {
            audioSource.Play();
            ActivateItems();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.CompareTag("Player") && !preasurePlateInventory.itemPlaced )
        {
            audioSource.Play();
            DeactivateItems();
        }
    }
    
    public void ActivateItems()
    {
        foreach (InteractiveItem item in interactiveItems)
        {
            if (!item.isActive)
            {
                item.Activate();
            }
        }
    }
    
    public void DeactivateItems()
    {
        foreach (InteractiveItem item in interactiveItems)
        {
            if (item.isActive)
            {
                item.Deactivate();
            }
        }
    }
}
