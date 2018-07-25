using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPatrolAction : SSAction {

	private enum Direction {
        NORTH,
        WEST,
        SOUTH,
        EAST
    };
    private Patrol patrol;
    private float x;
    private float y;
    private float length;
    private float speed = 1.2f;
    private bool arrived = true;
    private Direction direction = Direction.EAST;

    public override void Start() {
        patrol = this.gameObject.GetComponent<Patrol>();
        this.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);
    }

    public override void Update()
    {
        if(patrol.follow == false)
        {
            Gopatrol();
        }
        else
        {
            this.destroy = true;
            this.callback.SSActionEvent(this, 0, this.gameObject);
        }
    }

    private GoPatrolAction()
    {

    }

    private void Gopatrol()
    {
        if(arrived)
        {
            if(direction == Direction.EAST)
            {
                x -= length;
            }
            else if(direction == Direction.WEST)
            {
                x += length;
            }
            else if(direction == Direction.SOUTH)
            {
                y -= length;
            }
            else
            {
                y += length;
            }
            arrived = false;
        }

        this.transform.LookAt(new Vector3(x, 0, y));
        float distance = Vector3.Distance(transform.position, new Vector3(x, 0, y));

        if(distance > 0.1)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(x, 0, y), speed * Time.deltaTime);
        }
        else
        {
            direction = direction + 1;
            if (direction > Direction.EAST)
            {
                direction = Direction.NORTH;
            }
            arrived = true;
        }

    }

    public static GoPatrolAction GetSSAction(Vector3 destination)
    {
        GoPatrolAction action = CreateInstance<GoPatrolAction>();
        action.x = destination.x;
        action.y = destination.z;
        action.length = Random.Range(4, 4);

        return action;
    }
}
