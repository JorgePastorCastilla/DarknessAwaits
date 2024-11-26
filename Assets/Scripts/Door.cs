using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveItem
{
    private Vector3 openOffset = new Vector3(0, 4f, 0);
    private Vector3 closePosition;
    private float transitionSpeed = 1.5f;
    
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        closePosition = transform.position;
        AssignTargetPosition();
    }
    // protected override void Update()
    // {
    //     Debug.Log("Se manda mensaje");
    //     base.Update();
    // }
    private void MoveDoor()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);    
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
