using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserGUI : MonoBehaviour
{
    private UserAction action;
    public int status = 0;
	private GameObject Camera0;
	private GameObject Camera1;
    GUIStyle style;
    GUIStyle buttonStyle;

    void Start()
    {
        action = Director.getInstance().currentSceneController as UserAction;

        style = new GUIStyle();
        style.fontSize = 40;
        style.alignment = TextAnchor.MiddleCenter;

        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 30;

		Camera0=GameObject.Find("Main Camera");
		Camera1=GameObject.Find("Camera1");
    }
    void OnGUI()
    {

		if(GUILayout.Button("侧面",GUILayout.Height(50))){
			Camera0.active=true;
			Camera1.active=false;
		}

		if(GUILayout.Button("正面",GUILayout.Height(50))){
			Camera0.active=false;
			Camera1.active=true;
		}

        if (status == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "Gameover!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                status = 0;
                action.restart();
            }
        }
        else if (status == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "You win!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart", buttonStyle))
            {
                status = 0;
                action.restart();
            }
        }
    }
}
