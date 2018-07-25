using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFollow : SSAction {

    private float speed = 5f;
    private GameObject player;
    private Patrol patrol;

    public override void Start()
    {
        patrol = this.gameObject.GetComponent<Patrol>();
    }

    public override void Update()
    {
        if (transform.localEulerAngles.x != 0 || transform.localEulerAngles.z != 0) {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }

        if (transform.position.y != 0) {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        Follow();

        if (patrol.follow == false)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this, 1, this.gameObject);
        }
    }

    private PatrolFollow() { }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        this.transform.LookAt(player.transform.position);
    }

    public static PatrolFollow GetSSAction(GameObject player)
    {
        PatrolFollow action = CreateInstance<PatrolFollow>();
        action.player = player;
        return action;
    }
}
