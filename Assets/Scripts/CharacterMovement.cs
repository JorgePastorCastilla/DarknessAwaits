using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    private float unitsPerMovement;
    [SerializeField]
    private float transitionSpeed = 20f;
    [SerializeField]
    private float transitionRotationSpeed = 350f;

    private Vector3 restorePosition = Vector3.zero;

    private Vector3 targetGridPosition;
    private Vector3 targetRotation;
    

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
    }

    void Update()
    {
  
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
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

    public void MovePlayer(Vector3 direction)
    {
        if (IsAtRest())
        {
            direction = direction * unitsPerMovement;
            restorePosition = transform.position;
            // targetGridPosition = (positive) ? targetGridPosition + direction : targetGridPosition - direction;    
            targetGridPosition = targetGridPosition + direction;    

        }
    }


    private bool IsAtRest()
    {
        return (Vector3.Distance(transform.position, targetGridPosition) < 0.05f && Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f);
    }


}
