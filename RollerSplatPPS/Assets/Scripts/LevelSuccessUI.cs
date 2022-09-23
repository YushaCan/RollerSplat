using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSuccessUI : MonoBehaviour
{
    public GameObject LevelSuccessPanel, retryImage;
    public ParticleSystem confettiLeftTop, confettiLeftBot, confettiRightTop, confettiRightBot;

    private void OnEnable()
    {
        LevelSuccess.LvlSuccess += SetEndGameUI;
    }
    private void OnDisable()
    {
        LevelSuccess.LvlSuccess -= SetEndGameUI;
    }
    void  SetEndGameUI()
    {
        // All of the UI's shows up here when level has completed successfully
        LevelSuccessPanel.gameObject.SetActive(true);
        confettiLeftTop.Play();
        confettiLeftBot.Play();
        confettiRightTop.Play();
        confettiRightBot.Play();
        retryImage.gameObject.SetActive(false);
    }
}
