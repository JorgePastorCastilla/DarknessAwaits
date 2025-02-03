using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public bool isActive = false;
    public bool onlyActivateOnce = false;
    private bool alreadyActivated = false;
    public AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isActive)
        {
            ActiveAction();
        }
        else
        {
            DeactiveAction();
        }
    }

    public void Activate()
    {
        bool previousValueActive = isActive;
        if (!isActive)
        {
            if (onlyActivateOnce)
            {
                if (!alreadyActivated)
                {
                    isActive = true;    
                }
            }
            else
            {
                isActive = true;
            }
        }

        if (previousValueActive != isActive)
        {
            OnActivate();    
        }
        
    }

    public void Deactivate()
    {
        bool previousValueActive = isActive;
        isActive = false;
        if (previousValueActive != isActive)
        {
            OnDeactivate();
        }
    }

    public virtual void ActiveAction()
    {
        
    }

    public virtual void DeactiveAction()
    {
        
    }

    public virtual void OnActivate()
    {
        
    }
    public virtual void OnDeactivate()
    {
        
    }
}
