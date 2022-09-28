using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public ScriptableInt currentLevel;
    public GameObject levelText;
    int handmadeLevelLimit = 5;
    string lvltext;
    int level;
    private void Start()
    {
        lvltext = levelText.GetComponent<TextMeshProUGUI>().text;
        level = int.Parse(lvltext);
    }
    public void OpenLvl()
    {
        currentLevel.value = level;
        if (currentLevel.value > handmadeLevelLimit)
        {
            SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("ProceduralLevel", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("Level" + level, LoadSceneMode.Additive);
        }
    }
}
