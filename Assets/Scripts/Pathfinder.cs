using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Pathfinder : MonoBehaviour
{
    public Vector3 finalPosition;
    public Vector3 startPosition;
    private List<Cell> grid = new List<Cell>();
    [SerializeField]
    private List<Transform> patrolPath = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        CreateGrid();
        SetGridCellValues();
        Debug.Log(grid.Count());
        // foreach (Cell cell in grid)
        // {
        //     Debug.Log($"Cell x:{cell.x} z:{cell.z} walkable:{cell.walkable}");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position+finalPosition);
        //Debug.Log(isObjectHere(transform.position+finalPosition));
    }

    private void CreateGrid()
    {
        
        //Comprobar como hacer que coja las casillas correctamente
        // float currentXPosition = transform.position.x;
        // float currentZPosition = transform.position.z;
        
        float currentXPosition = -12.5f;
        float currentZPosition = -12.5f;
        
        // float finalXPosition = finalPosition.x;
        // float finalZPosition = finalPosition.z;
        
        float finalXPosition = 22.5f;
        float finalZPosition = 12.5f;
        
        float xDifference = Math.Abs( currentXPosition - finalXPosition );
        float zDifference = Math.Abs( currentZPosition - finalZPosition );
        Debug.Log($"xDifference: {xDifference} / zDifference: {zDifference}");
        xDifference = (xDifference / GameManager.gridCellSize)+1;
        zDifference = (zDifference / GameManager.gridCellSize)+1;
        Debug.Log($"xDifference: {xDifference} / zDifference: {zDifference}");
        Debug.Log($"xDifference Floor: {Math.Floor(xDifference)} / zDifference Floor: {Math.Floor(zDifference)}");
        float currentX = 0f;
        float currentZ = 0f;
        for (int x =0; x < Math.Floor(xDifference); x++)
        {
            currentX = currentXPosition + (x * GameManager.gridCellSize);
            for (float z =0; z < Math.Floor(zDifference); z++)
            {
               currentZ = currentZPosition + (z * GameManager.gridCellSize); 
               
               Vector3 cellPosition = new Vector3(currentX, gameObject.transform.position.y, currentZ);
               bool walkable = !isObjectHere(cellPosition);
               Cell cell = new Cell(currentX, currentZ, walkable);
               
               grid.Add(cell);
            }
        }
    }

    private void GetNeighbours(Cell cell)
    {
        
    }

    private void SetGridCellValues()
    {
        foreach (Cell cell in grid)
        {
            Vector3 cellPosition = new Vector3(cell.x, gameObject.transform.position.y, cell.z);
            float distanceFromStart = Vector3.Distance(cellPosition, startPosition);
            cell.g = distanceFromStart;

            float distanceToFinish = Vector3.Distance(cellPosition, finalPosition);
            cell.h = distanceToFinish;
            cell.f = cell.g + cell.h;
        }
    }
    //Method to check if there is an object at given position
    private bool isObjectHere(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 0.01f);
        return (intersecting.Length != 0);
    }
}

public class Cell
{
    public float x;
    public float z;
    public bool walkable;

    // public float costFromStart;
    // public float costFromFinish;
    
    //G ->  is the cost of the path from the start node
    //H -> is a heuristic function that estimates the cost of the cheapest path to the goal
    //F -> G+H
    public float f, g, h;

    public Cell(float x, float z, bool walkable)
    {
        this.x = x;
        this.z = z;
        this.walkable = walkable;
    }
}
