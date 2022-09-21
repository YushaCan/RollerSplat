using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall : MonoBehaviour
{
    public ScriptableBool isBallMoving;
    public static Action BallCollides;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BallCollides?.Invoke();
            isBallMoving.isTrue = false;
        }
    }
}
