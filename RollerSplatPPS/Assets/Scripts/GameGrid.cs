using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    int height = 10;
    int width = 10;
    float gridSpaceSize = 1;
    [SerializeField]
    private GameObject gridCellPrefab;
    GameObject[,] gameGrid;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }
    // Creates the grid when game starts
    void CreateGrid()
    {
        gameGrid = new GameObject[height, width];
        if (gridCellPrefab == null)
        {
            Debug.LogError("ERROR: gridCellPrefab on the game grid is not assigned");
            return;
        }

        // Make the grid
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                // Create a new grid space object for each cell
                gameGrid[x, z] = Instantiate(gridCellPrefab, new Vector3(x * gridSpaceSize, 0, z * gridSpaceSize), Quaternion.identity);
                gameGrid[x, z].GetComponent<GridCell>().SetPosition(x, z);
                gameGrid[x, z].transform.parent = transform;
                gameGrid[x, z].gameObject.name = "Grid Space (X: " + x.ToString() + " , Z: " + z.ToString() + ")";
            }
        }
    }

    // Gets the grid position from world position
    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition) 
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);
        int y = Mathf.FloorToInt(worldPosition.z / gridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x, y);
    }

    // Gets the world position of a grid position
    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x * gridSpaceSize;
        float y = gridPos.y * gridSpaceSize;

        return new Vector3(x, 0, y);
    }
}
