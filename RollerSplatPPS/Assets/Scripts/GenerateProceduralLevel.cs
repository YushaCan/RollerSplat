using System;
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
    int tempValue;
    int constructingCount;
    int deletedCount;
    /////////////////
    public int iterationCount = 5;
    int step = 1;
    Vector3 randomBallSpawnPoint;
    void Start()
    {
        constructingCount = 0;
        deletedCount = 0;
        pathDirection = UnityEngine.Random.Range(0, 3);
        vector3List.vector3.Clear();
        SpawnBallRandomly();
        // Iteration Count
        for (int i = 0; i < iterationCount; i++)
        {
            Debug.Log("Iteration " + (i + 1));
            LevelGenerateAlgorithm();
        }
        SpawnObstacles();
    }
    void LevelGenerateAlgorithm()
    {
        constructingCount = 0;
        deletedCount = 0;
        Debug.Log("Random path direction => " + pathDirection);
        // TO LEFT
        /////////////////////////////////////////////////////////// IN CONSTRUCTION ///////////////////////////////////////////////////////////////
        if (pathDirection == 0)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].x < 1)
                {
                    deletedCount++;
                    Debug.Log("Deleted grid");
                    vector3List.vector3.RemoveAt(i - 1);
                    break;
                }
                else
                {
                    constructingCount++;
                    Debug.Log("CONSTRUCTING");
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x - step, vector3.y, vector3.z));
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TO RIGHT
        if (pathDirection == 1)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].x > 8)
                {
                    deletedCount++;
                    Debug.Log("Deleted grid");
                    vector3List.vector3.RemoveAt(i - 1);
                    break;
                }
                else
                {
                    constructingCount++;
                    Debug.Log("CONSTRUCTING");
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x + step, vector3.y, vector3.z));
                }
            }

        }
        // TO UP
        else if (pathDirection == 2)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].z > 8)
                {
                    deletedCount++;
                    Debug.Log("Deleted grid");
                    vector3List.vector3.RemoveAt(i - 1);
                    break;
                }
                else
                {
                    constructingCount++;
                    Debug.Log("CONSTRUCTING");
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z + step));
                }
            }
        }
        // TO DOWN
        else if (pathDirection == 3)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                if (vector3List.vector3[i - step] == null || vector3List.vector3[i - step].z < 1)
                {
                    deletedCount++;
                    Debug.Log("Deleted grid");
                    vector3List.vector3.RemoveAt(i - 1);
                    break;
                }
                else
                {
                    constructingCount++;
                    Debug.Log("CONSTRUCTING");
                    Vector3 vector3 = vector3List.vector3[i - step];
                    vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z - step));
                }
            }
        }
        tempValue = UnityEngine.Random.Range(0, 1);
        Debug.Log("Temp Value: " + tempValue);
        ////// INSTRUCTION CONTINUE ///////
        if ((constructingCount - deletedCount) == 0)
        {
            Debug.Log("PRODUCTION STOPPPEEEEED");
        }
        ////////////////////////////////////
        // When previous move was rigt or left
        if (pathDirection == 0 || pathDirection == 1)
        {
            if (tempValue == 0)
            {
                Debug.Log("To Up");
                pathDirection = 2;
            }
            else
            {
                Debug.Log("To Down");
                pathDirection = 3;
            }
        }
        // When previous move was up or down
        else if (pathDirection == 2 || pathDirection == 3)
        {
            if (tempValue == 0)
            {
                Debug.Log("To left");
                pathDirection = 0;
            }
            else
            {
                Debug.Log("To Right");
                pathDirection = 1;
            }
        }
    }
    void SpawnBallRandomly()
    {
        int x = UnityEngine.Random.Range(minRandom, maxRandom);
        int y = 1;
        int z = UnityEngine.Random.Range(minRandom, maxRandom);
        // Ball Spawn point
        randomBallSpawnPoint = new Vector3(x, y, z);
        vector3List.vector3.Add(new Vector3(x, y, z));
        Instantiate(ball, randomBallSpawnPoint, Quaternion.identity);
    }
    void SpawnObstacles()
    {
        for (int x = 1; x <= 8; x++)
        {
            for (int z = 1; z <= 8; z++)
            {
                if (vector3List.vector3.Contains(new Vector3(x, 1, z)))
                {
                    continue;
                }
                GameObject go = Instantiate(obstacle, new Vector3(x, 1, z), Quaternion.identity);
                go.transform.parent = GameObject.Find("Obstacles").transform;
                go.transform.name = "Grid Space (X: " + x.ToString() + " , Z: " + z.ToString() + ")";
            }
        }
    }
}
