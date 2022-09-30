using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProceduralLevel : MonoBehaviour
{
    public GameObject obstacle, ball;
    public ScriptableVector3List vector3List;
    public ScriptableVector3List cannotDestroy;
    // Number of random steps of the path that can move forward
    int randomGridCountToMove;
    int minRandom = 1;
    int maxRandom = 8;
    ////////////////// 
    // For choosing the path direction
    int pathDirection;
    int tempValue;
    bool randomDirection;
    bool canGoLeft, canGoRight, canGoUp, canGoDown;
    /////////////////
    public int iterationCount = 5;
    int step = 1;
    Vector3 randomBallSpawnPoint;
    void Start()
    {
        canGoLeft = true;
        canGoRight = true;
        canGoUp = true;
        canGoDown = true;

        randomDirection = true;
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
        Debug.Log("Can go Left => " + canGoLeft + "\nCan go Right => " + canGoRight + "\nCan go Up => " + canGoUp + "\nCan go Down => " + canGoDown);
        Debug.Log("Random path direction => " + pathDirection);
        // TO LEFT
        /////////////////////////////////////////////////////////// IN CONSTRUCTION ///////////////////////////////////////////////////////////////
        if (pathDirection == 0 && canGoLeft)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    cannotDestroy.vector3.Add(new Vector3(vector3.x - step, vector3.y, vector3.z));
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    Debug.Log("VECTOR: " + vector3);
                    bool undestroyable = cannotDestroy.vector3.Contains(vector3);
                    if (vector3.x == 1 || undestroyable)
                    {
                        canGoLeft = false;
                        if (vector3.z == 1)
                        {
                            canGoDown = false;
                        }
                        else if (vector3.z == 8)
                        {
                            canGoUp = false;
                        }
                        break;
                    }
                    else
                    {
                        //Vector3 vector3 = vector3List.vector3[i - step];
                        vector3List.vector3.Add(new Vector3(vector3.x - step, vector3.y, vector3.z));
                        canGoRight = true;
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TO RIGHT
        if (pathDirection == 1 && canGoRight)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    cannotDestroy.vector3.Add(new Vector3(vector3.x + step, vector3.y, vector3.z));
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    Debug.Log("VECTOR: " + vector3);
                    bool undestroyable = cannotDestroy.vector3.Contains(vector3);
                    if (vector3.x == 8 || undestroyable)
                    {
                        canGoRight = false;
                        if (vector3.z == 1)
                        {
                            canGoDown = false;
                        }
                        else if (vector3.z == 8)
                        {
                            canGoUp = false;
                        }
                        break;
                    }
                    else
                    {
                        //Vector3 vector3 = vector3List.vector3[i - step];
                        vector3List.vector3.Add(new Vector3(vector3.x + step, vector3.y, vector3.z));
                        canGoLeft = true;
                    }
                }
            }
        }
        // TO UP
        else if (pathDirection == 2 && canGoUp)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    cannotDestroy.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z + step));
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    Debug.Log("VECTOR: " + vector3);
                    if (vector3.z == 8)
                    {
                        canGoUp = false;
                        bool undestroyable = cannotDestroy.vector3.Contains(vector3);
                        if (vector3.x == 1 || undestroyable)
                        {
                            canGoLeft = false;
                        }
                        else if (vector3.x == 8)
                        {
                            canGoRight = false;
                        }
                        break;
                    }
                    else
                    {
                        //Vector3 vector3 = vector3List.vector3[i - step];
                        vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z + step));
                        canGoDown = true;
                    }
                }         
            }
        }
        // TO DOWN
        else if (pathDirection == 3 && canGoDown)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            Debug.Log("Random grid count to move: " + randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    cannotDestroy.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z - step));
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    Debug.Log("VECTOR: " + vector3);
                    bool undestroyable = cannotDestroy.vector3.Contains(vector3);
                    if (vector3.z == 1 || undestroyable)
                    {
                        canGoDown = false;
                        if (vector3.x == 1)
                        {
                            canGoLeft = false;
                        }
                        else if (vector3.x == 8)
                        {
                            canGoRight = false;
                        }
                        break;
                    }
                    else
                    {
                        //Vector3 vector3 = vector3List.vector3[i - step];
                        vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z - step));
                        canGoUp = true;
                    }
                }
            }
        }
        if (randomDirection == true)
        {
            tempValue = UnityEngine.Random.Range(0, 1);
            // When previous move was right or left
            if (pathDirection == 0 || pathDirection == 1)
            {
                if (tempValue == 0 && canGoUp)
                {
                    //Debug.Log("To Up");
                    pathDirection = 2;
                }
                else if (tempValue == 0 && !canGoUp)
                {
                    pathDirection = 3;
                }
                else if(tempValue == 1 && canGoDown)
                {
                    //Debug.Log("To Down");
                    pathDirection = 3;
                }
                else if (tempValue == 1 && !canGoDown)
                {
                    pathDirection = 2;
                }
            }
            // When previous move was up or down
            else if (pathDirection == 2 || pathDirection == 3)
            {
                if (tempValue == 0 && canGoLeft)
                {
                    // Debug.Log("To left");
                    pathDirection = 0;
                }
                else if(tempValue == 0 && !canGoLeft)
                {
                    pathDirection = 1;
                }
                else if (tempValue == 1 && canGoRight)
                {
                    //Debug.Log("To Right");
                    pathDirection = 1;
                }
                else if (tempValue == 1 && !canGoRight)
                {
                    pathDirection = 0;
                }
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
