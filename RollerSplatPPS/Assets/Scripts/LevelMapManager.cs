using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapManager : MonoBehaviour
{
    public GameObject levelCircle;
    public ScriptableInt curLevel;
    public GameObject parentGO;
    private void Awake()
    {
        for (int i = 1; i <= curLevel.value; i++)
        {
            GameObject go = Instantiate(levelCircle);
            go.transform.SetParent(parentGO.transform);
            go.name = "Level" + i;
        }
    }
}
