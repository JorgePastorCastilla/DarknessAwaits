using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement playerMovement;
    public GameManager gameManager;
    private CharacterMovement _characterMovement;
    public Transform camera;
    public Quaternion cameraRotation = new Quaternion();
    float horizontalRotation = 0f;
    float verticalRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
            gameManager = GameManager.instance;
            _characterMovement = GetComponent<CharacterMovement>();
            cameraRotation = camera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Comprobar si conviene usar VARIABLES LIKE FORWARD,BACKWARD, RIGHT, LEFT AND CHANGE THEM AS WE ROTATE
        //TODO: CAMBIAR AL NEW INPUT SYSTEM
        //MOVEMENT
        if ( Input.GetKeyDown(KeyCode.A) )
        {
            playerMovement.RotateLeft();
        }
        if ( Input.GetKeyDown(KeyCode.D) )
        {
            playerMovement.RotateRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerMovement.Move(transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMovement.Move(-transform.forward);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            playerMovement.Move(-transform.right);
        }
        if (Input.GetKey(KeyCode.E))
        {
            playerMovement.Move(transform.right);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameManager.pauseMenuCanvas.activeSelf)
            {
                gameManager.OpenCanvas(gameManager.pauseMenuCanvas);    
            }
            else
            {
                gameManager.CloseCanvas(gameManager.pauseMenuCanvas);
            }
            
        }
        //TODO El codigo de abajo hay que revisarlo entero
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            horizontalRotation = camera.rotation.eulerAngles.y;
            verticalRotation = 0f;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _characterMovement.alreadyRotating = true;
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 300f;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 300f;

            // float horizontalRotation = mouseX;
            camera.Rotate(Vector3.up, horizontalRotation);
            Vector3 rotation = new Vector3(verticalRotation, horizontalRotation, 0f);
        
            horizontalRotation += mouseX;
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        
            camera.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                float cameraRotationY = camera.localEulerAngles.y;
                Debug.Log("Camera rotation is: " + cameraRotationY);
                if (cameraRotationY > 315 || cameraRotationY <= 45)
                {
                    Debug.Log("Forward");
                    // _characterMovement.targetRotation += Vector3.up * 0;
                }else if (cameraRotationY > 45 && cameraRotationY <= 135)
                {
                    Debug.Log("Right");
                    _characterMovement.targetRotation += Vector3.up * 90;
                }else if (cameraRotationY > 135 && cameraRotationY <= 225)
                {
                    Debug.Log("Backward");
                    _characterMovement.targetRotation += Vector3.up * 180;
                }else if (cameraRotationY > 225 && cameraRotationY <= 315)
                {
                    Debug.Log("Left");
                    _characterMovement.targetRotation -= Vector3.up * 90;
                }
                camera.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_characterMovement.targetRotation), Time.deltaTime * _characterMovement.transitionRotationSpeed);
                _characterMovement.alreadyRotating = false;
                
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }


}
