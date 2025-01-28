using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlateInventory : ItemInteractiveWithInventory
{
    public Transform placedObjectPosition;
    public GameObject placedObject;
    public bool itemPlaced = false;

    public void Update()
    {
        if (itemPlaced && placedObject == null)
        {
            itemPlaced = false;
            interactiveItem.Deactivate();
        }
    }

    public override void Interact(GameObject item)
    {
        if (isValid(item))
        {
            itemPlaced = true;
            placedObject = GameObject.Instantiate(item.GetComponent<InventoryItem>().itemScriptableObject.prefab, placedObjectPosition.position, new Quaternion(0,0,0,0) );
            interactiveItem.Activate();
        }
    }
}
