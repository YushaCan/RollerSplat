using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Game State")]
public class GameStateScriptable : ScriptableObject
{
    public bool gameActive;
    public bool win;
    public bool lose;
}
