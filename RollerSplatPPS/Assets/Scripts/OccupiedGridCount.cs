using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedGridCount : MonoBehaviour
{
    public ScriptableInt occupiedGridCount;
    public static Action OccupyOccurs;
    private void Start()
    {
        occupiedGridCount.value = 0;
    }
    private void OnEnable()
    {
        ChangeColor.ForOccupiedCount += CountOccupied;
    }
    private void OnDisable()
    {
        ChangeColor.ForOccupiedCount -= CountOccupied;
    }
    void CountOccupied()
    {
        occupiedGridCount.value++;
        OccupyOccurs?.Invoke();
    }
}
