using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {

    private List<GameObject> usingPatrolList;
    private GameObject patorl;
    private Vector3[] patorlPosition;

    private void Awake()
    {
        usingPatrolList = new List<GameObject>();
        patorl = null;
        patorlPosition = new Vector3[7];

        patorlPosition[0] = new Vector3(20, 0, 10);
        patorlPosition[1] = new Vector3(0, 0, 10);
        patorlPosition[2] = new Vector3(-10, 0, 5);
        patorlPosition[3] = new Vector3(-20, 0, 0);
        patorlPosition[4] = new Vector3(30, 0, 0);
        patorlPosition[5] = new Vector3(20, 0, -10);
        patorlPosition[6] = new Vector3(6, 0, -20);
    }

    public List<GameObject> GetPatrol()
    {
        for(int i=0;i<7;i++)
        {
            patorl = Instantiate(Resources.Load<GameObject>("Prefabs/Patrol"));
            patorl.transform.position = patorlPosition[i];
            patorl.GetComponent<Patrol>().start_postion = patorlPosition[i];
            usingPatrolList.Add(patorl);
        }

        return usingPatrolList;
    }
}
