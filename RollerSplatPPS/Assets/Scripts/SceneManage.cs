using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public ScriptableInt currentLevel;
    int handmadeLevelLimit = 5;
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
        if (currentLevel.value > handmadeLevelLimit)
        {
            SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("ProceduralLevel", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("Level" + currentLevel.value, LoadSceneMode.Additive);
        }
    }
    public void RetryLevel()
    {
        if (currentLevel.value > handmadeLevelLimit)
        {
            SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("ProceduralLevel", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("Level" + currentLevel.value, LoadSceneMode.Additive);
        }
    }
}
