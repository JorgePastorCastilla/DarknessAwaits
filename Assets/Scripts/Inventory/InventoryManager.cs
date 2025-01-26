using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    [SerializeField] GameObject[] slots = new GameObject[8];
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject ItemsContainer;
    
    GameObject draggedObject;
    GameObject lastItemSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (draggedObject != null)
        {
            draggedObject.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnPointerDown");
        Debug.Log(eventData.pointerCurrentRaycast.gameObject);
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
            InventorySlot slot = clickedObject.GetComponent<InventorySlot>();

            if (slot != null && slot.heldItem != null)
            {
                draggedObject = slot.heldItem;
                slot.heldItem = null;
                lastItemSlot = clickedObject;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("OnPointerUp");
        Debug.Log(eventData.pointerCurrentRaycast.gameObject);

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
            else
            {
                //EVENTDATA GAMEOBJECT ISN'T NULL BUT ITEM DRAG OVER SOMETHING THAT ISN'T A SLOT
                lastItemSlot.GetComponent<InventorySlot>().SetHeldItem(draggedObject);
                draggedObject = null;
            }
        }
        else if(draggedObject != null && eventData.button == PointerEventData.InputButton.Left)
        {
            //WHEN DRAGGING AND OBJECT AND DROPPING OVER NULL OBJECT
            lastItemSlot.GetComponent<InventorySlot>().SetHeldItem(draggedObject);
            draggedObject = null;
        }
        
    }

    public void ItemPicked(GameObject pickedItem)
    {
        GameObject emptySlot = null;

        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i].GetComponent<InventorySlot>();

            if (slot.heldItem == null)
            {
                emptySlot = slots[i];
                break;
            }
        }

        if (emptySlot != null)
        {
            GameObject newItem = Instantiate(itemPrefab);
            newItem.GetComponent<InventoryItem>().itemScriptableObject = pickedItem.GetComponent<ItemPickable>().itemScriptableObject;
            newItem.transform.SetParent(ItemsContainer.transform);//SET PARENT
            newItem.transform.position = emptySlot.transform.position;
            newItem.transform.localScale = Vector3.one;
            
            emptySlot.GetComponent<InventorySlot>().heldItem = newItem;
            
            Destroy(pickedItem);
        }
    }
    
    private void OnApplicationPause (bool paused)
    {
        if (draggedObject != null && paused)
        {
            // Not focused
            lastItemSlot.GetComponent<InventorySlot>().SetHeldItem(draggedObject);
            draggedObject = null;
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (draggedObject != null && !hasFocus)
        {
            // Not focused
            lastItemSlot.GetComponent<InventorySlot>().SetHeldItem(draggedObject);
            draggedObject = null;
        }
    }
}
