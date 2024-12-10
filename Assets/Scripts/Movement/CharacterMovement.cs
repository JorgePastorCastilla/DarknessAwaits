using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    private float unitsPerMovement;
    public float transitionSpeed = 15f;
    public float transitionRotationSpeed = 350f;

    private Vector3 restorePosition = Vector3.zero;

    public Vector3 targetGridPosition;
    public Vector3 targetRotation;

    private float moveCooldown = 0.5f;
    private float lastTimeMoved = 0f;
    public bool alreadyRotating = false;
    

    private void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.CompareTag("Wall") )
        {
            targetGridPosition = restorePosition;
        }
    }
    void Start()
    {
        unitsPerMovement = GameManager.gridCellSize;
        targetGridPosition = transform.position;
        targetRotation = transform.eulerAngles;
    }

    void Update()
    {
  
    }
    private void FixedUpdate()
    {
        Move();
        
    }
    private void Move()
    {
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
        if (!alreadyRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
        }
    }
    public void RotateLeft()
    {
        if ( IsAtRest() )
        {
            lastTimeMoved = Time.time;
            targetRotation -= Vector3.up * 90f;
        }
    }
    public void RotateRight()
    {
        if ( IsAtRest() )
        {
            lastTimeMoved = Time.time;
            targetRotation += Vector3.up * 90f;
        }
    }

    public void Move(Vector3 direction)
    {
        if ( canMove() )
        {
            lastTimeMoved = Time.time;
            direction = direction * unitsPerMovement;
            restorePosition = transform.position;
            // targetGridPosition = (positive) ? targetGridPosition + direction : targetGridPosition - direction;    
            targetGridPosition = targetGridPosition + direction;    

        }
    }

    public void IAMove()
    {
        transform.LookAt(targetGridPosition);
        Move();
    }

    private bool canMove()
    {
        return IsAtRest() && Time.time - lastTimeMoved > moveCooldown;
    }

    public bool IsAtRest()
    {
        return (Vector3.Distance(transform.position, targetGridPosition) < 0.05f && Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f);
    }


}
