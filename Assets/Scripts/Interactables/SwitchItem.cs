using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItem : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    // Start is called before the first frame update
    public bool switchOn = false;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void OnMouseDown()
    {
        if (switchOn)
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
        }
    }
}
