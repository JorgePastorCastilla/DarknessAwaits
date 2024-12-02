using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private Vector3 target;
    private List<Vector3> path = new List<Vector3>();
    private int currentNodeOfPath = 0;
    [SerializeField]
    private Pathfinder pathfinder;
    public List<Transform> checkpoints;
    private int currentNodeOfCheckpoint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // pathfinder = gameObject.GetComponent<Pathfinder>();
        path = pathfinder.FindPath(transform.position, checkpoints[currentNodeOfCheckpoint].position);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(transform.position, checkpoints[currentNodeOfCheckpoint].position) < 0.05f && gameObject.GetComponent<CharacterMovement>().IsAtRest() )
        // {
        //     if (currentNodeOfCheckpoint == checkpoints.Count - 1)
        //     {
        //         currentNodeOfCheckpoint = 0;
        //     }
        //     else
        //     {
        //         currentNodeOfCheckpoint++;       
        //     }
        //     path = pathfinder.FindPath(transform.position, checkpoints[currentNodeOfCheckpoint].position);
        // }
        // else
        if (transform.position == path[currentNodeOfPath] && currentNodeOfPath < path.Count)
        {
            if (currentNodeOfPath == path.Count - 1)
            {
                if (currentNodeOfCheckpoint == checkpoints.Count - 1)
                {
                    currentNodeOfCheckpoint = 0;
                }
                else
                {
                    currentNodeOfCheckpoint++;       
                }
                path = pathfinder.FindPath(transform.position, checkpoints[currentNodeOfCheckpoint].position);
                currentNodeOfPath = 0;
            }
            else
            {
                currentNodeOfPath++;
            }
        }
        else
        {
            Vector3 current = (path[currentNodeOfPath] - transform.position) / GameManager.gridCellSize;
            gameObject.GetComponent<CharacterMovement>().Move(current);
            // TODO pendiente programar un LookAt en CharacterMovement.cs para rotar antes de moverse
            // gameObject.transform.LookAt( this.path[currentNodeOfPath] );
            // TODO NECESARIO CAMBIAR A ESTE METODO PARA QUE LA IA ROTE ANTES DE MOVERSE
            // gameObject.GetComponent<CharacterMovement>().IAMove(current);

        }

        // {
        // }
    }
}
