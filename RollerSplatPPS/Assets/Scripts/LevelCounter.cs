using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCounter : MonoBehaviour
{
    public ScriptableInt totalLevel;
    int otherScenes = 3;
    void Awake()
    {
        totalLevel.value = SceneManager.sceneCountInBuildSettings - otherScenes;
    }
}
