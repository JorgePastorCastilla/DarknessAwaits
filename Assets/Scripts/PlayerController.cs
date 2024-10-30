using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float unitsPerMovement = 5f;
    [SerializeField]
    private float transitionSpeed = 40f;
    private float transitionRotationSpeed = 500f;

    private Vector3 restorePosition = Vector3.zero;
    private Vector3 lastDirection = Vector3.zero;
    private bool positiveLastDirection = false;

    private Vector3 targetGridPosition;
    private Vector3 prevTargetGridPosition;
    private Vector3 targetRotation;

    public GameObject camera;
    private Vector3 cameraStaticPosition;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            cameraStaticPosition = camera.transform.position;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        cameraStaticPosition = new Vector3(0,1,0);
        
        camera.transform.localPosition = cameraStaticPosition;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            // Debug.Log("Collision Wall");
            // Debug.Log($"Is at Rest:{IsAtRest()}");
            // Debug.Log($"transform position:{transform.position}");
            // Debug.Log($"TargetGridPosition:{targetGridPosition}");
            // Debug.Log($"Distance:{Vector3.Distance(transform.position, targetGridPosition)}");
            // Debug.Log($"Distance Rotation:{Vector3.Distance(transform.eulerAngles, targetRotation)}");
            
            MovePlayer(lastDirection, !positiveLastDirection);
            Vector3 newDirection = transform.position - restorePosition;
            camera.transform.position = cameraStaticPosition;
            // Debug.Log($"NEW DIRECTION:{newDirection}");
            // ForceMovePlayer(newDirection, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        targetGridPosition = Vector3Int.RoundToInt(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Restore Position:{restorePosition}");
        Debug.Log($"Current Position:{transform.position}");
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
            lastDirection = transform.forward * unitsPerMovement;
            positiveLastDirection = true;
            MovePlayer(lastDirection, positiveLastDirection);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastDirection = transform.forward * unitsPerMovement;
            positiveLastDirection = false;
            MovePlayer(lastDirection, positiveLastDirection);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lastDirection = transform.right * unitsPerMovement;
            positiveLastDirection = false;
            MovePlayer(lastDirection, positiveLastDirection);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            lastDirection = transform.right * unitsPerMovement;
            positiveLastDirection = true;
            MovePlayer(lastDirection, positiveLastDirection);
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

    // public void ForceMovePlayer(Vector3 direction, bool positive)
    // {
    //     targetGridPosition = (positive) ? targetGridPosition + direction : targetGridPosition - direction;
    // }
    public void MovePlayer(Vector3 direction, bool positive)
    {
        if (IsAtRest())
        {
            restorePosition = transform.position;
            targetGridPosition = (positive) ? targetGridPosition + direction : targetGridPosition - direction;    
        }
    }


    private bool IsAtRest()
    {
        return (Vector3.Distance(transform.position, targetGridPosition) < 0.5f && Vector3.Distance(transform.eulerAngles, targetRotation) < 0.5f);
    }


}
