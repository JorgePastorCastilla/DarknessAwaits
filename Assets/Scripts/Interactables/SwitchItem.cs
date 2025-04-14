using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItem : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    public bool switchOn = false;
    public Animator animator;
    public AudioSource audioSource;
    // Update is called once per frame
    public virtual void OnMouseDown()
    {
        if (switchOn && interactiveItem != null)
        {
            if (interactiveItem.isActive)
            {
                interactiveItem.Deactivate();
                // animator.SetTrigger("TurnOff");
                //Some objects like hidden doors have invisible switches but no animation
                if (animator != null)
                {
                    animator.SetBool("isActive", false);    
                }
                
            }
            else
            {
                interactiveItem.Activate();
                // animator.SetTrigger("TurnOn");
                //Some objects like hidden doors have invisible switches but no animation
                if (animator != null)
                {
                    animator.SetBool("isActive", true);    
                }
            }
            audioSource.Play();
        }
    }
}
