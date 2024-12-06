using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement playerMovement;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
            gameManager = GameManager.instance;
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
    }


}
