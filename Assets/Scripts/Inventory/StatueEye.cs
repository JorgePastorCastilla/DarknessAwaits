using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueEye : ItemInteractiveWithInventory
{
    public bool eyeIsActive = false;
    public StatueEye otherEye;
    
    public override void Interact(GameObject item)
    {
        // DoSomething with item
        if (isValid(item))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            eyeIsActive = true;
            
            GameObject prefab = item.GetComponent<InventoryItem>().itemScriptableObject.prefab;
            GameObject jewel = Instantiate(prefab, transform.position, transform.rotation);
            
            jewel.transform.parent = transform;
            jewel.transform.localPosition = Vector3.zero;
            jewel.transform.localRotation = Quaternion.identity;
            jewel.transform.localScale = Vector3.one;
            
            if (otherEye.eyeIsActive)
            {
                ActivateItems();
            }
        }
    }
}
