using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectLocation : MonoBehaviour
{
    public ScrollRect scrollRect;
    public ScriptableInt currentLevel, totalLevel;
    void Start()
    {
        scrollRect = scrollRect.GetComponent<ScrollRect>();
        CalculateRectPos(currentLevel.value, totalLevel.value);
    }
    void CalculateRectPos(float currentLevel, float totalLevel)
    {
        float divide = currentLevel / totalLevel;
        Debug.Log("Divide => " + divide);
        if (divide <= .1f)
        {
            scrollRect.verticalNormalizedPosition = 0f;
        }
        else
        {
            scrollRect.verticalNormalizedPosition = divide;
        }
    }
}
