using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPrototype : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Player win
            GameManager.instance.PlayerWin();
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
