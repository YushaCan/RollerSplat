using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public ScriptableInt currentLevel;
    private void OnEnable()
    {
        LevelManager.ChangeScene += ChangeScene;
    }
    private void OnDisable()
    {
        LevelManager.ChangeScene -= ChangeScene;
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("Level0" + currentLevel.value, LoadSceneMode.Additive);
    }
}
