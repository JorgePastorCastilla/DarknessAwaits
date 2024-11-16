using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
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
            playerMovement.MovePlayer(transform.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMovement.MovePlayer(-transform.forward);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            playerMovement.MovePlayer(-transform.right);
        }
        if (Input.GetKey(KeyCode.E))
        {
            playerMovement.MovePlayer(transform.right);
        }
    }
}
