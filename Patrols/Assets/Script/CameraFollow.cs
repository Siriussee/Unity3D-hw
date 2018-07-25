using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour {
    //public GameObject target;            // The position that that camera will be following.
    public Transform target;
    public float smoothing = 5f;        // The speed with which the camera will be following.

    Vector3 offset;                     // The initial offset from the target.

    bool firsttime = true;

    void FixedUpdate()
    {
        if(firsttime)
        {
            while (target == null)
            {
                target = GameObject.Find("Player(Clone)").transform;
            }
            offset = transform.position - target.position;
            firsttime = false;
        }     
        
        // Create a postion the camera is aiming for based on the offset from the target.
        //Vector3 targetCamPos = target.transform.position + offset;
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
