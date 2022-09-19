using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public ScriptableBool gameStarts;
    public ScriptableInt ballSpeed;

    Vector2 tapPos = new Vector2();
    Vector2 swipePos = new Vector2();
    float deltaX, deltaY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (Input.GetMouseButtonDown(0))
        {
            tapPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            swipePos = Input.mousePosition;
            deltaX = swipePos.x - tapPos.x;
            deltaY = swipePos.y - tapPos.y;
            // Ball Direction Check
            // UNDER CONSTRUCTION
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
