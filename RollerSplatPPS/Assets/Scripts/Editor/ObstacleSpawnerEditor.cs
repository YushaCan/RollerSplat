using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnObstacleAtStart))]
public class ObstacleSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox(
            "Edge obstacles are already done.\n" +
            "Give numbers (1-9) X and Z values to spawn obstacles in grid map", 
            MessageType.Warning);
        SpawnObstacleAtStart obstacleSpawnAtStart = (SpawnObstacleAtStart)target;
        base.OnInspectorGUI();
    }
}
