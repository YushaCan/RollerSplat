using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSuccessUI : MonoBehaviour
{
    public GameObject LevelSuccessPanel;
    private void OnEnable()
    {
        LevelSuccess.LvlSuccess += SetEndGameUI;
    }
    private void OnDisable()
    {
        LevelSuccess.LvlSuccess -= SetEndGameUI;
    }
    void SetEndGameUI()
    {
        // All of the UI's shows up here when level has completed successfully
        LevelSuccessPanel.gameObject.SetActive(true);
    }
}
