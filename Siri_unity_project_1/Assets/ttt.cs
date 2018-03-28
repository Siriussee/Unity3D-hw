using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ttt : MonoBehaviour {
	int turn;
	int count;
	int[,] checkerboard = new int[3, 3];

	void Start () {  
		restart();  
	} 

	void Update () {  
		;
	}  

	//make all buttons unclicked
	void restart()  
	{  
		turn = 1;
		count = 0;
		for (int i = 0; i < 3; ++i)  
		{  
			for (int j = 0; j < 3; ++j)  
			{  
				checkerboard[i, j] = 0;  
			}  
		}  
	}  

	int winCheck()  
	{  
		//row
		for(int i = 0; i < 3; ++i)  
		{  
			if (checkerboard[i, 0] != 0 &&
				checkerboard[i,0]==checkerboard[i, 1] && 
				checkerboard[i, 1] == checkerboard[i, 2])  
			{  
				return checkerboard[i, 0];  
			}  
		}  
		//col
		for (int i = 0; i < 3; ++i)  
		{  
			if (checkerboard[0, i] != 0 && 
				checkerboard[0, i] == checkerboard[1, i] && 
				checkerboard[1, i] == checkerboard[2, i])  
			{  
				return checkerboard[0, i];  
			}  
		}  
		//cross line
		if(checkerboard[1,1]!=0&&  
			checkerboard[0,0]==checkerboard[1,1]&&  
			checkerboard[1,1]==checkerboard[2,2]||  
			checkerboard[0,2]==checkerboard[1,1]&&  
			checkerboard[1,1]==checkerboard[2,0]  
		)  
		{  
			return checkerboard[1, 1];  
		}  
		//dual
		if (count == 9) return 3; 
		//no result yet
		return 0;  
	} 

	void OnGUI()
    {
        
        if (GUI.Button(new Rect(20, 300, 100, 50),"restart"))  
			restart();  

		GUIStyle msgStyle = new GUIStyle  
		{  
			fontSize = 40  
		};

        GUI.Box(new Rect(0, 200, 150, 90), "Result");
        if (winCheck() == 1)
            GUI.Label(new Rect(20, 230, 100, 50), "O WIN", style: msgStyle);
        if (winCheck() == 2)
            GUI.Label(new Rect(20, 230, 100, 50), "X WIN", style: msgStyle);
        if (winCheck() == 3)
            GUI.Label(new Rect(20, 230, 100, 50), "DUAL", style: msgStyle);

        for (int i = 0; i < 3; ++i)  
		{  
			for(int j = 0; j < 3; ++j)  
			{  
				if (checkerboard[i, j] == 1)  
				{  
					GUI.Button(new Rect(i * 50, j * 50, 50, 50), "0");  
				}  
				if (checkerboard[i, j] == 2)  
				{  
					GUI.Button(new Rect(i * 50, j * 50, 50, 50), "X");  
				}  
				if(GUI.Button(new Rect(i * 50, j * 50, 50, 50), ""))  
				{  
					if (winCheck() == 0)  
					{  
						if (turn == 1) checkerboard[i, j] = 1;  
						else checkerboard[i, j] = 2;  
						count++;  
						turn = -turn;  
					}  
				}  
			}  
		}  
	}  


}
