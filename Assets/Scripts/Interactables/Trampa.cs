using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : Door
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Trampa");
            other.gameObject.GetComponent<PlayerHealth>().DealDamage(50f);
        }
    }
}
