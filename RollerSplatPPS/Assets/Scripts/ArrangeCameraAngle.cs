using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeCameraAngle : MonoBehaviour
{
    void Start()
    {
        Camera.main.aspect = 9f / 16f;
    }
}
