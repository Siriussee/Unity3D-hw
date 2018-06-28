using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {

	public float bloodValue = 0.3f;
	private float ResultValue;
	private Rect rctBloodBar;
	private Rect rctUpButton;
	private Rect rctDownButton;
	private bool onoff;

	void Start()
	{
		rctBloodBar = new Rect(350, 190, 200, 20);  
		ResultValue = bloodValue;
	}

	void OnGUI()
	{
		if (ResultValue > 1.0f)
		{
			ResultValue = 1.0f;
		}
		if (ResultValue < 0.0f)
		{
			ResultValue = 0.0f;
		}

		//bloodValue = Mathf.Lerp(bloodValue, ResultValue, 0.05f);

		GUI.HorizontalScrollbar(rctBloodBar, 0.0f, bloodValue, 0.0f, 1.0f);  
	}
}