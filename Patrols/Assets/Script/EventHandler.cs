using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public delegate void GameOverEvent();
    public static event GameOverEvent GameOverChange; 

    public delegate void ScoreEvent();
    public static event ScoreEvent ScoreChange;

    public void PlayerEscape()
    {
        if(ScoreChange != null)
        {
            ScoreChange();
        }
    }

    public void PlayerCaught()
    {
        if(GameOverChange != null)
        {
            GameOverChange();
        }
    }
}
