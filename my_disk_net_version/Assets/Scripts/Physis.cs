using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physis : SSAction
{
	private Vector3 start_vector;  
	private Vector3 force;  
	//public GameObject disk; 

	private Physis() { }
	public static Physis GetSSAction(GameObject d, float angle, float power)
	{
		Physis action = CreateInstance<Physis>();
		return action;
	}

	public override void Update()
	{
		//
	}

	public override void Start() { }

	public void FixedUpdate () 
	{
		//
	}

	public void Destory()
	{
		this.destroy = true;
		this.callback.SSActionEvent (this);
	}
}
