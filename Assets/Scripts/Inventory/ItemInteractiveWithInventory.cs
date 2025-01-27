using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractiveWithInventory : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    public string[] validObjects;

    public void Interact(GameObject item)
    {
        // DoSomething with item
        if (isValid(item))
        {
            interactiveItem.Activate();
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
}
