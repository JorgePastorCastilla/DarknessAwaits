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
        gameObject.GetComponent<BoxCollider>().isTrigger = !(gameObject.transform.position == closePosition + openOffset);
    }
}
