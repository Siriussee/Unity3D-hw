using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  

public class sharp : MonoBehaviour {  
	public int turn;
	public int count;
	private int[,] cells = new int[3, 3];
	// Use this for initialization  
	void Start () {  
		restart();  
	}  
	void restart()  
	{  
		turn = 1;  
		for (int i = 0; i < 3; ++i)  
		{  
			for (int j = 0; j < 3; ++j)  
			{  
				cells[i, j] = 0;  
			}  
		}  
		count = 0;  
	}  
	private int winCheck()  
	{  
		for(int i = 0; i < 3; ++i)  
		{  
			if (cells[i, 0] != 0 && cells[i,0]==cells[i, 1] && cells[i, 1] == cells[i, 2])  
			{  
				return cells[i, 0];  
			}  
		}  
		for (int i = 0; i < 3; ++i)  
		{  
			if (cells[0, i] != 0 && cells[0, i] == cells[1, i] && cells[1, i] == cells[2, i])  
			{  
				return cells[0, i];  
			}  
		}  
		if(cells[1,1]!=0&&  
			cells[0,0]==cells[1,1]&&  
			cells[1,1]==cells[2,2]||  
			cells[0,2]==cells[1,1]&&  
			cells[1,1]==cells[2,0]  
		)  
		{  
			return cells[1, 1];  
		}  
		if (count == 9) return 3;  
		return 0;  
	}  
	private void OnGUI()  
	{  
		if(GUI.Button(new Rect(20, 300, 100, 50),"restart"))  
		{  
			restart();  
		}  
		int result = winCheck();//  

		GUIStyle temp = new GUIStyle  
		{  
			fontSize = 20  
		};  
		temp.normal.textColor = Color.red;  
		temp.fontStyle = FontStyle.BoldAndItalic;  

		switch (result)  
		{  
		case 1:  
			GUI.Label(new Rect(500, 100, 100, 50), "O WIN", style: temp);//先手赢;  
			break;  
		case 2:  
			GUI.Label(new Rect(500, 100, 100, 50), "X WIN", style: temp);//后手胜  
			break;  
		case 3:  
			GUI.Label(new Rect(500, 100, 100, 50), "DUAL", style: temp);//平局  
			break;  
		}  

		for (int i = 0; i < 3; ++i)  
		{  
			for(int j = 0; j < 3; ++j)  
			{  
				if (cells[i, j] == 1)  
				{  
					GUI.Button(new Rect(i * 50, j * 50, 50, 50), "0");  
				}  
				if (cells[i, j] == 2)  
				{  
					GUI.Button(new Rect(i * 50, j * 50, 50, 50), "X");  
				}  
				if(GUI.Button(new Rect(i * 50, j * 50, 50, 50), ""))  
				{  
					if (result == 0)  
					{  
						if (turn == 1) cells[i, j] = 1;  
						else cells[i, j] = 2;  
						count++;  
						turn = -turn;  
					}  
				}  
			}  
		}  
	}  
	// Update is called once per frame  
	void Update () {  

	}  
}  