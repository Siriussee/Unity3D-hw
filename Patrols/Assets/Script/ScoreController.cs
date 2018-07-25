using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public FirstSceneController firstSceneController;
    public int score = 0;

    public void Score()
    {
        score++;
    }

	public int GetScore()
    {
        return score;
    }
}
