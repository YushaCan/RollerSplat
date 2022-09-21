using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnBallAtStart : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballSpawnPoint;
    

    void Start()
    {
        ballSpawnPoint.y = 1;
        Instantiate(ball, ballSpawnPoint, Quaternion.identity);
    }
}
