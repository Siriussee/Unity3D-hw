using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {
    public Transform father;
    private float r;
    private float r_x;
    private float r_y;
    // Use this for initialization
    void Start()
    {
        r = this.transform.position.x;
        r_x = Random.Range(1, 3);
        r_y = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(r_x, r_y, 0);
        float speed = 200.0f * Mathf.Sqrt(1.0f / (r * r * r));
        this.transform.RotateAround(father.position, axis, speed * Time.deltaTime);
    }
}
