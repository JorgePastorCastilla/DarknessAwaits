using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

    public void Update()
    {
        base.Update();
        float distance = Vector3.Distance(closePosition + openOffset, gameObject.transform.position);
        gameObject.GetComponent<BoxCollider>().isTrigger = !(distance < 0.1f);
        // gameObject.GetComponent<BoxCollider>().isTrigger = !(gameObject.transform.position == closePosition + openOffset);
        
    }
}
