using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;
    private GUIStyle style;
    private GUIStyle buttonStyle;

    public ScoreController scoreController
    {
        get;
        set;
    }

    // Use this for initialization
    void Start () {
        action = Director.GetInstance().CurrentScenceController as IUserAction;

        style = new GUIStyle();
        style.fontSize = 40;
        style.alignment = TextAnchor.MiddleCenter;

        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 20;

        this.gameObject.AddComponent<ScoreController>();
        scoreController = Singleton<ScoreController>.Instance;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, 10, 60, 20), "分数:" + action.GetScore().ToString());

        if(action.GetGameOver())
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - 20, 100, 100), "游戏结束");
            if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2, 100, 50), "重新开始"))
            {
                action.Restart();
                return;
            }
        }
    }
}
