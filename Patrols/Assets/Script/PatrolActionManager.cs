using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolActionManager : SSActionManager {

    private GoPatrolAction goPatrol;

    public void GoPatrol(GameObject patrol)
    {
        goPatrol = GoPatrolAction.GetSSAction(patrol.transform.position);
        this.Act(patrol, goPatrol, this);
    }

    public void DestroyAllAction()
    {
        DestroyAll();
    }
}
