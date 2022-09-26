using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallMovement : MonoBehaviour
{
    public ScriptableBool gameStarts;
    public ScriptableBool isBallMoving;
    public ScriptableInt ballSpeed;

    public bool isFirstStart = false;

    bool left, right, up, down;
    float translateAmount = 0.2f;

    Vector2 tapPos = new Vector2();
    Vector2 swipePos = new Vector2();
    float deltaX, deltaY;

    Rigidbody ballRb;
    Action MoveTheBall;

    Animator ballAnimator;
    private void Awake()
    {
       ballAnimator = gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        ballAnimator.enabled = false;
        ballRb = GetComponent<Rigidbody>();
        left = false;
        right = false;
        up = false;
        down = false;
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
        LevelSuccess.LvlSuccess += AnimateBall;
        MoveTheBall += MoveBall;
        StopBall.BallCollides += ArrangeConstraintsAndPos;
    }
    private void OnDisable()
    {
        LevelSuccess.LvlSuccess -= AnimateBall;
        MoveTheBall -= MoveBall;
        StopBall.BallCollides -= ArrangeConstraintsAndPos;
    }
    IEnumerator AnimateNumerator()
    {
        ballAnimator.enabled = true;
        transform.DOMoveY(3f, .2f);
        yield return new WaitForSeconds(.2f);
        transform.DOMoveY(1f, .2f);
        yield return new WaitForSeconds(.2f);
        transform.DOMoveY(2f, .2f);
        yield return new WaitForSeconds(.2f);
        transform.DOMoveY(1f, .2f);
    }
    void AnimateBall()
    {
        StartCoroutine(AnimateNumerator());
    }
    void ArrangeConstraintsAndPos()
    {
        //ballRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        if (left)
        {
            transform.Translate(translateAmount, 0, 0);
            left = false;
            right = false;
            up = false;
            down = false;
        }
        else if (right)
        {
            transform.Translate(-translateAmount, 0, 0);
            left = false;
            right = false;
            up = false;
            down = false;
        }
        else if (up)
        {
            transform.Translate(0, 0, -translateAmount);
            left = false;
            right = false;
            up = false;
            down = false;
        }
        else if (down)
        {
            transform.Translate(0, 0, translateAmount);
            left = false;
            right = false;
            up = false;
            down = false;
        }
        ballRb.velocity = new Vector3(0, 0, 0);     
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
                left = true;
                //ballRb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else if (deltaX > 1)
            {
                // Right Movement
                ballRb.velocity = new Vector3(ballSpeed.value, 0, 0);
                right = true;
                //ballRb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
        }
        else if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
        {
            // Ball moves vertically
            if (deltaY < -1)
            {
                // Down Movement
                ballRb.velocity = new Vector3(0, 0, -ballSpeed.value);
                down = true;
                //ballRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else if (deltaY > 1)
            {
                // Up Movement
                ballRb.velocity = new Vector3(0, 0, ballSpeed.value);
                up = true;
                //ballRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
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

