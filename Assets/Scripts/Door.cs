using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorIsOpen = false;
    private Vector3 openOffset = new Vector3(0, 4f, 0);
    private Vector3 closePosition;
    private float transitionSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        closePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveDoor();
    }

    private void MoveDoor()
    {
        Vector3 targetPosition;
        if (doorIsOpen)
        {
            targetPosition = closePosition + openOffset;
        }
        else
        {
            targetPosition = closePosition;
        }

        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);    
        }
        
        
    }
}
