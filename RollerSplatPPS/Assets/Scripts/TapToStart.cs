using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public GameObject tapToStartText;
    public ScriptableBool gameStarts;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Game starts
            tapToStartText.gameObject.SetActive(false);
            gameStarts.isTrue = true;
        }
    }
}
