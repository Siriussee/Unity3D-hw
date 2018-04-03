using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola3 : MonoBehaviour
{
    public float verticalspeed = 1;
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position,
            this.transform.position + new Vector3(-1, Time.deltaTime - 2 * this.transform.position.x) * Time.deltaTime,
        1.0f * Time.deltaTime);
    }
}
