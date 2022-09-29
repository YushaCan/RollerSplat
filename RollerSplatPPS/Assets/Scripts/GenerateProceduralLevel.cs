using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProceduralLevel : MonoBehaviour
{
    public GameObject obstacle, ball;
    public ScriptableVector3List vector3List;
    // Number of random steps of the path that can move forward
    int randomGridCountToMove;
    int minRandom = 1;
    int maxRandom = 8;
    ////////////////// 
    // For choosing the path direction
    int pathDirection;
    int previousPathDirection;
    /////////////////
    int iterationCount = 10;
    int step = 1;
    Vector3 randomBallSpawnPoint;
    void Start()
    {
        vector3List.vector3.Clear();
        previousPathDirection = -1;
        // Iteration Count
        SpawnBallRandomly();
        for (int i = 0; i < iterationCount; i++)
        {
            Debug.Log("Iteration " + (i + 1));
            LevelGenerateAlgorithm();
        }
    }
    void LevelGenerateAlgorithm()
    {
        pathDirection = Random.Range(0, 3);
        Debug.Log("Random path direction => " + pathDirection);
        //pathDirection = 0;
        // TO LEFT
        /////////////////////////////////////////////////////////// IN CONSTRUCTION ///////////////////////////////////////////////////////////////
        if (pathDirection == 0 && previousPathDirection != pathDirection)
        {
            previousPathDirection = pathDirection;
            randomGridCountToMove = Random.Range(minRandom, maxRandom);
            Debug.Log(randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].x <= 1)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x - step, vector3.y, vector3.z));
                    // Destroy the grid for create the path
                    GameObject go = GameObject.Find("Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")");
                    Destroy(go);
                    
                    /*
                    GameObject go = Instantiate(obstacle, vector3List.vector3[i], Quaternion.identity);
                    go.transform.parent = GameObject.Find("Obstacles").transform;
                    go.transform.name = "Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")";
                    */
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TO RIGHT
        if (pathDirection == 1 && previousPathDirection != pathDirection)
        {
            previousPathDirection = pathDirection;
            randomGridCountToMove = Random.Range(minRandom, maxRandom);
            Debug.Log(randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].x >= 8)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x + step, vector3.y, vector3.z));
                    // Destroy the grid for create the path
                    GameObject go = GameObject.Find("Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")");
                    Destroy(go);
                    /*
                    GameObject go = Instantiate(obstacle, vector3List.vector3[i], Quaternion.identity);
                    go.transform.parent = GameObject.Find("Obstacles").transform;
                    go.transform.name = "Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")";
                    */
                }
            }
        }
        // TO UP
        else if (pathDirection == 2 && previousPathDirection != pathDirection)
        {
            previousPathDirection = pathDirection;
            randomGridCountToMove = Random.Range(minRandom, maxRandom);
            Debug.Log(randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].z >= 8)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z + step));
                    // Destroy the grid for create the path
                    GameObject go = GameObject.Find("Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")");
                    Destroy(go);
                    /*
                    GameObject go = Instantiate(obstacle, vector3List.vector3[i], Quaternion.identity);
                    go.transform.parent = GameObject.Find("Obstacles").transform;
                    go.transform.name = "Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")";
                    */
                }
            }
        }
        // TO DOWN
        else if (pathDirection == 3 && previousPathDirection != pathDirection)
        {
            previousPathDirection = pathDirection;
            randomGridCountToMove = Random.Range(minRandom, maxRandom);
            Debug.Log(randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].z <= 1)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z - step));
                    // Destroy the grid for create the path
                    GameObject go = GameObject.Find("Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")");
                    Destroy(go);
                    /*
                    GameObject go = Instantiate(obstacle, vector3List.vector3[i], Quaternion.identity);
                    go.transform.parent = GameObject.Find("Obstacles").transform;
                    go.transform.name = "Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")";
                    */
                }
            }
        }
        // For randomize the direction value again
        else
        {
            Debug.Log("Previous and current directions are the same: p: " + previousPathDirection + " c: " + pathDirection);
            pathDirection = Random.Range(0, 3);
        }
    }
    void SpawnBallRandomly()
    {
        int x = Random.Range(minRandom, maxRandom);
        int y = 1;
        int z = Random.Range(minRandom, maxRandom);
        // Ball Spawn point
        randomBallSpawnPoint = new Vector3(x, y, z);
        vector3List.vector3.Add(new Vector3(x, y, z));
        GameObject obstacle = GameObject.Find("Grid Space (X: " + randomBallSpawnPoint.x.ToString() + " , Z: " + randomBallSpawnPoint.z.ToString() + ")");
        Destroy(obstacle);
        Instantiate(ball, randomBallSpawnPoint, Quaternion.identity);
    }
}
