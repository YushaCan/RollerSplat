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
    void Update()
    {
        // If game is Active
        if (gameStarts.isTrue)
        {
            MoveBall();
        }
    }
    void MoveBall()
    {
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
                isBallMoving.isTrue = true;
            }
        }
        isFirstStart = true;
        // UNDER CONSTRUCTION
        if (isBallMoving.isTrue == true)
        {
            // Ball Direction Check
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                // Ball moves horizontally
                if (deltaX < -1)
                {
                    // Left Movement
                    transform.Translate(Vector3.left * Time.deltaTime * ballSpeed.value);
                }
                else if (deltaX > 1)
                {
                    // Right Movement
                    transform.Translate(Vector3.right * Time.deltaTime * ballSpeed.value);
                }
            }
            else if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
            {
                // Ball moves vertically
                if (deltaY < -1)
                {
                    // Down Movement
                    transform.Translate(Vector3.back * Time.deltaTime * ballSpeed.value);
                }
                else if (deltaY > 1)
                {
                    // Up Movement
                    transform.Translate(Vector3.forward * Time.deltaTime * ballSpeed.value);
                }
            }
            /////////////////////////
        }

    }
}

