using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScriptableBool isGameStarts;
    public ScriptableBool isBallMoving;
    public GameStateScriptable gameState;
    void Start()
    {
        isGameStarts.isTrue = false;
        isBallMoving.isTrue = false;
        gameState.lose = false;
        gameState.win = false;
        gameState.gameActive = false;
    }

    private void Update()
    {
        if (!isGameStarts.isTrue)
        {
            gameState.gameActive = false;
        }
        else if (isGameStarts.isTrue)
        {
            gameState.gameActive = true;
        }
    }
    private void OnEnable()
    {
        LevelSuccess.LvlSuccess += LevelSucceed;
    }
    private void OnDisable()
    {
        LevelSuccess.LvlSuccess -= LevelSucceed;
    } 
    void LevelSucceed()
    {
        gameState.gameActive = false;
        isGameStarts.isTrue = false;
        gameState.win = true;
    }
}
