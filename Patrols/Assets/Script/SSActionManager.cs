using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour, ISSActionCallback {

    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    private List<SSAction> waitingList = new List<SSAction>();
    private List<int> toDelete = new List<int>();

    protected void Update()
    {
        foreach(SSAction action in waitingList)
        {
            actions[action.GetInstanceID()] = action;
        }
        waitingList.Clear();

        foreach(KeyValuePair<int, SSAction> keyvalue in actions)
        {
            SSAction action = keyvalue.Value;
            if(action.destroy)
            {
                toDelete.Add(action.GetInstanceID());
            }
            else if(action.enable)
            {
                action.Update();
            }
        }

        foreach(int key in toDelete)
        {
            SSAction action = actions[key];
            actions.Remove(key);
            DestroyObject(action);
        }
        toDelete.Clear();
    }

    public void Act(GameObject gameObject, SSAction action, ISSActionCallback callback)
    {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = callback;
        waitingList.Add(action);
        action.Start();
    }

    public void DestroyAll()
    {
        foreach(KeyValuePair<int ,SSAction> keyvalue in actions)
        {
            SSAction action = keyvalue.Value;
            action.destroy = true;
        }
    }

    public void SSActionEvent(SSAction source, int intParam = 0, GameObject objectParam = null)
    {
        if(intParam == 0)
        {
            PatrolFollow action = PatrolFollow.GetSSAction(objectParam.gameObject.GetComponent<Patrol>().player);
            this.Act(objectParam, action, this);
        }
        else
        {
            GoPatrolAction action = GoPatrolAction.GetSSAction(objectParam.gameObject.GetComponent<Patrol>().start_postion);
            this.Act(objectParam, action, this);
            Singleton<EventHandler>.Instance.PlayerEscape();
        }
    }
}
