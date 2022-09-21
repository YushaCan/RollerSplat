using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public ScriptableBool gameStarts;
    public ScriptableBool isBallMoving;
    public ScriptableInt ballSpeed;

    public bool isFirstStart = false;

    Vector2 tapPos = new Vector2();
    Vector2 swipePos = new Vector2();
    float deltaX, deltaY;

    Rigidbody ballRb;
    Action MoveTheBall;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // If game is Active
        if (gameStarts.isTrue)
        {
            TouchControl();
        }
    }
    private void OnEnable()
    {
        MoveTheBall += MoveBall;
        StopBall.BallCollides += ArrangeConstraints;
    }
    private void OnDisable()
    {
        MoveTheBall -= MoveBall;
        StopBall.BallCollides -= ArrangeConstraints;
    }
    void ArrangeConstraints()
    {
        ballRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    void MoveBall()
    {
        isBallMoving.isTrue = true;
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            // Ball moves horizontally
            if (deltaX < -1)
            {
                // Left Movement
                ballRb.velocity = new Vector3(-ballSpeed.value, 0, 0);
                ballRb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else if (deltaX > 1)
            {
                // Right Movement
                ballRb.velocity = new Vector3(ballSpeed.value, 0, 0);
                ballRb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
        }
        else if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
        {
            // Ball moves vertically
            if (deltaY < -1)
            {
                // Down Movement
                ballRb.velocity = new Vector3(0, 0, -ballSpeed.value);
                ballRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else if (deltaY > 1)
            {
                // Up Movement
                ballRb.velocity = new Vector3(0, 0, ballSpeed.value);
                ballRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
    void TouchControl()
    {
        if (isBallMoving.isTrue && (ballRb.velocity.x == 0 && ballRb.velocity.z == 0))
        {
            ballRb.velocity = new Vector3(0, 0, 0);
            isBallMoving.isTrue = false;
        }
        if (isBallMoving.isTrue == false && isFirstStart == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tapPos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                swipePos = Input.mousePosition;
                deltaX = swipePos.x - tapPos.x;
                deltaY = swipePos.y - tapPos.y;
                MoveTheBall?.Invoke();
            }
        }
        isFirstStart = true;
    }
}

