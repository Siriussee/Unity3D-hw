using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public float acceleration = 1;
    public float speed = 10;
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * speed * acceleration;//s = (at^2)/2 = avt/2
        this.transform.position += Vector3.right * Time.deltaTime * speed;//s = vt
        acceleration++;
    }
}
