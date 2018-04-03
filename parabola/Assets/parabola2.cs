using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public float acceleration = 1;
    public float speed = 10;
    void Update()
    {
        transform.Translate(new Vector3(Time.deltaTime * speed, Time.deltaTime * acceleration, 0));
        acceleration++;
    }
}