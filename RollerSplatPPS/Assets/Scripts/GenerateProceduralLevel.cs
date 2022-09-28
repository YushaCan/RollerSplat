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
    /////////////////
    int step = 1;
    Vector3 randomBallSpawnPoint;
    void Start()
    {
        vector3List.vector3.Clear();
        LevelGenerateAlgorithm();
    }
    void LevelGenerateAlgorithm()
    {
        SpawnBallRandomly();
        //pathDirection = Random.Range(0, 3);
        pathDirection = 0;
        // TO LEFT
        /////////////////////////////////////////////////////////// IN CONSTRUCTION ///////////////////////////////////////////////////////////////
        if (pathDirection == 0)
        {
            randomGridCountToMove = Random.Range(minRandom, maxRandom);
            Debug.Log(randomGridCountToMove);
            int totalPathGrids = vector3List.vector3.Count;
            for (int i = totalPathGrids; i < totalPathGrids + randomGridCountToMove; i++)
            {
                Vector3 vector3 = vector3List.vector3[i - step];
                if (vector3.x <= 1)
                {
                    continue;
                }
                else
                {
                    vector3List.vector3.Add(new Vector3(vector3.x - step, vector3.y, vector3.z));
                    GameObject go = Instantiate(obstacle, vector3List.vector3[i], Quaternion.identity);
                    go.transform.parent = GameObject.Find("Obstacles").transform;
                    go.transform.name = "Grid Space (X: " + vector3List.vector3[i].x.ToString() + " , Z: " + vector3List.vector3[i].z.ToString() + ")";
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TO RIGHT
        else if (pathDirection == 1)
        {

        }
        // TO UP
        else if (pathDirection == 2)
        {

        }
        // TO DOWN
        else if (pathDirection == 3)
        {

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
        Instantiate(ball, randomBallSpawnPoint, Quaternion.identity);
    }
}
