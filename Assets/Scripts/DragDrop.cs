using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
    }

    private void OnMouseDrag()
    {
        Debug.Log("MouseDrag");
    }
}
