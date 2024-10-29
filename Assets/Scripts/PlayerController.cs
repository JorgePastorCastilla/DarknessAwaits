using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float transitionSpeed = 10f;
    private float transitionRotationSpeed = 500f;


    private Vector3 targetGridPosition;
    private Vector3 prevTargetGridPosition;
    private Vector3 targetRotation;


    // Start is called before the first frame update
    void Start()
    {
        targetGridPosition = Vector3Int.RoundToInt(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.A) )
        {
            RotateLeft();
        }
        if ( Input.GetKeyDown(KeyCode.D) )
        {
            RotateRight();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(transform.forward, true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(transform.forward, false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MovePlayer(transform.right, false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MovePlayer(transform.right, true);
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        prevTargetGridPosition = targetGridPosition;

        Vector3 targetPosition = targetGridPosition;

        if (targetRotation.y > 270f && targetRotation.y < 361f)
        {
            targetRotation.y = 0f;
        }
        if ( targetRotation.y < 0f)
        {
            targetRotation.y = 270f;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
        
    }


    public void RotateLeft()
    {
        if ( IsAtRest())
        {
            targetRotation -= Vector3.up * 90f;
        }
    }
    public void RotateRight()
    {
        if (IsAtRest())
        {
            targetRotation += Vector3.up * 90f;
        }
    }
    public void MovePlayer(Vector3 direction, bool positive)
    {
        targetGridPosition = (positive) ? targetGridPosition + direction : targetGridPosition - direction;
    }


    private bool IsAtRest()
    {
        return (Vector3.Distance(transform.position, targetGridPosition) < 0.05f && Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f);
    }


}
