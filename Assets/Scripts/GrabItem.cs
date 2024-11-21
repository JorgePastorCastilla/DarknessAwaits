using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    
    public GameObject grabItem;
    public GameObject text;
    private bool canGrabItem = false;
    
    public Door door;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrabItem)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
                grabItem.SetActive(true);
                text.SetActive(false);
                door.doorIsOpen = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        canGrabItem = true;
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        canGrabItem = false;
    }

    private void OnTriggerStay(Collider other)
    {
        canGrabItem = other.gameObject.CompareTag("Player");
    }
}
