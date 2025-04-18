using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabItem : MonoBehaviour
{
    
    public GameObject text;
    private bool canGrabItem = false;
    public Transform playerHand;
    public InteractiveItem door;
    public GameObject torchWall;
    public GameObject torchHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            GrabObject();
        }*/
        
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

    private void GrabObject()
    {
        if (canGrabItem)
        {
            transform.parent = playerHand;
            // gameObject.SetActive(false);
            // grabItem.SetActive(true);
            // text.SetActive(false);
            this.gameObject.GetComponent<GrabItem>().enabled = false;
            Collider[] colliders = this.gameObject.GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
            text.SetActive(false);
            torchWall.SetActive(false);
            torchHand.SetActive(true);
            transform.position = playerHand.transform.position;
            transform.rotation = playerHand.transform.rotation;
            gameObject.AddComponent<TorchlightTimer>();
            if (door != null)
            {
                door.Activate();    
            }
        }
        
    }

    public void OnMouseDown()
    {
        GrabObject();
    }
}
