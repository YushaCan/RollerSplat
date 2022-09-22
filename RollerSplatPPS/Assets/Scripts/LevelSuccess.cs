using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSuccess : MonoBehaviour
{
    public ScriptableInt totalGridCount, occupiedGrids;
    public static Action LvlSuccess;

    private void OnEnable()
    {
        OccupiedGridCount.OccupyOccurs += SuccessCheck;
    }
    private void OnDisable()
    {
        OccupiedGridCount.OccupyOccurs -= SuccessCheck;
    }
    void SuccessCheck()
    {
        // Level Success
        if (occupiedGrids.value == totalGridCount.value)
        {
            LvlSuccess?.Invoke();
            // NEXT LEVEL
            Debug.Log("LEVEL SUCCESS");
        }
    }
}
