using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleAtStart : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3[] obstacleSpawnPoints;
    void Start()
    {
        for (int i = 0; i < obstacleSpawnPoints.Length; i++)
        {
            obstacleSpawnPoints[i].y = 1;
            Instantiate(obstacle, obstacleSpawnPoints[i], Quaternion.identity);
        }
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                if ((x != 0 && z != 0) && (x != 9 && z != 9))
                {
                    continue;
                }
                GameObject go = Instantiate(obstacle, new Vector3(x, 1, z) ,Quaternion.identity);
                go.transform.parent = GameObject.Find("Obstacles").transform;
                go.transform.name = "Grid Space (X: " + x.ToString() + " , Z: " + z.ToString() + ")";
            }
        }
    }
}
