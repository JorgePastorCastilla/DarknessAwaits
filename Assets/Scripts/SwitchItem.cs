using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItem : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    // Start is called before the first frame update
    public bool switchOn = false;
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
            }
            else
            {
                interactiveItem.Activate();
            }
        }
    }
}
