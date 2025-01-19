using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    GameObject draggedObject;
    GameObject lastItemSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
            InventorySlot slot = clickedObject.GetComponent<InventorySlot>();

            if (slot != null && slot.heldItem != null)
            {
                draggedObject = slot.heldItem;
                slot.heldItem = null;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

        if (draggedObject != null && eventData.pointerCurrentRaycast.gameObject != null && eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
            InventorySlot slot = clickedObject.GetComponent<InventorySlot>();

            if (slot != null && slot.heldItem == null)
            {
                slot.SetHeldItem(draggedObject);
                draggedObject = null;
            }
            else if (slot != null && slot.heldItem != null)
            {
                lastItemSlot.GetComponent<InventorySlot>().SetHeldItem(slot.heldItem);
                slot.SetHeldItem(draggedObject);
                draggedObject = null;
            }
        }
        
    }
}
