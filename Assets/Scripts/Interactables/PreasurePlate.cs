using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlate : MonoBehaviour
{
    public InteractiveItem[] interactiveItems;
    public PreasurePlateInventory preasurePlateInventory;
    public AudioSource audioSource;
    public Animator animator;
    private void Start()
    {
        preasurePlateInventory = gameObject.GetComponent<PreasurePlateInventory>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if ( other.CompareTag("Player") && !preasurePlateInventory.itemPlaced )
        {
            audioSource.Play();
            animator.SetBool("isActive", true);
            ActivateItems();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.CompareTag("Player") && !preasurePlateInventory.itemPlaced )
        {
            audioSource.Play();
            animator.SetBool("isActive", false);
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
