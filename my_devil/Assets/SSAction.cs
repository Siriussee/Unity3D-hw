using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SSActionEventType:int {Started,Completed}

public class SSAction : ScriptableObject {

	public bool enable = true;
	public bool destory = false;

	public GameObject gameobject { get; set;}
	public Transform transform { get; set;}
	public ISSActionCallback callback { get; set;}

	protected SSAction(){}

	// Use this for initialization
	public virtual void Start () {
		throw new System.NotImplementedException ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		throw new System.NotImplementedException ();
	}
}


public class CCMoveToAction : SSAction{
	public Vector3 target;
	public float speed = 10;

	public static CCMoveToAction GetAction(Vector3 target, float speed){
		CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction> ();
		action.target = target;
		action.speed = speed;
		return action;	
	}
	public override void Start (){
	}
	public override void Update(){
		this.transform.position = Vector3.MoveTowards(this.transform.position,target,speed * Time.deltaTime);
		if (this.transform.position == target ){
			this.destory = true;
			this.callback.SSActionEvent(this);
		}	
	}
}

public class CCSequenceAction : SSAction, ISSActionCallback{
	public List<SSAction> sequence;
	public int repeat = -1;
	public int start = 0;

	public void SSActionEvent(SSAction source,	SSActionEventType events,int intParam,string strParam ,Object ObjectParam){
	}

	public static CCSequenceAction GetSSAction(int repeat, int start, List<SSAction> sequence){
		CCSequenceAction action = ScriptableObject.CreateInstance<CCSequenceAction> ();
		action.repeat = repeat;
		action.sequence = sequence;
		action.start = start;
		return action;
	}

	public override void Update(){
		if (sequence.Count == 0)
			return;
		if(start <sequence.Count){
			sequence[start].Update ();
		}
	}
	public void SSActionEvent (SSAction source, SSActionEventType events = SSActionEventType.Completed){
		source.destory = false;
		this.start++;
		if (this.start >= sequence.Count) {
			this.start = 0;
			if (repeat > 0)
				repeat--;
			if (repeat == 0) {
				this.destory = true;
				this.callback.SSActionEvent (this);
			}
		}
	}
		
	public override void Start(){
		foreach(SSAction action in sequence){
			action.gameobject = this.gameobject;
			action.transform = this.transform;
			action.callback = this;
			action.Start ();
		}
	}

	void OnDestory(){
		foreach(SSAction action in sequence){
			DestroyObject (action);
		}
	}
}


public interface ISSActionCallback{
	void SSActionEvent(SSAction source,
		SSActionEventType events = SSActionEventType.Completed,
		int intParam = 0,
		string strParam = null,
		Object ObjectParam = null);
}

public class SSActionManager :MonoBehaviour, ISSActionCallback{

	private Dictionary<int, SSAction> actions = new Dictionary<int,SSAction>();
	private List<SSAction> waitingAdd = new List<SSAction>();
	private List<int> waitingDelete = new List<int>();

	public void SSActionEvent(SSAction source,	SSActionEventType events,int intParam,string strParam ,Object ObjectParam){
	}

	protected void Update(){
		foreach(SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
		waitingAdd.Clear ();

		foreach(KeyValuePair <int, SSAction> kv in actions){
			SSAction ac = kv.Value;
			if (ac.destory)
				waitingDelete.Add (ac.GetInstanceID ());
			else if (ac.enable)
				ac.Update ();
		}

		foreach(int key in waitingDelete){
			SSAction ac = actions[key];
			actions.Remove (key);
			DestroyObject (ac);
		}
		waitingDelete.Clear ();
	}

	public void RunAction(GameObject gameobject, SSAction action ,ISSActionCallback manager){
		action.gameobject = gameobject;
		action.transform = gameobject.transform;
		action.callback = manager;
		waitingAdd.Add(action);
		action.Start();
	}

	protected void Start(){
	}
}


		


