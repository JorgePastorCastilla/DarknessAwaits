using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCinematic : MonoBehaviour
{
    
    public bool deactivate = false;
    public GameObject nextCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deactivate)
        {
            Destroy(this.gameObject);  
            nextCamera.SetActive(true);
            
        }
    }
    
}
