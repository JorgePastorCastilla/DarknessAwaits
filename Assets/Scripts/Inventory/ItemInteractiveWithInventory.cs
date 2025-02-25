using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractiveWithInventory : MonoBehaviour
{
    public InteractiveItem[] interactiveItems;
    public string[] validObjects;
    public AudioSource audioSource;

    private void Start()
    {
    }

    public virtual void Interact(GameObject item)
    {
        // DoSomething with item
        if (isValid(item))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            ActivateItems();
        }
    }

    public bool isValid(GameObject item)
    {
        
        string objectName = item.GetComponent<InventoryItem>().itemScriptableObject.name;
        
        for (int i = 0; i < validObjects.Length; i++)
        {
            if (objectName == validObjects[i])
            {
                return true;
            }
        }
        return false;
    }

    public void ActivateItems()
    {
        foreach (InteractiveItem item in interactiveItems)
        {
            item.Activate();
        }
    }
    
    public void DeactivateItems()
    {
        foreach (InteractiveItem item in interactiveItems)
        {
            item.Deactivate();
        }
    }
}
