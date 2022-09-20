using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public ScriptableBool gameStarts;
    public ScriptableBool isBallMoving;
    public void StartTheGame()
    {
        // Game starts
        gameStarts.isTrue = true;
        isBallMoving.isTrue = false;
    }
}
