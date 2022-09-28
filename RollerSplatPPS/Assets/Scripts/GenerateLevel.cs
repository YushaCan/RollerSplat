using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateLevel : MonoBehaviour
{
    public ScriptableInt totalLevel;
    int addedLevelCount = 5;
    private void OnEnable()
    {
        GenerateLevelOnMap.GenerateLevels += GenerateLvl;
    }
    private void OnDisable()
    {
        GenerateLevelOnMap.GenerateLevels -= GenerateLvl;
    }
    void GenerateLvl()
    {
        totalLevel.value += addedLevelCount;
    }
}
