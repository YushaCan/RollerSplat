using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScriptableInt currentLevel;
    public static Action ChangeScene;
    int time;
    private void Start()
    {
        time = 2;
    }
    private void OnEnable()
    {
        LevelSuccess.LvlSuccess += LevelUp;
    }
    private void OnDisable()
    {
        LevelSuccess.LvlSuccess -= LevelUp;
    }
    private IEnumerator LevelUpCoR()
    {
        currentLevel.value++;
        yield return new WaitForSeconds(time);
        ChangeScene?.Invoke();
    }
    void LevelUp()
    {
        StartCoroutine(LevelUpCoR());
    }
}
