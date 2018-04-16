using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class MyClickGUI : MonoBehaviour
{
    UserAction action;
    MyCharacterController characterController;

    public void setController(MyCharacterController characterCtrl)
    {
        characterController = characterCtrl;
    }

    void Start()
    {
		
        action = Director.getInstance().currentSceneController as UserAction;

		if (Director.getInstance().currentSceneController != null)
			action = Director.getInstance().currentSceneController as UserAction;

		if (action == null)
			Debug.Log ("null in start");
    }

    void OnMouseDown()
    {
		if (action == null)
			return;
        if (gameObject.name == "boat")
        {
            action.moveBoat();

        }
        else
        {
            action.characterIsClicked(characterController);
        }
    }
}
