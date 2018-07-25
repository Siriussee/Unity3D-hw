using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCollide : MonoBehaviour {

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<Patrol>().follow = true;
            this.gameObject.transform.parent.GetComponent<Patrol>().player = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.GetComponent<Patrol>().follow = false;
            this.gameObject.transform.parent.GetComponent<Patrol>().player = null;
        }
    }
}
