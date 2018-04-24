using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysisManager :  SSActionManager, IActionManager {

	public Physis fly;                            
	public FirstController scene_controller; 


	protected void Start()
	{
		scene_controller = (FirstController)SSDirector.GetInstance().CurrentScenceController;
		scene_controller.action_manager = this;     
	}

	public void UFOFly(GameObject disk, float angle, float power)
	{
		fly = Physis.GetSSAction(disk, angle, power);
		this.RunAction(disk, fly, this);
		disk.GetComponent<DiskData> ().action = fly;
		//Rigibody rb = disk.AddComponent<Rigibody> ();

		disk.GetComponent<Rigidbody>().velocity = Vector3.zero;
		Vector3 force = new Vector3 (6 * Random.Range(-1,1), 6 * Random.Range(0.5f,2), 13);
		disk.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
	}
}
