using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public ScriptableInt currentLevel;
    public GameObject levelText;
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
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("Level" + level, LoadSceneMode.Additive);
    }
}
