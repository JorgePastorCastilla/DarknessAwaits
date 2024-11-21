using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Pathfinder : MonoBehaviour
{
    public Vector3 finalPosition;
    public Vector3 startPosition;
    private List<Vector3> foundCells = new List<Vector3>();
    private List<Vector3> alreadyCheckCells = new List<Vector3>();
    private float maxToTimeOut = 5f;
    
    [SerializeField]
    // private List<Transform> patrolPath = new List<Transform>();
    private List<Cell> patrolPath = new List<Cell>();
    
    private Vector3[] directions = {
        Vector3.forward * GameManager.gridCellSize,
        Vector3.back * GameManager.gridCellSize,
        Vector3.left * GameManager.gridCellSize,
        Vector3.right * GameManager.gridCellSize
    };
    
    // Start is called before the first frame update
    void Start()
    {
        // startPosition = transform.position;
        // patrolPath = FindPath(startPosition, finalPosition);
        
        // Debug.Log(patrolPath.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position+finalPosition);
        //Debug.Log(isObjectHere(transform.position+finalPosition));
    }

    public List<Vector3> FindPath(Vector3 startPosition, Vector3 finalPosition)
    {
        float startTime = Time.time;
        Cell StartCell = new Cell(startPosition);
        StartCell.calculateGHF(startPosition, finalPosition);
        
        List<Vector3> path = new List<Vector3>();
        List<Cell> foundCells = new List<Cell>();
        List<Cell> alreadyCheckCells = new List<Cell>();

        foundCells.Add(StartCell);
        Cell currentCell = StartCell;
        while ( !positionIsInCells(alreadyCheckCells, finalPosition) )
        {
            if (Time.time - startTime > maxToTimeOut)
            {
                return path;
                break;
            }
            foundCells = foundCells.OrderBy(x => x.f).ToList();
            int i = 0;
            currentCell = foundCells[i];
            while (positionIsInCells(alreadyCheckCells, currentCell.position))
            {
                
                if (i < foundCells.Count - 1)
                {
                    i++;    
                }
                currentCell = foundCells[i];
            }
            List<Cell> neighbours = GetNeighbours( currentCell );
            foreach (Cell cell in neighbours)
            {
                if ( !positionIsInCells(foundCells, cell.position) )
                {
                    foundCells.Add(cell);
                }
            }

            alreadyCheckCells.Add(currentCell);
        }
        
        Cell endCell = GetCellByPosition(alreadyCheckCells,finalPosition);
        
        foreach (Cell cell in GetPathFromFinalCell(endCell))
        {
            path.Add(cell.position);
        }
        return path;
    }



    private Cell GetCellByPosition(List<Cell> cells, Vector3 position)
    {
        foreach (Cell cell in cells)
        {
            if (Vector3.Distance(position, cell.position) < 0.05f)
            {
                return cell;
            }
        }

        return null;
    }

    private List<Cell> GetPathFromFinalCell(Cell finalCell)
    {
        List<Cell> path = new List<Cell>();
        Cell currentCell = finalCell;
        while (currentCell.parent != null)
        {
            path.Add(currentCell);
            currentCell = currentCell.parent;
        }
        path.Add(currentCell);
        
        path.Reverse();
        
        return path;
    }
    

    private bool positionIsInCells(List<Cell> cells, Vector3 position)
    {
        foreach (Cell cell in cells)
        {
            if (Vector3.Distance(cell.position, position) < 0.05f)
            {
                return true;
            }
        }

        return false;
    }

    private List<Cell> GetNeighbours(Cell cell)
    {
        Vector3 cellPosition = cell.position;
        List<Cell> neighboursCells = new List<Cell>();
        
        for (int i = 0; i < directions.Length; i++)
        {
            Vector3 neighbourPosition = cellPosition + directions[i];
            if ( !isObjectHere(neighbourPosition) )
            {
                Cell neighbour = new Cell(neighbourPosition, cell);
                neighbour.calculateGHF(startPosition, finalPosition);
                
                neighboursCells.Add(neighbour);
            }
        }
        return neighboursCells;
    }
    
    //Method to check if there is an object at given position
    private bool isObjectHere(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 0.01f);
        // return (intersecting.Length != 0);
        //The code below checks if there is a wall there and return true if there is
        if (intersecting.Length != 0)
        {
            foreach (var obj in intersecting)
            {
                //TODO POSIBLE CHANGE INSTEAD OF COMPARING TO WALL CHECK VARIOUS TAGS FOR OBSTACLES
                if ( intersecting[0].CompareTag("Wall") )
                {
                    return true;
                }
            }
            
        }
        
        return false;
        
    }
}

public class Cell
{
    public Vector3 position;

    public Cell parent;
    // public bool walkable;

    // public float costFromStart;
    // public float costFromFinish;
    
    //G ->  is the cost of the path from the start node
    //H -> is a heuristic function that estimates the cost of the cheapest path to the goal
    //F -> G+H
    public float f, g, h;

    public Cell(Vector3 position, Cell parent)
    {
        this.position = position;
        this.parent = parent;
    }
    public Cell(Vector3 position)
    {
        this.position = position;
    }

    public void calculateGHF(Vector3 startPosition, Vector3 finalPosition)
    {
        this.g = Vector3.Distance(this.position, startPosition);
        this.h = Vector3.Distance(this.position, finalPosition);
        this.f = this.g + this.h;
    }
}
