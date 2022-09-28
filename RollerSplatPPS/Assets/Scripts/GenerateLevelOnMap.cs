using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GenerateLevelOnMap : MonoBehaviour
{
    public GameObject levelCircle, parentGO;
    public ScriptableInt curLevel, totalLevel;
    int createdLevelCount = 5;
    public static Action GenerateLevels;
    public void GenerateLvlOnMap()
    {
        for (int i = totalLevel.value + 1; i <= totalLevel.value + createdLevelCount; i++)
        {
            GameObject go = Instantiate(levelCircle);
            go.transform.SetParent(parentGO.transform);
            go.name = "Level" + i;
            go.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            if (i == curLevel.value)
            {
                go.GetComponent<Image>().color = Color.green;
            }
            // Action here for create the map and save it to the build settings
        }
            GenerateLevels?.Invoke();
    }
}
