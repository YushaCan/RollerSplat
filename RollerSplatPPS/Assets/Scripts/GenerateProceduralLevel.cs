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
    int minRandom = 2;
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

        pathDirection = UnityEngine.Random.Range(0, 3);
        randomDirection = true;
        vector3List.vector3.Clear();
        SpawnBallRandomly();
        // Iteration Count
        for (int i = 0; i < iterationCount; i++)
        {
            LevelGenerateAlgorithm();
        }
        SpawnObstacles();
    }
    void LevelGenerateAlgorithm()
    {
        // TO LEFT
        /////////////////////////////////////////////////////////// IN CONSTRUCTION ///////////////////////////////////////////////////////////////
        if (pathDirection == 0 && canGoLeft)
        {
            randomGridCountToMove = UnityEngine.Random.Range(minRandom, maxRandom);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    if (vector3.x == 1)
                    {
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
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    if (vector3.x == 8)
                    {
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
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    if (vector3.z == 8)
                    {
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
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i <= totalPathGrids + randomGridCountToMove; i++)
            {
                if (i == totalPathGrids + randomGridCountToMove)
                {
                    break;
                }
                else
                {
                    Vector3 vector3 = vector3List.vector3[i - step];
                    if (vector3.z == 1)
                    {
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
                        vector3List.vector3.Add(new Vector3(vector3.x, vector3.y, vector3.z - step));
                        canGoUp = true;
                    }
                }
            }
        }
        // TO check that previous move will not the same with continuous move
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
        // To check previous move's last grid is on the edge or not. If on the edge it will not allow to go that direction again
        int count = vector3List.vector3.Count - 1;
        Vector3 conrolVector3 = vector3List.vector3[count];
        if (conrolVector3.x == 1)
        {
            canGoLeft = false;
        }
        if (conrolVector3.x == 8)
        {
            canGoRight = false;
        }
        if (conrolVector3.z == 1)
        {
            canGoDown = false;
        }
        if (conrolVector3.z == 8)
        {
            canGoUp = false;
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
