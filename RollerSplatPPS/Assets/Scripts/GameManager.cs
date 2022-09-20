using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableBool isGameStarts;
    public ScriptableBool isBallMoving;
    void Start()
    {
        isGameStarts.isTrue = false;
        isBallMoving.isTrue = false;
    }

}
