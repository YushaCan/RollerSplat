using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall : MonoBehaviour
{
    public ScriptableBool isBallMoving;
    public static Action BallCollides;

    private void OnEnable()
    {
        LevelSuccess.LvlSuccess += StopTheBall;
    }
    private void OnDisable()
    {
        LevelSuccess.LvlSuccess -= StopTheBall;
    }
    void StopTheBall()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BallCollides?.Invoke();
            isBallMoving.isTrue = false;
        }
    }

}
