using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveItem
{
    public Vector3 openOffset;
    public Vector3 closePosition;
    public float transitionSpeed;
    
    public Vector3 targetPosition;
    public bool audioIsOn = false;
    // Start is called before the first frame update
    public virtual void Start()
    {
        if (openOffset == Vector3.zero)
        {
            float altura = (gameObject.transform.position.y * 2) * 1f;
            openOffset = new Vector3(0, altura, 0);
        }

        if (transitionSpeed == 0)
        {
            transitionSpeed = 1.5f;
        }
        closePosition = transform.position;
        
        AssignTargetPosition();
    }

    private void MoveDoor()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.time = 1f;
                audioSource.Play();
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);    
        }
        else
        {
            audioSource.Stop();
        }
    }
    
    public override void ActiveAction()
    {
        MoveDoor();
    }

    public override void DeactiveAction()
    {
        MoveDoor();
    }

    public override void OnActivate()
    {
        AssignTargetPosition();
    }

    public override void OnDeactivate()
    {
        AssignTargetPosition();
    }

    private void AssignTargetPosition()
    {
        if (this.isActive)
        {
            targetPosition =  closePosition + openOffset;
        }
        else
        {
            targetPosition = closePosition;
        }
    }
}
