using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelMapManager : MonoBehaviour
{
    public GameObject levelCircle;
    public ScriptableInt curLevel, totalLevel;
    public GameObject parentGO;
    private void Awake()
    {
        for (int i = 1; i <= totalLevel.value; i++)
        {
            GameObject go = Instantiate(levelCircle);
            go.transform.SetParent(parentGO.transform);
            go.name = "Level" + i;
            go.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            if (i == curLevel.value)
            {
                go.GetComponent<Image>().color = Color.green;
            }
        }
    }
}
