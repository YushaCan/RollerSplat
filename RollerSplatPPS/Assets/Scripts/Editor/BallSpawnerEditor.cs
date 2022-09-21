using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnBallAtStart))]
public class BallSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Make sure to enter Y value as 1\nAlso X and Z values are between 0-10 (10 excluded)", MessageType.Warning);
        base.OnInspectorGUI();
        SpawnBallAtStart spawnBallAtStart = (SpawnBallAtStart)target;
    }
}
